using Bindings;
using Cells;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WorldViewModel
    {
        private ObservableCollection<BoidViewModel> _BoidViewModels;

        public ObservableCollection<BoidViewModel> BoidViewModels {
            get { return _BoidViewModels; }
            set { _BoidViewModels = value; }
        }

        public Cell<double> Height => worldRefBinding.Read(World.Height);
        public Cell<double> Width => worldRefBinding.Read(World.Width);

        private World worldRef;
        private ParameterBindings worldRefBinding => worldRef.Bindings;

        public WorldViewModel(World world)
        {
            worldRef = world;
            //maakt observable boidviewmodels 
            BoidViewModels = new ObservableCollection<BoidViewModel>(worldRef.Population.Select(boid => new BoidViewModel(boid)));
            
        }

        //method invoked on change in boids
        public void update_population(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //reset and recreate the viewmodels | does not delete the actual _BoidViewModels object, only clear and refill
            BoidViewModels.Clear();

            // ** LINQ does not have indexes use foreach instead
            //for(int i = 0; i < worldRef.Population.Count; i++)
            //{
            //    BoidViewModels.Add(new BoidViewModel(worldRef.Population.se))
            //}
            foreach (Boid boid in worldRef.Population)
            {
                BoidViewModels.Add(new BoidViewModel(boid));
            }

        }
    }
}
