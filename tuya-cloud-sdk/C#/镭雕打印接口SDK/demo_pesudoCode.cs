using Newtonsoft.Json;
using System.Collections.Generic;

using TuyaCloudIfLib;

namespace LDTY
{
    class Demo
    {
        public Demo()
        {

            UserLoginReqParas reqlogin = new UserLoginReqParas();
            reqlogin.username = "";//PMS用户名
            reqlogin.password = "";//PMS密码
            UserLoginRspParas rsplogin = TuyaCloudIf.UserLogin(reqlogin);
            if (rsplogin.success == false)//登录成功才能操作
            {
                return;
            }
            #region dongle无线打印获取数据流程
            //界面选择对应的dongle串口号
            //如果是zigbeee dongle串口波特率选择460800，其他类型选择9600
            //开启串口通讯
            //以下dongle串口通讯 请参考【不同类型dongle串口协议】文档
            //if (dongle类型为zigbee类型/Zigbee Dongle对接-Thread)
            //{
            //    //发送进入产测指令 (0x00) 
            //    //进入产测成功后，发送读取mac指令 
            //    //获取mac成功后作为“界面入参”走以下流程
            //}
            //else if (dongle类型为wifi类型)
            //{
            //   //发送查询dongle信息【子命令0XFF06】来获取dongle固件版本号
            //   //发送wifi dongle设备信息同步【子命令0x003E】 max_sync_time 设置为 -1那么dongle在收到设备同步信
            //   //息后会直接上报 ==>获取设备的 uuid
            //   //将uuid“界面入参”走以下流程
            //}
            //else if (dongle类型为蓝牙类型)
            //{
            //   //发送查询dongle信息【子命令0x001C】来获取dongle固件版本号
            //   //发送蓝牙 dongle设备信息同步【子命令0x001F】 max_sync_time 设置为 -1那么dongle在收到设备同步信
            //   //息后会直接上报 ==>获取设备的 uuid
            //   //将uuid“界面入参”走以下流程
            //}



            #endregion

            #region  界面数据作为入参，通过云端接口反查其他相关数据
            List<LabelPrintInfoFeaturesModel> labelPrintInfoFeaturesModels = new List<LabelPrintInfoFeaturesModel>();
            //根据需要参数的类型 加入对应的code到列表中
            labelPrintInfoFeaturesModels.Add(new LabelPrintInfoFeaturesModel()
            {
                code = LabelPrintInfoFeatureCode.matter.ToString()
            });
            //
            LabelPrintInfoReq labelPrintInfoReq = new LabelPrintInfoReq();
            labelPrintInfoReq.value = "10010414700042"; //界面入参数据
            labelPrintInfoReq.features = JsonConvert.SerializeObject(labelPrintInfoFeaturesModels);
            labelPrintInfoReq.type = "auth_sn";//和以下类型 bind_sn 、  mac 、uuid、imei、matter_qr_code

            LabelPrintInfoRsp _LabelPrintInfoRspsn = TuyaCloudIf.GetLabelPrintInfo(labelPrintInfoReq);
            string resultSN = _LabelPrintInfoRspsn.result.sn;//_LabelPrintInfoRspsn.result中云端也会返回其他参数
                                                             //比如uuid  matterQrCode  matterManualCode

            #endregion



            #region  云端数据校验  uuid不可以为空
            if (string.IsNullOrEmpty(_LabelPrintInfoRspsn.result.uuid))
            {
                TuyaCloudIf.ValidateData(_LabelPrintInfoRspsn.result.pid, _LabelPrintInfoRspsn.result.uuid);
            }
            #endregion



            //根据_LabelPrintInfoRspsn对象云端返回数据 打印对应的信息
        }

    }
}
