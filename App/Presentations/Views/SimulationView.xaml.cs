using App.Presentations.ViewModels;

namespace App.Presentations.Views;

public partial class SimulationView : ContentPage
{
	public SimulationView(SimulationViewModel simulationViewModel)
	{
		InitializeComponent();

        BindingContext = simulationViewModel;
    }
}