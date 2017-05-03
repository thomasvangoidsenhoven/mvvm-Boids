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
        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer(TimeSpan.FromMilliseconds(20), DispatcherPriority.Render, (x, y) =>
            {
                var vm = (SimulationViewModel)DataContext;
                vm.Update(0.02);
            }, this.Dispatcher);


            timer.Start();

    

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("try_add");
            var vm = (SimulationViewModel)DataContext;
            vm.populate(e.GetPosition(this).X, e.GetPosition(this).Y);
     
        }
    }
}
