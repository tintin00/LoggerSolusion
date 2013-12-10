using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mkFx.Framework
{
    public class mkAppContext
    {
        static mkAppContext _self = null; 
        static Microsoft.Practices.Unity.UnityContainer _container = null; 
        private mkAppContext() 
        { 
            // 공개적인 생성을 막는다. 
        } 
        public static mkAppContext Current 
        { 
            get 
            { 
                if (_self == null) 
                    _self = new mkAppContext(); 
                return _self; 
            } 
        } 
        public Microsoft.Practices.Unity.UnityContainer Container 
        { 
            get 
            { 
                return _container; 
            } 
            set 
            { 
                _container = value; 
            } 
        } 
    }
}
