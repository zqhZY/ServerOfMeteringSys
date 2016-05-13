using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace InfoGetter
{
    /**
     * 类名：infoGetter
     * 功能：分析接收到的数据，提取命令内容
     * */
    class infoGetter
    {
        //private string str_to_match;
        private string pattern;
        //private string result;

        public string getHead(string msg)
        {
            //msg:<head>1</head><data>131</data>
            pattern = @"<c>(?<c>[0-9]+)</c>";
            return Regex.Match(msg, pattern).Groups["c"].Value;
        }

        public string getData(string msg)
        {
            //msg:<head>1</head><data>131|111|333</data>
            pattern = @"<info>(?<info>.+)</info>";
            return Regex.Match(msg, pattern).Groups["info"].Value;
        }


        public string[] getInfo(string msg)
        {
            //infos:131|111|333
            string infos = this.getData(msg);
            string[] infoList = infos.Split('|');
            return infoList;
        }
    }
}
