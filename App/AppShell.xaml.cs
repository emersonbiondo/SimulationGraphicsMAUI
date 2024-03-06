using App.Presentations.Views;

namespace App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SimulationView), typeof(SimulationView));
        }
    }
}
