using App.Presentations.ViewModels;
using App.Presentations.Views.Control;

namespace App.Presentations.Views;

public partial class SimulationView : ContentPage
{
	public SimulationView(SimulationViewModel simulationViewModel)
	{
		InitializeComponent();

        BindingContext = simulationViewModel;

        simulationViewModel.CustomView = customView;
    }
}