using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace View.classes
{
    class TimeService : ITimeService
    {
        private DispatcherTimer timer;
        public event Action<ITimeService> Advance;

        public TimeService() {
            timer = new DispatcherTimer();
            timer.Tick += AdvanceTimer;
        }

        public void Initiate(TimeSpan interval)
        {
            if (!timer.IsEnabled) timer.Start();
            timer.Interval = interval;
        }

        public void Pause()
        {
            timer.Stop();
        }

        private void AdvanceTimer(object sender, EventArgs e)
        {
            if (Advance != null)
            {
                Advance.Invoke(this);
            }
        }

    }
}
