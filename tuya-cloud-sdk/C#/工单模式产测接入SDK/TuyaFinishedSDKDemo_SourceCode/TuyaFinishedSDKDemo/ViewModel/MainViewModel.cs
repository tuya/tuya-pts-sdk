using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Controls;
using TuyaFinished_SDK;
using System.Threading;
using TuyaFinished_SDK.Model;
using System.Collections.Generic;
using System.Windows;

namespace TuyaFinishedSDKDemo.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

        }

        private void ExecuteTuyaButtonCommand(object data)
        {
            if (data is ContentControl control)
            {
                switch (control.Name)
                {
                    case "LoginButton": FuncLoginButton(); break;
                    case "WorkOrderButton": FuncWorkOrderButton(); break;
                    case "ProductTransitButton": FuncProductTransitButton();break;
                    case "ProductionTestLogUpload": FuncProductionTestLogUpload();break;
                    default:
                        break;
                }
            }
        }

        private void FuncProductionTestLogUpload()
        {

            var isSuccess = true;
            TestSequenceLog log = new TestSequenceLog()
            {
                TestItem = new List<TestSequenceTestItemLog>()

            };
            log.TestItem.Add(new TestSequenceTestItemLog()
            {
                Code = "CHECK_STATION",
                Description = "��վ��Ϣ���",
                Result = "Success"
            });

            TuyaFinishedSDK.ProductionTestLogUpload(isSuccess, "", log, out string message);
            MessageInfo = message;
        }

        private void FuncLoginButton()
        {
            IsLogin = TuyaFinishedSDK.Login(UserName, Password, out string message);
            Infomation = IsLogin ? $"�û�: {UserName} ��¼��" : $"δ��¼ �쳣��Ϣ:{message}";
        }

        private void FuncWorkOrderButton()
        {
            RestartTimer(WorkOrderInformationTimerCallback);
        }

        private void FuncProductTransitButton()
        {
            if (TuyaFinishedSDK.ProductPassThroughStation(ProductSN, out var orderInfo))
            {
                ProductModel = $"��Ʒ�ͺ�:{orderInfo.ProductModel} ��������:{orderInfo.TotalNum}";
                MessageInfo = $"��Ʒ�ͺ�:{orderInfo.ProductModel}\r\n��������:{orderInfo.TotalNum}\r\n��ǰ������������:{orderInfo.StationPassAmount}";
            }
            else
            {
                MessageInfo = orderInfo.ErrorMessage;
            }
        }

        private void RestartTimer(TimerCallback callback)
        {
            lock (_lock)
            {
                _timer?.Dispose(); 
                _timer = new Timer(callback, null, 500, Timeout.Infinite);
            }
        }
        private void WorkOrderInformationTimerCallback(object state)
        {
            lock (_lock)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    NodeList.Clear();
                    if (TuyaFinishedSDK.GetWorkOrderInformation(WorkOrder, out var orderInfo))
                    {
                        NodeList.AddIf(true, orderInfo.OrderNodeList);
                        ProductModel = $"��Ʒ�ͺ�:{orderInfo.ProductModel} ��������:{orderInfo.TotalNum} ";
                    }
                    else
                    {
                        ProductModel = "";
                        MessageInfo = orderInfo.ErrorMessage;
                    }
                });
            }
        }

        private void TestSequenceTimerCallback(object state)
        {
            lock (_lock)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    if (TuyaFinishedSDK.GetTestSequenceWithOrderNode(OrderNode, out var orderInfo))
                    {
                        ProductModel = $"��Ʒ�ͺ�:{orderInfo.ProductModel} ��������:{orderInfo.TotalNum}";
                        MessageInfo = $"��Ʒ�ͺ�:{orderInfo.ProductModel}\r\n��������:{orderInfo.TotalNum}\r\n��ǰ������������:{orderInfo.StationPassAmount}";
                    }
                    else
                    {
                        MessageInfo = orderInfo.ErrorMessage;
                    }
                });
            }
        }
    }
}