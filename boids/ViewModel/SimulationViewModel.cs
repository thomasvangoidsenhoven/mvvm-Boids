 using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using System.Windows.Input;
using Commands;
using Mathematics;

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
        public ICommand AddPrey { get; }
        public ICommand AddHunter { get; }
        public ICommand DefaultSpeed { get; }
        public ICommand FastSpeed { get; }
        public ICommand SlowSpeed { get; }
        public ICommand PauseSimulation { get; }


        public SimulationViewModel(Simulation simulation)
        {
            _simulation = simulation;
            _simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            _simulation.Species[1].CreateBoid(new Vector2D(250, 250));


            WorldView = new WorldViewModel(_simulation.World);
            timeService = ServiceLocator.Current.GetInstance<ITimeService>();
            timeService.Advance += AdvanceTimer;
            timeService.Start(new TimeSpan(0,0,0,0,15));


            AddPrey = EnabledCommand.FromDelegate(() => _simulation.Species[0].CreateBoid(new Vector2D(50, 50)));
            AddHunter = EnabledCommand.FromDelegate(() => _simulation.Species[1].CreateBoid(new Vector2D(50, 50)));
            PauseSimulation = EnabledCommand.FromDelegate(() => Pause_Simulation());
            DefaultSpeed = EnabledCommand.FromDelegate(() => RestartAndAdvanceTimer(20));
            SlowSpeed = EnabledCommand.FromDelegate(() => RestartAndAdvanceTimer(40));
            FastSpeed = EnabledCommand.FromDelegate(() => RestartAndAdvanceTimer(5));

        }


        public void Update(double time)
        {
            _simulation.Update(time);
        }

        private void AdvanceTimer(ITimeService service)
        {
            Update(0.02);
        }

        private void RestartAndAdvanceTimer(int interval)
        {
            timeService.Start(new TimeSpan(0, 0, 0, 0, interval));
        }

        private void Pause_Simulation()
        {
            timeService.Pause();
        }
    }
}
