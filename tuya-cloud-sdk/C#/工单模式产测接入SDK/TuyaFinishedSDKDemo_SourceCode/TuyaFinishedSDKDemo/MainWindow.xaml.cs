using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TuyaFinishedSDKDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var tmp = TuyaFinishedSDK.Login("05367", "poppy2021", out string message);
            //tmp = TuyaFinishedSDK.GetWorkOrderInformation("TPEM20UUW", out var data);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LoginSimplePanel.Width = this.ActualWidth * 0.5;
            LoginSimplePanel.Height = this.ActualHeight * 0.5;

            ProductTransitSimplePanel.Width = this.ActualWidth * 0.5;
            ProductTransitSimplePanel.Height = this.ActualHeight * 0.5;
        }

        private void WorkOrderTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Text == "v")
            {
                // 获取剪贴板中的文本
                string clipboardText = Clipboard.GetText();

                // 将剪贴板中的文本粘贴到 TextBox 中
                WorkOrderTextBox.SelectedText = clipboardText;

                // 阻止 TextBox 实际接收到 "v" 字符
                e.Handled = true;
            }
        }

        private void WorkOrderTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
      
        }
    }
}
