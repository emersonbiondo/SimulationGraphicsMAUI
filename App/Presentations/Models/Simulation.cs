using App.Utils;

namespace App.Presentations.Models
{
    public class Simulation
    {
        public double InitialPrice { get; set; }

        public double Sigma { get; set; }

        public double Mean { get; set; }

        public int NumDays { get; set; }

        public float StrokeSizeValue { get; set; }

        public List<string> ListColors { get; set; }

        public string Color { get; set; }

        public Simulation()
        {
            InitialPrice = 100;
            Sigma = 20;
            Mean = 1;
            NumDays = 252;
            StrokeSizeValue = 2;
            ListColors = new List<string>()
            {
                "Amarelo",
                "Azul",
                "Laranja",
                "Preto",
                "Vermelho"
            };
            Color = "Preto";
        }

        public double[] GenerateBrownianMotion()
        {
            return BrownianMotion.GenerateBrownianMotion(Sigma, Mean, InitialPrice, NumDays);
        }
    }
}
