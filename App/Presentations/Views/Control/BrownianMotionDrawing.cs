﻿using Microsoft.Maui.Graphics;

namespace App.Presentations.Views.Control
{
    public class BrownianMotionDrawing : IDrawable
    {
        public float scale { get; set; } = 1;

        public double[] BrownianMotion { get; set; }

        public float StrokeSize { get; set; }

        public string Color { get; set; }

        public BrownianMotionDrawing(double[] brownianMotion, float strokeSize, string color)
        {
            BrownianMotion = brownianMotion;
            StrokeSize = strokeSize;
            Color = color;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            switch (Color)
            {
                case "Preto":
                    canvas.StrokeColor = Colors.Black;
                    break;
                case "Vermelho":
                    canvas.StrokeColor = Colors.Red;
                    break;
                case "Azul":
                    canvas.StrokeColor = Colors.Blue;
                    break;
                case "Amarelo":
                    canvas.StrokeColor = Colors.Yellow;
                    break;
                case "Laranja":
                    canvas.StrokeColor = Colors.Orange;
                    break;
                default:
                    break;
            }
            canvas.StrokeSize = StrokeSize;

            var fatorWidth = dirtyRect.Width / BrownianMotion.Length;
            var fatorHeight = dirtyRect.Height / BrownianMotion.Max();

            for (int i = 1; i < BrownianMotion.Length; i++)
            {
                canvas.DrawLine((i-1) * fatorWidth, (float)(BrownianMotion[i-1] * fatorHeight), i * fatorWidth, (float)(BrownianMotion[i] * fatorHeight));
            }
        }
    }
}
