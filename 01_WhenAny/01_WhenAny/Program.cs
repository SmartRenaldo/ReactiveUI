using _01_ReactiveUITest;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WhenAny
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            MainViewModel vm = new MainViewModel();
            vm.WhenAnyValue(x => x.TimeSync)
                .Subscribe(System.Console.WriteLine);

            System.Console.ReadLine();
        }
    }
}
