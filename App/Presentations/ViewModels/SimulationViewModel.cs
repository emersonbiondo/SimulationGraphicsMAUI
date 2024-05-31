using App.Presentations.Models;
using App.Presentations.Views.Control;
using App.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace App.Presentations.ViewModels
{
    public partial class SimulationViewModel: ObservableObject
    {
        public static IAlertService AlertService;

        public Simulation Simulation { get; set; }

        public AbsoluteLayout CustomView { get; set; }

        public GraphicsView GraphicsView { get; set; }        

        public string InitialPriceString
        {
            get
            {
                return Simulation.InitialPrice.ReturnDoubleToStringWithEmpty();
            }
            set
            {
                Simulation.InitialPrice = value.ReturnValidNumber();
                OnPropertyChanged("InitialPriceString");
            }
        }

        public string SigmaString
        {
            get
            {
                return Simulation.Sigma.ReturnDoubleToStringWithEmpty();
            }
            set
            {
                Simulation.Sigma = value.ReturnValidNumber();
                OnPropertyChanged("SigmaString");
            }
        }

        public string MeanString
        {
            get
            {
                return Simulation.Mean.ReturnDoubleToStringWithEmpty();
            }
            set
            {
                Simulation.Mean = value.ReturnValidNumber();
                OnPropertyChanged("MeanString");
            }
        }

        public string NumDaysString
        {
            get
            {
                return Simulation.NumDays.ReturnIntToStringWithEmpty();
            }
            set
            {
                Simulation.NumDays = value.ReturnValidNumber();
                OnPropertyChanged("NumDaysString");
            }
        }

        private float scaleValue = 1;

        public float ScaleValue
        {
            get
            {
                return scaleValue;
            }
            set
            {
                SetProperty(ref scaleValue, value);
                if (CustomView != null)
                {
                    CustomView.Scale = value;
                }
            }
        }

        public int NumSimulations
        {
            get
            {
                return Simulation.NumSimulations;
            }
            set
            {
                Simulation.NumSimulations = value;
                OnPropertyChanged("NumSimulations");
            }
        }

        public bool IsInitialPriceValid { get; set; }

        public bool IsSigmaValid { get; set; }

        public bool IsMeanValid { get; set; }

        public bool IsNumDaysValid { get; set; }

        public bool BuildEnabled { get; set; }

        public SimulationViewModel(IAlertService alertService)
        {
            AlertService = alertService;
            Simulation = new Simulation(); 
            BuildEnabled = true;
        }

        [RelayCommand]
        public async Task Build()
        {
            BuildEnabled = false;

            if (Validate())
            {
                ScaleValue = 1;
                for (int i = 1; i <= Simulation.NumSimulations; i++)
                {
                    GraphicsView = new GraphicsView();
                    GraphicsView.Drawable = new BrownianMotionDrawing(Simulation.GenerateBrownianMotion(), Simulation.StrokeSizeValue, Simulation.Color);
                    AbsoluteLayout.SetLayoutBounds(GraphicsView, new Rect(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(GraphicsView, AbsoluteLayoutFlags.All);
                    CustomView.Add(GraphicsView);
                    await Task.Delay(200);
                }
            }

            BuildEnabled = true;
        }

        [RelayCommand]
        public async Task Clear()
        {
            CustomView.Clear();
        }

        public bool Validate()
        {
            var errors = new List<string>();

            if (!IsInitialPriceValid)
            {
                errors.Add("Starting Price must be a valid number greater than '0'");
            }

            if (!IsSigmaValid)
            {
                errors.Add("Average Volatility (%) must be a valid number greater than '0.1%'");
            }

            if (!IsMeanValid)
            {
                errors.Add("Average Return (%) must be a valid number greater than '0.1%'");
            }

            if (!IsNumDaysValid)
            {
                errors.Add("Time (Days) must be a valid number greater than 1");
            }

            if (errors.Count > 0)
            {
                AlertService.ShowAlert("Parameter Validation", string.Join(Environment.NewLine, errors));
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
