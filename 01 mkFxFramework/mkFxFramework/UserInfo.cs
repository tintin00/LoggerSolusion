using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mkFx.Framework
{
    public class UserInfo
    {
        private string _id = "";
        private string _name = "";

        public UserInfo(string id)
        {
            _id = id;

            // id를 통해서 이름을 DB에서 조회해온다.  
            _name = "민국이";
        }

        public virtual string ID
        {
            get
            {
                return _id;
            }
        }
        public virtual string Name
        {
            get
            {
                return _name;
            }
        }
    } 
}
