using Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics.Forces
{
    public interface IForce
    {
        Vector2D Compute(IParameterBindings bindings, World world, Boid self);
    }
}
