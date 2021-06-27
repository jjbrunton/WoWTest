using System;
using Autofac;

namespace WoWTestConsole
{
    class Program
    {

        public static IContainer Container { get; private set; }

        static void Main(string[] args)
        {
            Container = BuildContainer();

            var objectManager = Container.Resolve<ObjectManager>();
            var objects = objectManager;
            foreach (var obj in objects)
            {
                Console.WriteLine($"Guid: {obj.Guid}");
            }

            Console.ReadLine();
        }

        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BaseModule());
            return builder.Build();
        }
    }
}