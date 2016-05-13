using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    /**
     * 电表信息模型
     * 
     * 
     * */
    class Collection_t
    {
        private string node_id;
        private string node_name;
        private string room_id;
        private string foor_id;
        private string building_id;
        private string gateway_id;
        private string state;
        private string Switch;
        private string describle;
        private string node_num;

      

        /***
         * 额外信息
         * 
         * 
         * */
        private string address;
        private string port;
        private string active_net;

       



        public Collection_t(string node_id, string node_name, string room_id, string foor_id,
           string building_id, string gateway_id, string state, string Switch, string describle, string node_num)
        {

            this.node_id = node_id;
            this.node_name = node_name;
            this.room_id = room_id;
            this.foor_id = foor_id;
            this.building_id = building_id;
            this.gateway_id = gateway_id;
            this.state = state;
            this.Switch = Switch;
            this.describle = describle;
            this.node_num = node_num;
        
        }


        
        /**
         * 额外信息的get、set方法
         * 
         * 
         * */
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        public string Active_net
        {
            get { return active_net; }
            set { active_net = value; }
        }



        /**
         * get and set methods
         * 
         * 
         * */

        public string Node_id
        {
            get { return node_id; }
            set { node_id = value; }
        }

        

        public string Node_name
        {
            get { return node_name; }
            set { node_name = value; }
        }

        

        public string Room_id
        {
            get { return room_id; }
            set { room_id = value; }
        }

        

        public string Foor_id1
        {
            get { return foor_id; }
            set { foor_id = value; }
        }

        public string Foor_id
        {
            get { return foor_id; }
            set { foor_id = value; }
        }

        

        public string Building_id
        {
            get { return building_id; }
            set { building_id = value; }
        }

        

        public string Gateway_id
        {
            get { return gateway_id; }
            set { gateway_id = value; }
        }

        

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        

        public string Switch1
        {
            get { return Switch; }
            set { Switch = value; }
        }

        

        public string Describle
        {
            get { return describle; }
            set { describle = value; }
        }


        public string Node_num
        {
            get { return node_num; }
            set { node_num = value; }
        }
    }

}
