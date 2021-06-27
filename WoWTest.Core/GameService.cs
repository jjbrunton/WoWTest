using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Process.NET;
using Process.NET.Memory;
using WoWTest.Core.Factories;
using WoWTest.Core.Models;

namespace WoWTest.Core
{
    public class GameService
    {
        private readonly IProcess wowProcess;
        private readonly IPointer basePointer;
        private readonly ObjectManager objectManager;
        private readonly IWowObjectFactory objectFactory;
        private UInt128 localGuid;
        private Player localPlayer;
        private IEnumerable<Npc> npcs;
        private IEnumerable<Player> players;

        public GameService(IProcess wowProcess, IPointer basePointer, ObjectManager objectManager, IWowObjectFactory objectFactory)
        {
            this.wowProcess = wowProcess;
            this.basePointer = basePointer;
            this.objectManager = objectManager;
            this.objectFactory = objectFactory;
        }

        public IObservable<Player> Me => this.Update.Select(_ => this.localPlayer);

        public IObservable<IEnumerable<Npc>> NpcList => this.Update.Select(_ => this.npcs);

        public IObservable<IEnumerable<Player>> Players => this.Update.Select(_ => this.players);

        private IObservable<Unit> Update => Observable.Create<Unit>(
            observer =>
            {
                var timer = new System.Timers.Timer();
                timer.Enabled = true;
                timer.Interval = Constants.GamePollIntervalMs;
                timer.Elapsed += (s, e) => UpdateState();
                timer.Elapsed += (s, e) => observer.OnNext(Unit.Default);
                timer.Start();
                return () => {
                    timer.Dispose();
                };
            });

        private void UpdateState()
        {
            this.localGuid = basePointer.Read<UInt128>((int)Offsets.Player.LocalGuid);

            this.localPlayer = new Player(this.wowProcess, this.objectManager.FirstOrDefault(x => x.Guid == localGuid).BaseAddress);

            this.npcs = this.objectManager.Where(x => x.Type == ObjectType.Unit)
                .Select(x => objectFactory.Create<Npc>(x));

            this.players = this.objectManager.Where(x => x.Type == ObjectType.Unit)
                .Select(x => objectFactory.Create<Player>(x));
        }
    }
}
