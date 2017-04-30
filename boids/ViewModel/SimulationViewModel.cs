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

        public IList<SpeciesViewModel> Species => _simulation.Species.Select(s => new SpeciesViewModel(s)).ToList();



        public SimulationViewModel(Simulation simulation)
        {
            _simulation = simulation;
            WorldView = new WorldViewModel(_simulation.World);
            
        }
    }
}
