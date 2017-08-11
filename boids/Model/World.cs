using Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class World
    {
        //removed readonly to change the values
        public static  RangedDoubleParameter Width = new RangedDoubleParameter("Width", 1500, 100, 10000);

        public static  RangedDoubleParameter Height = new RangedDoubleParameter("Height", 1000, 100, 10000);

        public World()
        {
            this.Population = new ObservableCollection<Boid>();
            this.Bindings = new ParameterBindings("World").Initialize(Width).Initialize(Height);
        }

        public ObservableCollection<Boid> Population { get; }

        public void Update(double dt)
        {
            foreach (var boid in Population)
            {
                boid.Update(dt);
            }
        }

        public ParameterBindings Bindings { get; }
    }
}
