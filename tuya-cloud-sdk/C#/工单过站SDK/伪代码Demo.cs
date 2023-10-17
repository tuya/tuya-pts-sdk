using Newtonsoft.Json;
using System.Collections.Generic;

using TuyaCloudIfLib;

namespace StationTestDemo
{
    class Demo
    {
        public Demo()
        {

            #region 1.用户登录，只需登陆一次
            UserLoginReqParas reqlogin = new UserLoginReqParas();
            reqlogin.username = "XXX";//PMS用户名，需自主输入
            reqlogin.password = "XXX";//PMS密码，需自主输入
            UserLoginRspParas rsplogin = TuyaCloudIf.UserLogin(reqlogin);
            if (rsplogin.success == false)//登录成功才能操作
            {
                //提示账号异常
                return;
            }
            #endregion

            #region 2.选取工艺路线，单个站位只需一次
            GetCraftLineReq getCraftLineReq = new GetCraftLineReq();
            getCraftLineReq.orderCode = "XXX"; //工单号，需自主输入
            GetCraftLineRsp getCraftLineRsp = TuyaCloudIf.GetCraftLine(getCraftLineReq);
            List<Node> stationList = getCraftLineRsp.result.nodeList;  //获取到站位信息列表
            Node tempStation = stationList[0];  //选择出对应的站位列表并获取到其中的,举例子选第二个站位
            #endregion

            #region 3.站位信息重置，获取requestId
            StationResetReq stationResetReq = new StationResetReq();
            stationResetReq.sn = "XXX";//待测试设备SN，需自主输入
            stationResetReq.stationCode = tempStation.code;
            stationResetReq.orderCode = "XXX";//工单号，需自主输入
            StationResetRsp stationResetRsp = TuyaCloudIf.StationReset(stationResetReq);
            #endregion

            #region 4.过站信息上报
            StationStatusCommitReq stationReq = new StationStatusCommitReq();
            stationReq.orderCode = "XXX";//工单号，需自主输入
            stationReq.sn = "XXX";  //待测试设备SN，需自主输入
            stationReq.stationCode = tempStation.code;
            stationReq.requestId = stationResetRsp.result.requestId;
            stationReq.status = 1;   //数字1,0表示结果；1为产测成功， 0为产测失败；

            TuyaCloudIfLib.StationStatusCommitRsp stationRsp = TuyaCloudIf.StationStatusCommit(stationReq);
            if (stationRsp.success)
            {
                //过站检测通过
            }
            #endregion
        }

    }
}



