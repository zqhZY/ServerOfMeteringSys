using System;

namespace MsgClass
{

    //服务器接受命令标识集
    public enum MsgCommand
    {
        NONE,
        CONNECT = 1,
        LOGIN = 3,//用户登录

        HEART_BEAT_RES = 6,//心跳响应

        UPDATE_NODE_NUM = 7,//电表注册

        COLLECTER_INFO_RES = 10,//电表信息查询的返回数据包
        

    }

    //服务器发送命令集
    public class Conmmend{

        public static string CONNECTION_RES = "<c>02</c><info></info>";//链接响应

        public static string LOGIN_MSG_RES = "<c>04</c><info></info>";//登录响应


        public static string HEART_BEAT = "<c>05</c><info></info>";//网关心跳


        public static string UPDATE_NODE_NUM_RES = "<c>08</c><info></info>";//电表注册响应

        public static string GET_ALL_COLLECTER_INFO = "<c>09</c><info>All</info>"; //查询所有电表采集的信息  


    }
   

}
