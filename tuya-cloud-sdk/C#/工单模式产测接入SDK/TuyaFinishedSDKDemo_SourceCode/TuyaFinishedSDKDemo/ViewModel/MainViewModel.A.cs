using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using TuyaFinished_SDK.Model;
using static TuyaCloudIfLib.GetCraftLineRsp.CraftLineNodes;

namespace TuyaFinishedSDKDemo.ViewModel
{
    public partial class MainViewModel
    {
        private Timer _timer;
        private readonly object _lock = new object();


        private string _Infomation = string.Empty;
        public string Infomation
        {
            get => _Infomation;
            set => Set(ref _Infomation, value);
        }

        private bool _bIsLogin = false;
        public bool IsLogin
        {
            get => _bIsLogin;
            set => Set(ref _bIsLogin, value);
        }

        private string _UserName = "aden-65am";
        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }

        private string _Password = "";
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }


        private string _WorkOrder = string.Empty;
        public string WorkOrder
        {
            get => _WorkOrder;
            set
            {
                if (Set(ref _WorkOrder, value))
                {
                    RestartTimer(WorkOrderInformationTimerCallback);
                };
            }
        }


        private string _MessageInfo = string.Empty;
        public string MessageInfo
        {
            get => _MessageInfo;
            set => Set(ref _MessageInfo, value);
        }

        private string _ProductModel = string.Empty;
        public string ProductModel
        {
            get => _ProductModel;
            set => Set(ref _ProductModel, value);
        }


        private string _ProductSN = string.Empty;
        public string ProductSN
        {
            get => _ProductSN;
            set => Set(ref _ProductSN, value);
        }


        private OrderNode _OrderNode = new OrderNode();
        public OrderNode OrderNode
        {
            get => _OrderNode;
            set
            {
                if (Set(ref _OrderNode, value) && value.IsNotNull())
                {
                    RestartTimer(TestSequenceTimerCallback);
                }
            }
        }

        private ObservableCollection<OrderNode> _NodeList =new ObservableCollection<OrderNode>();
        public ObservableCollection<OrderNode> NodeList
        {
            get => _NodeList;
            set => Set(ref _NodeList, value);
        }

        private RelayCommand<object> _TuyaButtonCommand;
        /// <summary>
        /// TuyaButton Command.
        /// </summary>
        public RelayCommand<object> TuyaButtonCommand
        {
            get
            {
                if (_TuyaButtonCommand == null) _TuyaButtonCommand = new RelayCommand<object>((x) => ExecuteTuyaButtonCommand(x), CanExecuteTuyaButtonCommand());
                return _TuyaButtonCommand;
            }
        }
        private bool CanExecuteTuyaButtonCommand() { return true; }
    }
}
