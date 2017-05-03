using Bindings;
using Cells;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorldViewModel
    {
        private IEnumerable<BoidViewModel> _BoidViewModels;

        public IEnumerable<BoidViewModel> BoidViewModels {
            get { return _BoidViewModels; }
            set { _BoidViewModels = value; }
        }

        public Cell<double> Height => worldRefBinding.Read(World.Height);
        public Cell<double> Width => worldRefBinding.Read(World.Width);

        private World worldRef;
        private ParameterBindings worldRefBinding => worldRef.Bindings;

        public WorldViewModel(World world)
        {
            worldRef = world;
            BoidViewModels = worldRef.Population.Select(b => new BoidViewModel(b));
        }


        public void update()
        {
            BoidViewModels = worldRef.Population.Select(b => new BoidViewModel(b));
        }
    }
}
