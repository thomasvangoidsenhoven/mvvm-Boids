using Bindings;
using Cells;
using Model.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class HunterViewModel
    {

        private BoidSpecies hunterSpecies;
        public Cell<double> Maxspeed
        {
            get;
            set;
        }

        public Cell<double> MaxAcceleration
        {
            get;
            set;
        }

        public HunterViewModel(BoidSpecies species)
        {
            hunterSpecies = species;
            var bindings = species.Bindings;
            Maxspeed = bindings.Read(BoidSpecies.MaximumSpeed);
            MaxAcceleration = bindings.Read(BoidSpecies.MaximumAcceleration);
            
        }

    }
}
