using Mathematics;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Simulation simulation = new Simulation();
            var main = new MainWindow();
            

            simulation.Species[0].CreateBoid(new Vector2D(50, 50));
            simulation.Species[1].CreateBoid(new Vector2D(150, 150));
            SimulationViewModel vm = new SimulationViewModel(simulation);
            
            main.DataContext = vm;
            main.Hunters.DataContext = vm.Species.First();
            main.Preys.DataContext = vm.Species[1];
            main.Show();

            var side = new BoidSpy();
            side.DataContext = vm;
            side.Show();
        }
    }
}
