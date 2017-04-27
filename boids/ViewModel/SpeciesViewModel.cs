using Model.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SpeciesViewModel
    {

        private BoidSpecies _species;
        public IEnumerable

        public SpeciesViewModel(BoidSpecies species)
        {
            _species = species;
        }
    }
}
