﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using mkFx.Framework;
using Site.Framework;
using Site.Job01;
using Microsoft.Practices.Unity;

namespace FSLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 편의상 이전 로그 파일이 존재하면 삭제한다. 로그가 누적되면 테스트가 방해되잖아. 
            if (System.IO.File.Exists(@"C:\FSLogger.log"))
                System.IO.File.Delete(@"C:\FSLogger.log");
            
            UnityContainer container = new UnityContainer();

            //mkAppContext에 현재 컨테이너 참조 저장 
            mkAppContext.Current.Container = container;

            //UserInfo 매핑 정보를 등록한다. sigleton 패턴 사용 
            //container.RegisterType<UserInfo, SiteUserInfo>(new ContainerControlledLifetimeManager());

            //주목 1 : ILogger와 FSLogger의 매핑 정보를 등록한다. 
            container.RegisterType<ILogger, FSLogger>(new ContainerControlledLifetimeManager());

            SiteUserInfo userinfo = new SiteUserInfo("mkkim2");
            container.RegisterInstance<UserInfo>(userinfo, new ContainerControlledLifetimeManager());



            //주목 2 : 아래 주석을 해제할때를 일러주겠다. 
            //container.RegisterType< Biz01>(new ContainerControlledLifetimeManager()); 
            //Biz01 객체를 생성한다. 
            Biz01 biz1 = container.Resolve<Biz01>();
            //Biz01 biz2 = container.Resolve<Biz01>();

            // 주목 3 
            //Biz01 biz1 = new Biz01(); 
            //Biz01 biz2 = new Biz01();

            biz1.Save();
            //biz2.Save();

            //로그 파일의 내용을 콘솔에 출력한다. 
            Console.WriteLine(System.IO.File.ReadAllText(@"C:\FSLogger.log"));
            Console.Read();

        } 
    }
}
