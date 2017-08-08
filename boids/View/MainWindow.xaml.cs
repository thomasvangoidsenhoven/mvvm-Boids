using Mathematics;
using Model;
using Model.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public BoidSpy boidSpy;
        public BoidControls boidController;
        public MainWindow()
        {
            InitializeComponent();
            boidSpy = new BoidSpy();
            boidController = new BoidControls();
           
        }

        public void initSideWindows()
        {
            var context = (SimulationViewModel)this.DataContext;

            boidController.Hunters.DataContext = context.Species.First();
            boidController.Preys.DataContext = context.Species[1];
            boidSpy.DataContext = context;
        }

        private void Show_Boid_Controls(object sender, RoutedEventArgs e)
        {
            boidController.Show();
        }

        private void Show_Boid_Spy(object sender, RoutedEventArgs e)
        {
            boidSpy.Show();
        }
    }
}
