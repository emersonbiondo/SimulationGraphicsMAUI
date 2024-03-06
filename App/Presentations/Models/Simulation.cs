namespace App.Presentations.Models
{
    public class Simulation
    {
        public double InitialPrice { get; set; }

        public double Sigma { get; set; }

        public double Mean { get; set; }

        public int NumDays { get; set; }

        public Simulation()
        {
            InitialPrice = 100;

            Sigma = 20;

            Mean = 1;

            NumDays = 252;
        }
    }
}
