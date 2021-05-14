using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TP2_Simulateur.Models
{
    class Airport
    { 
        public string Name { get; set; }
        public PointCartographique Position { get; set; }
        public Airport() { }
        public Airport(string name, string position) {
            Position = new PointCartographique(position);
            Name = name;
        }
        public Airport(string name, PointCartographique position)
        {
            Position = position;
            Name = name;
        }
    }
}
