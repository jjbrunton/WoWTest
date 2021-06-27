using System.Reflection;
using Autofac;
using WoWTest.Core;
using WoWTest.GUI.ViewModels;

namespace WoWTest.GUI
{
    public class AppModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterModule(new CoreModule());
            builder.RegisterType<MainWindow>();
            builder.RegisterType<MainWindowViewModel>();
        }
    }
}
