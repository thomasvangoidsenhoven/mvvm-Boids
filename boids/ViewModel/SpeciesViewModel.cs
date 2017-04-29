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
    public class SpeciesViewModel
    {
        private BoidSpecies specie;
        public BindingsViewModel Bindings;

        public SpeciesViewModel(BoidSpecies specie)
        {
            this.specie = specie;
            Bindings = new BindingsViewModel(specie.Bindings);
        }
    }

    public class BindingsViewModel
    {
        private ParameterBindings bindings;
        public IEnumerable<RangeViewModel> RangeViewModel;
        public BindingsViewModel(ParameterBindings bindings)
        {
            this.bindings = bindings;
            this.RangeViewModel = this.bindings.Parameters.Where(p => p is RangedDoubleParameter).Select(p => new RangeViewModel(this.bindings, (RangedDoubleParameter) p));
        }

    }

    public class RangeViewModel
    {
        private ParameterBindings parameterBindings;
        private RangedDoubleParameter parameter;

        public String Name;
        public Cell<double> Value { get; set; }

        public RangeViewModel(ParameterBindings bindings, RangedDoubleParameter parameter)
        {
            parameterBindings = bindings;
            this.parameter = parameter;
            this.Value = this.parameterBindings.Read(this.parameter);
            this.Name = parameter.Id;
        }
    }
}
