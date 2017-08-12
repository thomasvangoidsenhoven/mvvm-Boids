using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Model.AI;
using Model.Forces;
using Bindings;

namespace Model.Species
{
    public class BombSpecies : BoidSpecies
    {
        public static RangedDoubleParameter PreyAttractionConstant = new RangedDoubleParameter("Prey Attraction Constant", defaultValue: 20000, minimum: 0, maximum: 100000);

        public static RangedDoubleParameter PreyAttractionExponent = new RangedDoubleParameter("Prey Attraction Exponent", defaultValue: 1.5, minimum: 1, maximum: 10);

        //the specie it is attracted to (tries to follow)
        public static Parameter<string> FriendSpecies = new Parameter<string>("Attractive Species", "hunter");

        public BombSpecies(World world) : base(world, "bomb")
        {
            Bindings.Initialize(PreyAttractionConstant)
                .Initialize(PreyAttractionExponent)
                .Initialize(FriendSpecies);
        }

        internal override IArtificialIntelligence CreateAI(Boid boid)
        {
            return new ArtificialIntelligence(World, boid);
        }

        private class ArtificialIntelligence : Model.AI.ArtificialIntelligence
        {
            private readonly IForce friendForce;
        

            public ArtificialIntelligence(World world, Boid self)
                :base(world, self)
            {
                friendForce = new BoidAttractionForce(PreyAttractionConstant, PreyAttractionExponent, FriendSpecies);
            }

            
            public override Vector2D ComputeAcceleration()
            {
                var total = new Vector2D(0, 0);

                total += friendForce.Compute(this.self.Bindings, this.world, this.self);
                return total;
            }
        }
    }
}
