using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SimulationViewModel
    {
        private Simulation _simulation;

        private WorldViewModel _WorldView;
        public WorldViewModel WorldView
        {
            set { _WorldView = value; }
            get { return _WorldView; }
        }

        private SpeciesViewModel _Species;
        public SpeciesViewModel Species
        {
            get { return _Species; }
            set { _Species = value; }
        }

        public SimulationViewModel(Simulation simulation)
        {
            _simulation = simulation;
            WorldView = new WorldViewModel(_simulation.World);
            Species = new SpeciesViewModel(_simulation.Species);
        }
    }
}
