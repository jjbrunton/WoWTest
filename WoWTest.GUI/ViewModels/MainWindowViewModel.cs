using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using WoWTest.Core;
using WoWTest.Core.Models;

namespace WoWTest.GUI.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly GameService gameState;

        public MainWindowViewModel(GameService gameState)
        {
            this.gameState = gameState;

            gameState.Me.ObserveOn(RxApp.MainThreadScheduler).Select(x => x)
                .ToPropertyEx(this, x => x.Player);

            gameState.NpcList.ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.NpcList);
        }

        [ObservableAsProperty]
        public IEnumerable<Npc> NpcList { get; }

        [ObservableAsProperty]
        public Player Player { get; }
    }
}