using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using WoWTest.GUI.ViewModels;

namespace WoWTest.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainWindowViewModel>
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.ViewModel = viewModel;

            // Setup the bindings
            // Note: We have to use WhenActivated here, since we need to dispose the
            // bindings on XAML-based platforms, or else the bindings leak memory.
            this.WhenActivated(disposable =>
            {
                this.OneWayBind(this.ViewModel, x => x.NpcList, x => x.NpcList.ItemsSource)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.Player.Guid, x => x.PlayerGUID.Text)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.Player.CurrentHealth, x => x.PlayerHealth.Text)
                    .DisposeWith(disposable);
                this.OneWayBind(this.ViewModel, x => x.Player.Position, x => x.PlayerPosition.Text)
                    .DisposeWith(disposable);
            });
        }

        public MainWindowViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainWindowViewModel)value;
        }
    }
}
