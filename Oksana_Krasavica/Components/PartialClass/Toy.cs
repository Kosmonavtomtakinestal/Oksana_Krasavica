using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksana_Krasavica.Components
{
    partial class Toy
    {
        public string ColorBG
        {
            get
            {
                if (IsAvailable != true)
                    return "#FFC1C1C1";
                else
                    return "#ffffff";
            }
        }
    }
}
