using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace ViewModel
{
    public class SimulationViewModel
    {
        private Simulation _simulation;
        //geen view dingen => dependency injection | op timerservice interface
        private ITimeService timeService;
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
            timeService = ServiceLocator.Current.GetInstance<ITimeService>();
            timeService.Advance += AdvanceTimer;
            timeService.Start(new TimeSpan(0,0,0,0,15));


        }


        public void Update(double time)
        {
            _simulation.Update(time);
        }

        private void AdvanceTimer(ITimeService service)
        {
            Update(0.02);
        }
    }
}
