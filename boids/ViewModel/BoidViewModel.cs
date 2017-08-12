
using Cells;
using Mathematics;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    //gets a boid species name + its current position
    public class BoidViewModel
    {
        private Boid _boid;

        public Cell<Vector2D> Position => _boid.Position;
        public string Species => _boid.Species.Name;

        public BoidViewModel(Boid boid)
        {
            _boid = boid;
            
        }

    }
}
