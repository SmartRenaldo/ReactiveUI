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
        private DateTimeOffset _timeTwo;
        private ObservableAsPropertyHelper<string> _timeSync;

        public MainViewModel()
        {
            this.WhenAnyValue(
                    x => x.Time,
                    x => x.TimeTwo,
                    (time, timeTwo) => $"Time 1: {time}\nTime 2: {timeTwo}")
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, nameof(TimeSync), out _timeSync, scheduler: RxApp.TaskpoolScheduler);

            Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Select(_ => DateTimeOffset.Now)
                .Subscribe(
                    time =>
                    {
                        Time = time;
                    }
                );

            Observable
                .Interval(TimeSpan.FromSeconds(2))
                .Select(_ => DateTimeOffset.Now)
                .Subscribe(
                    time =>
                    {
                        TimeTwo = time;
                    }
                );
        }

        public string TimeSync => _timeSync.Value;

        public DateTimeOffset Time
        {
            get => _time;
            set => this.RaiseAndSetIfChanged(ref _time, value);
        }

        public DateTimeOffset TimeTwo
        {
            get => _timeTwo;
            set => this.RaiseAndSetIfChanged(ref _timeTwo, value);
        }
    }
} 
