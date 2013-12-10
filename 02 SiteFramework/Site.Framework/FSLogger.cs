using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using mkFx.Framework;
using Microsoft.Practices.Unity;

namespace Site.Framework
{
    public class FSLogger : ILogger
    {
        public FSLogger()
        {

            System.IO.File.AppendAllText(@"C:\FSLogger.log", "FSLogger 생성자 호출" + Environment.NewLine);
        }

        public void Write(string message)
        {
            // System.IO.File.AppendAllText(@"C:\FSLogger.log", message + Environment.NewLine);

            SiteUserInfo userinfo = (SiteUserInfo)mkAppContext.Current.Container.Resolve<UserInfo>();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ID:{0}, 이름:{1}, 부서:{2}, 메세지:{3}", userinfo.ID, userinfo.Name, userinfo.DeptCode, message);
            //sb.Append(message); 
            System.IO.File.AppendAllText(@"C:\FSLogger.log", sb.ToString() + Environment.NewLine); 
        }
    } 
}
