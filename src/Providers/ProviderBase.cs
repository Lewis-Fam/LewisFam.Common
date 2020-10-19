using System;
using System.Collections.Generic;
using System.Text;

namespace LewisFam.Common.Providers
{
    public abstract class ProviderBase<T> : IObservable<T>
    {
        protected List<IObserver<T>> observers;

        protected ProviderBase()
        {
            observers = new List<IObserver<T>>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;

            public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public virtual void Get()
        {
        }
        public void GetTemperature()
        {
            // Create an array of sample data to mimic a temperature device.
            Nullable<Decimal>[] temps =
            {
                14.6m, 14.65m, 14.7m, 14.9m, 14.9m, 15.2m, 15.25m, 15.2m, 15.4m, 15.45m, null
            };
            // Store the previous temperature, so notification is only sent after at least .1 change.
            Nullable<Decimal> previous = null;
            bool start = true;

            foreach (var temp in temps)
            {
                System.Threading.Thread.Sleep(2500);
                if (temp.HasValue)
                {
                    if (start || (Math.Abs(temp.Value - previous.Value) >= 0.1m))
                    {
                        //IStockPrice tempData = new Stock(temp.Value, DateTime.Now);
                        //foreach (var observer in observers)
                        //   observer.OnNext(tempData);
                        previous = temp;
                        if (start) start = false;
                    }
                }
                else
                {
                    foreach (var observer in observers.ToArray())
                        if (observer != null)
                            observer.OnCompleted();

                    observers.Clear();
                    break;
                }
            }
        }

    }
}
