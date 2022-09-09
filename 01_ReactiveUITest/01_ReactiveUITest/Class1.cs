using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ReactiveUITest
{
    internal class Class1 : ReactiveObject
    {
        private string businessMsg;

        public string BusinessMsg { 
            get { return businessMsg; }
            set { this.RaiseAndSetIfChanged(ref businessMsg, value); }
        }
    }
}
