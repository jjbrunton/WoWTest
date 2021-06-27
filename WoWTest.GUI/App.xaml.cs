using System;
using System.Windows;
using Autofac;
using WoWTest.Core;

namespace WoWTest.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Container = this.BuildContainer();

            var gameService = Container.Resolve<GameService>();
            gameService.Me.Subscribe(x => Console.WriteLine($"My health: {x.CurrentHealth}"));

            Current.MainWindow = Container.Resolve<MainWindow>();
            Current.MainWindow.Show();
        }

        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AppModule());
            builder.RegisterModule(new CoreModule());
            return builder.Build();
        }
    }
}
