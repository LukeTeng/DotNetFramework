using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Framework.Model;

namespace Framework
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(FrameworkContext)).As(typeof(IContext)).InstancePerLifetimeScope();

        }
    }
}