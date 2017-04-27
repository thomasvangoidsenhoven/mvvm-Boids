using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public interface ICell<T> : INotifyPropertyChanged
    {
        T Value { get; set; }

        event Action<ICell<T>> ValueChanged;
    }

    public class Cell<T> : ICell<T>
    {
        private T value;

        public event Action<ICell<T>> ValueChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public Cell(T initialValue)
        {
            this.value = initialValue;
        }

        public virtual T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (!AreEqual(this.value, value))
                {
                    this.value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
                    NotifyObservers();
                }
            }
        }

        private bool AreEqual(T x, T y)
        {
            if (x == null)
            {
                return y == null;
            }
            else
            {
                return x.Equals(y);
            }
        }

        private void NotifyObservers()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this);
            }
        }
    }

    public class Derived<T, R> : Cell<R>
    {
        private readonly Func<T, R> transformer;

        protected Derived(ICell<T> cell, Func<T, R> transformer)
            : base(transformer(cell.Value))
        {


            this.transformer = transformer;

            cell.ValueChanged += CellUpdated;
        }

        private void CellUpdated(ICell<T> cell)
        {
            base.Value = transformer(cell.Value);
        }


        public override R Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
    }
}
