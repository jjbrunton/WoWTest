using Autofac;
using Process.NET;
using Process.NET.Memory;
using WoWTest.Core.Factories;

namespace WoWTest.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(_ => new ProcessSharp(Constants.ProcessName, MemoryType.Remote)).As<IProcess>().SingleInstance();

            builder.Register(x =>
            {
                var wowProcess = new ProcessSharp(Constants.ProcessName, MemoryType.Remote);
                return wowProcess[wowProcess.ModuleFactory.MainModule.BaseAddress];
            }).As<IPointer>().SingleInstance();

            builder.RegisterType<ObjectManager>().SingleInstance();
            builder.RegisterType<GameService>();
            builder.RegisterType<WowObjectFactory>().As<IWowObjectFactory>();
        }
    }
}
