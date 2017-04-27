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

        private World worldRef;

        public WorldViewModel(World world)
        {
            worldRef = world;
            BoidViewModels = world.Population.Select(b => new BoidViewModel(b));
        }

    }
}
