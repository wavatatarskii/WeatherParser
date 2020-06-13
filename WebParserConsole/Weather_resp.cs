using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebParserConsole
{
    public class Weather_resp
    {
        public Weather Main { get; set; }

        public Weather Sys { get; set; }
      
        public string Name { get; set; }
    }
}
