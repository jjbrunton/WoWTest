using System.Collections.Generic;
using System.Linq;
using Process.NET;
using Process.NET.Memory;
using WoWTestConsole.Factories;
using WoWTestConsole.Models;

namespace WoWTestConsole
{
    public class GameService
    {
        private readonly IProcess wowProcess;
        private readonly IPointer basePointer;
        private readonly ObjectManager objectManager;
        private readonly IWowObjectFactory objectFactory;
        private UInt128 localGuid; 

        public GameService(IProcess wowProcess, IPointer basePointer, ObjectManager objectManager, IWowObjectFactory objectFactory)
        {
            this.wowProcess = wowProcess;
            this.basePointer = basePointer;
            this.objectManager = objectManager;
            this.objectFactory = objectFactory;
        }

        public Player Me { get; private set; }

        public IEnumerable<Npc> Npcs { get; private set; }

        public IEnumerable<Player> Players { get; private set; }

        public void Update()
        {
            this.localGuid = basePointer.Read<UInt128>((int)Offsets.Player.LocalGuid);

            this.Me = new Player(this.wowProcess, this.objectManager.FirstOrDefault(x => x.Guid == localGuid).BaseAddress);

            this.Npcs = this.objectManager.Where(x => x.Type == ObjectType.Unit)
                .Select(x => objectFactory.Create<Npc>(x));

            this.Players = this.objectManager.Where(x => x.Type == ObjectType.Unit)
                .Select(x => objectFactory.Create<Player>(x));
        }
    }
}
