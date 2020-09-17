using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alarm
{

    public delegate void AlarmAction();

    class Program
    {
        static void Main(string[] args)
        {
            Alarm a = new Alarm();
            for(int i = 0; i < 100; i++)
            {
                if (i % 10 == 0) a.ai.Ringing();
                else a.ai.Ticking();

            }
            string stop = Console.ReadLine();
        }
    }

    class AlarmInside
    {
        
        public event AlarmAction Ring;
        public event AlarmAction Tick;

        public void Ticking()
        {
            Tick();
        }

        public void Ringing()
        {
            Ring();
        }
    }

    class Alarm
    {
        public AlarmInside ai = new AlarmInside();

        public Alarm()
        {
            ai.Ring += new AlarmAction(Ringing);
            ai.Tick += new AlarmAction(Ticking);
        }

        public void Ticking()
        {
            Console.WriteLine("The Clock is TICKING.");
        }

        public void Ringing()
        {
            Console.WriteLine("     The Clock is RINGING.");
        }
    }
}
