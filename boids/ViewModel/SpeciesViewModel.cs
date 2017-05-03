using Bindings;
using Cells;
using Mathematics;
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
       

        public SpeciesViewModel(BoidSpecies specie)
        {
            
            this.specie = specie;
        }

        public void populate(double x, double y)
        {
            
            specie.CreateBoid(new Vector2D(x, y));
        }

        public BindingsViewModel bindingsViewModel => new BindingsViewModel(specie.Bindings);
    }

    public class BindingsViewModel
    {
        private ParameterBindings bindings;
        public IEnumerable<RangeViewModel> RangeViewModel => this.bindings.Parameters.Where(p => p is RangedDoubleParameter).Select(p => new RangeViewModel(this.bindings, (RangedDoubleParameter)p));
        public BindingsViewModel(ParameterBindings bindings)
        {
            this.bindings = bindings;
         
        }

    }

    public class RangeViewModel
    {
        private ParameterBindings parameterBindings;
        private RangedDoubleParameter parameter;
        
        public String Name => parameter.Id;

        public double Minimum => parameter.Minimum;
        public double Maximum => parameter.Maximum;
        public Cell<double> Value { get; set; }

        public RangeViewModel(ParameterBindings bindings, RangedDoubleParameter parameter)
        {
            parameterBindings = bindings;
            this.parameter = parameter;
            this.Value = this.parameterBindings.Read(this.parameter);
            
        }
    }
}
