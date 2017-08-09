using Mathematics;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using View.classes;
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

            //dependency injection timer
            var container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container);
            container.RegisterType<ITimeService, TimeService>();
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);


            Simulation simulation = new Simulation();
            
            
            SimulationViewModel vm = new SimulationViewModel(simulation);

            var main = new MainWindow();
            main.DataContext = vm;
            main.initSideWindows();
        


            main.Show();
        
            
            
           
        }
    }
}
