using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TuyaCloudIfLib;

namespace ZigbeeAuthDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            string userName = textBox_username.Text;
            string password = textBox_password.Text;
            string tokenId = textBox_token.Text;
            string mac = textBox_mac.Text;
            string sn = textBox_sn.Text;

            UserLoginReqParas loginReq = new UserLoginReqParas();
            loginReq.username = userName;
            loginReq.password = password;
            UserLoginRspParas loginRsp = TuyaCloudIf.UserLogin(loginReq);
            if (!loginRsp.success)
            {
                textBox_info.Text = loginRsp.errorMsg;
                return;
            }

            GetTokenInfoReqParas getTokenInfoReq = new GetTokenInfoReqParas();
            getTokenInfoReq.tokenId = tokenId;
            GetTokenInfoRspParas getTokenInfoRsp = TuyaCloudIf.GetTokenInfo(getTokenInfoReq);
            if(!getTokenInfoRsp.success)
            {
                textBox_info.Text = getTokenInfoRsp.errorMsg;
                return;
            }
            if(getTokenInfoRsp.result.type!="zigbee")
            {
                textBox_info.Text = "\r\nToken type error! token type ="+ getTokenInfoRsp.result.type;
                return;
            }
            else
            {
                textBox_info.Text += "\r\nPID=" + getTokenInfoRsp.result.productId;
            }

            var req = new GetModuleSignReqParas
            {
                mac = mac,
                tokenId = tokenId,
                firmwareName = "tuya_zigbee"//20190409会议讨论决定固件名称用常量替代
            };
            var rsp = TuyaCloudIf.GetModuleSign(req);
            if (rsp.success == false)
            {
                textBox_info.Text  += rsp.errorMsg;
                return ;
            }
            else
            {
                textBox_info.Text += "\r\nsign=" + rsp.result.sign;
            }

            //云端授权
            var authReq = new TokenAuthReq()
            {
                tokenId = tokenId,
                sn = sn,
                mac = mac,
                muid = "",
                chipId = "",
                sftVersion = TuyaCloudIf.SftVersion
            };
            var authRsp = TuyaCloudIf.TokenAuth(authReq);
            if (authRsp.success == false)
            {
                textBox_info.Text += $"\r\n云端授权失败:{authRsp.errorMsg}";
                return ;
            }
            else
            {
                textBox_info.Text += $"\r\nuuid=" + authRsp.result.uuid;
                textBox_info.Text += $"\r\naccessKey=" + authRsp.result.accessKey;
            }

            //云端授权验证
            var validateReq = new TokenAuthValidateReq()
            {
                tokenId = tokenId ?? "",
                sn = sn ?? "",
                uuid = authRsp.result.uuid ?? "",
                mac = mac ?? "",
                accessKey = authRsp.result.accessKey ?? "",
                sftVersion = TuyaCloudIf.SftVersion ?? "",
                muid = "",
                wifiPassword = "",
                wifiHotspotName = "",
                chipId = ""
            };
            var validateRsp = TuyaCloudIf.TokenAuthValidate(validateReq);
            if (validateRsp.success == false || validateRsp.result.result == false)
            {
                textBox_info.Text += $"\r\n云端授权验证调用失败:error:{validateRsp.errorMsg};depict:{validateRsp.result.failureDepict}";
                return ;
            }
        }

    }
}
