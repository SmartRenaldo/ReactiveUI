using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ReactiveUITest
{
    public class MainViewModel : ReactiveObject
    {
        private DateTimeOffset _time;

        public MainViewModel()
        {
            this.WhenAnyValue(x => x.Time)
                .Subscribe(time => System.Console.WriteLine(time));

            Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => DateTimeOffset.Now)
                .Subscribe(
                    time =>
                    {
                        Time = time;
                    }
                );
        }

        public DateTimeOffset Time
        {
            get => _time;
            set => this.RaiseAndSetIfChanged(ref _time, value);
        }
    }
} 
