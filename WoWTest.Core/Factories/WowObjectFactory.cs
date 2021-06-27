using System;
using Process.NET;
using WoWTest.Core.Models;

namespace WoWTest.Core.Factories
{
    public class WowObjectFactory : IWowObjectFactory
    {
        private readonly IProcess wowProcess;

        public WowObjectFactory(IProcess wowProcess)
        {
            this.wowProcess = wowProcess;
        }

        public T Create<T>(WowObject wowObject) where T : WowObject
        {
            if (typeof(T) == typeof(Npc))
            {
                return new Npc(this.wowProcess, wowObject.BaseAddress) as T;
            }
            else if (typeof(T) == typeof(Player))
            {
                return new Player(this.wowProcess, wowObject.BaseAddress) as T;
            }

            throw new NotImplementedException("Conversion not registered");
        }
    }
}
