using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParserConsole
{
    /*класс - обработчик приходящего Json-пакета*/
    public class Weather
    {
        public float temp { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }

        public long sunrise { get; set; }
        public long sunset { get; set;  }

    }
}
