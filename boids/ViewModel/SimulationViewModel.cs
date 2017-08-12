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

        //=> Operator creates a getter and that retuns the value;
        public IList<SpeciesViewModel> Species => _simulation.Species.Select(s => new SpeciesViewModel(s)).ToList();

        //Icommand om de command van de button 2 methodes: CanExecute + Execute
        public ICommand AddPrey { get; }
        public ICommand AddHunter { get; }
        public ICommand DefaultSpeed { get; }
        public ICommand FastSpeed { get; }
        public ICommand SlowSpeed { get; }
        public ICommand PauseSimulation { get; }
        public ICommand Reset { get; }
        public ICommand AddBomb { get; }

        public SimulationViewModel(Simulation simulation)
        {
            _simulation = simulation;

            WorldView = new WorldViewModel(_simulation.World);
            //ServiceLocator: Unity Framework // dependency Injection, gets the ITimeService object from it
            timeService = ServiceLocator.Current.GetInstance<ITimeService>();

            //every time event is triggered use the private method AdvanceTimer
            timeService.Advance += AdvanceTimer;
            timeService.Initiate(new TimeSpan(0,0,0,0,15));

            //creates the button and binds it with the private methods inside this viewmodel class; The FromDelegate creates and returns an Action object with the corresponding private method bound to it.
            //sidenode: Action Interface => delegates a method without returning something <=> Func Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.
            AddPrey = EnabledCommand.FromDelegate(() => CreateBoid(1,50,50));
            AddHunter = EnabledCommand.FromDelegate(() => CreateBoid(0,300,50));
            PauseSimulation = EnabledCommand.FromDelegate(() => Pause_Simulation());
            DefaultSpeed = EnabledCommand.FromDelegate(() => RestartAndAdvanceTimer(15));
            SlowSpeed = EnabledCommand.FromDelegate(() => RestartAndAdvanceTimer(40));
            FastSpeed = EnabledCommand.FromDelegate(() => RestartAndAdvanceTimer(3));
            Reset = EnabledCommand.FromDelegate(() => Reset_Simulation());
            AddBomb = EnabledCommand.FromDelegate(() => CreateBoid(2, 650, 650));
        }


        //clears the boids currently on the field
        private void Reset_Simulation()
        {
            _simulation.World.Population.Clear();
        }


        //creates a boid given a position
        private void CreateBoid(int boidSpecieIndex, int x, int y)
        {
            _simulation.Species[boidSpecieIndex].CreateBoid(new Vector2D(x, y));
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
            timeService.Initiate(new TimeSpan(0, 0, 0, 0, interval));
        }

        private void Pause_Simulation()
        {
            timeService.Pause();
        }
    }
}
