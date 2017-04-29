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

        private SpeciesViewModel _HunterView;
        public SpeciesViewModel HunterView
        {
            get { return this._HunterView; }
            set { this._HunterView = value; }
        }


        private SpeciesViewModel _PreyView;
        public SpeciesViewModel PreyView
        {
            get { return this._PreyView; }
            set { this._PreyView = value; }
        }



        public SimulationViewModel(Simulation simulation)
        {
            _simulation = simulation;
            WorldView = new WorldViewModel(_simulation.World);
            HunterView = new SpeciesViewModel(_simulation.Species[0]);
            PreyView = new SpeciesViewModel(_simulation.Species[1]);
        }
    }
}
