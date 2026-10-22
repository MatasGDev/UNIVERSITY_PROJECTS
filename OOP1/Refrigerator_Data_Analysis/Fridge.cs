using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_10
{
    internal class Fridge
    {
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public int Capacity { get; set; }
            public string Energy { get; set; }
            public string InstallationType { get; set; }
            public string Color { get; set; }
            public bool Feature { get; set; }
            public decimal Price { get; set; }
            public double Height { get; set; }
            public double Width { get; set; }
            public double Depth { get; set; }

            public Fridge(string manufacturer, string model, int capacity, string energy,
            string installationType, string color, bool feature, decimal price,
            double height, double width, double depth)
            {
                this.Manufacturer = manufacturer;
                this.Model = model;
                this.Capacity = capacity;
                this.Energy = energy;
                this.InstallationType = installationType;
                this.Color = color;
                this.Feature = feature;
                this.Price = price;
                this.Height = height;
                this.Width = width;
                this.Depth = depth;
            }
    }
}
