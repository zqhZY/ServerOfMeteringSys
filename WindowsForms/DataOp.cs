using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Datawraper
{
    public class DataOp
    {
        private string Server;
        private  string DataSource;
        private string UserId;
        private string PassWord;
        private OleDbConnection Conn;
        private  bool ifConnect;

        /***    
          *     1、函数功能：数据库连接构造方法，连接目标数据库
          *      2、method_name:DataOp
          *      3、参数：数据库服务器主机地址，数据源，登陆用户名，用户密码
          *      4、创建数据库连接句柄
        * */
        public DataOp(string server, string port, string datasource, string userid, string password)
        {
            this.Server = server;
            this.DataSource = "(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = " + server + ")(PORT = " + port + ")))(CONNECT_DATA =(SERVICE_NAME = " + datasource + ")))";
            this.UserId = userid;
            this.PassWord = password;

            try
            {
                this.Conn = new OleDbConnection("Provider=OraOLEDB.Oracle.1;Server=" + server + "; data source=" + this.DataSource + ";User ID=" + userid + ";Password=" + password + ";");
                //this.Conn = new OleDbConnection("Provider=OraOLEDB.Oracle.1;Server=localhost; Data  Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = orcl))); User ID=Admin;Password=zqh321;");
                this.Conn.Open();
                this.ifConnect = true;
            }
            catch (Exception ex)
            {
                this.ifConnect = false;
                Console.WriteLine("数据库连接异常：" + ex.Message);
            }

        }

        public DataOp(string server, string datasource, string userid, string password)
        {
            this.Server = server;
            this.DataSource = "(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = " + server + ")(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = " + datasource + ")))";
            this.UserId = userid;
            this.PassWord = password;

            try
            {
                this.Conn = new OleDbConnection("Provider=OraOLEDB.Oracle.1;Server=" + server + "; data source=" + this.DataSource + ";User ID=" + userid + ";Password=" + password + ";");
                this.Conn.Open();
                this.ifConnect = true;
            }
            catch (Exception ex)
            {
                this.ifConnect = false;
                Console.WriteLine("数据库连接异常：" + ex.Message);
            }

        }


        public bool Close()
        { 
            bool flag = true;

            try
            {
                this.Conn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("数据库CLOSE异常：" + ex.Message);
                flag = false;
            }


            return flag; 

        
        }

        public bool IfConnect {

            get { 
            
                return ifConnect;
            }
            
            set {

                ifConnect = value;
            }
        }

        /***    
        *     1、函数功能：查询记录一项，根据表中某一属性
       *      2、method_name:GetOneStrTypeByName
       *      3、参数：希望得到的字段名，表名，定位属性名，属性值
       *      4、返回OleDbDataReader类型结果
       * */
        public string GetOneStrTypeByName(string data_to_get, string tablename, string chara_name, string name)
        {

            string result = null;
            OleDbCommand selectcom = new OleDbCommand("select " + data_to_get + "  from " + tablename + " where " + chara_name + "= '" + name + "'", this.Conn);
            //select password from user_t where user_name = 'zqh'
            //OleDbCommand selectcom = new OleDbCommand("select password from user_t where user_name = 'zqh'", this.Conn);
            try
            {

                OleDbDataReader data = selectcom.ExecuteReader();
                while (data.Read())
                {

                    result = data[0].ToString();
                }

            }
            catch (Exception ex)
            {

                //待定
                Console.WriteLine("GetOneStrTypeByName函数异常：" + ex.Message);
                //conn.Close();  
            }
            selectcom.Dispose();

            return result;

        }

        /***    1、功能：通过属性名查询该行所有字段
         *      2、method_name:GetRowByName
         *      3、参数：表名，定位属性名，属性值
         *      4、返回OleDbDataReader类型结果
         * */
        public OleDbDataReader GetRowByIndex(string tablemame, string chara_name, string index)
        {
            OleDbDataReader data = null;
            OleDbCommand selectcom = new OleDbCommand("select * from " + tablemame + " where " + chara_name + "= '" + index + "'", this.Conn);

            try
            {
                data = selectcom.ExecuteReader();
            }

            catch (Exception ex)
            {

                Console.WriteLine("GetRowByName函数异常：" + ex.Message);
                //this.Conn.Close();

            }

            selectcom.Dispose();
            return data;

        }


        /**
         * 
         * 根据sql语句查询，用于多项条件查询
         * 
         * 
         * */
        public OleDbDataReader GetRowsBySql(string sql)
        {
            OleDbDataReader data = null;
            OleDbCommand selectcom = new OleDbCommand(sql, this.Conn);

            try
            {
                data = selectcom.ExecuteReader();
            }

            catch (Exception ex)
            {

                Console.WriteLine("GetRowByName函数异常：" + ex.Message);
                //this.Conn.Close();

            }

            selectcom.Dispose();
            return data;
 
        
        }


        /**
         *    1、功能：根据表名查询所有记录
         *    2、data中返回查询到的所有信息。
         * 
         * 
         * 
         * 
         * 
         * */

        public OleDbDataReader GetAllRowByTable(string tablename)
        {
            OleDbDataReader data = null;
            OleDbCommand selectcom = new OleDbCommand("select * from " + tablename , this.Conn);


            
            
            try
            {
                data = selectcom.ExecuteReader();
                //while (data.Read()) {

                    //Dictionary<String, String> dataListHash = new Dictionary<string,string>();

                
                //}

            }
            catch(Exception ex)
            {

                Console.WriteLine("GetAllRowByTable函数异常：" + ex.Message);
                
            }
            selectcom.Dispose();//释放资源，否则多次使用会异常，oracle默认同时300个
            return data;
            
        }




        //查询两个字段，返回对应字符串数组
        public string[] GetTwoStrType(string first, string second, string tablename, string id)
        {

            string[] strs = new String[2];
            OleDbCommand selectcom = new OleDbCommand("select " + first + " , " + second + " from " + tablename + " where ename = '" + id + "'", this.Conn);

            try
            {
                OleDbDataReader data = selectcom.ExecuteReader();
                while (data.Read())
                {

                    strs[0] = data[0].ToString();
                    strs[1] = data[1].ToString();
                }
            }

            catch (Exception ex)
            {

                Console.WriteLine("GetTwoStrType函数异常：" + ex.Message);
                //this.Conn.Close();

            }
            selectcom.Dispose();
            return strs;
        }

        /*
         * 
         * 
         *  插入一行，tablename表名，values 待插入记录值
         * 
         * 
         * */
        public int InsertOneRow(string tablename, string values)
        {

            int rownum = 0;
            OleDbCommand insertcom = new OleDbCommand("insert into " + tablename + " values(" + values + ")", this.Conn);
            try
            {
                rownum = insertcom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("InsertOneRow函数异常：" + ex.Message);
            }

            insertcom.Dispose();
            return rownum;
        }




        //删除记录根据记录名，待修改
        public int DeleteOneRow(string tablename, string name)
        {

            int rownum = 0;
            OleDbCommand deletecom = new OleDbCommand("delete from " + tablename + " where ename= '" + name + "'", this.Conn);
            try
            {
                rownum = deletecom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("DeleteOneRow函数异常：" + ex.Message);
            }

            deletecom.Dispose();

            return rownum;
        }


        /**
         * 
         * 根据列名更新记录 ， 待修改（根据主键）
         * 
         * 
         * 
         * */
        //
        public int UpdateOneRow(string tablename, string newvaluelist, string colume, string name)
        {

            int rownum = 0;
            OleDbCommand updatecom = new OleDbCommand("update " + tablename + " " + newvaluelist + " where " + colume + " = '" + name + "'", this.Conn);
            try
            {

                rownum = updatecom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine("UpdateOneRow函数异常：" + ex.Message);
            }

            updatecom.Dispose();
            return rownum;
        }


        /**
         * 
         * 获取数据表最大id，由于不采用自增id，插入时需调用
         * 
         * 
         * 
         * 
         * */

        public int GetMaxId(string tablename, string colume)
        {
            int maxId = 0;

            string comm = " select max(" + colume + ") from " + tablename;
            OleDbCommand selectcom = new OleDbCommand(comm, this.Conn);


            try
            {
                OleDbDataReader data = selectcom.ExecuteReader();
                while (data.Read())
                {

                    maxId = int.Parse(data[0].ToString());
                }
            }

            catch (Exception ex)
            {

                Console.WriteLine("GetTwoStrType函数异常：" + ex.Message);
                //this.Conn.Close();

            }

            selectcom.Dispose();
            return maxId;
        
        }

    }
}


