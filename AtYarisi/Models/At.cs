using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtYarisi.Models
{
    public class At
    {
        public At()
        {
            Hizi = new Random();
            Sakatlanma = new Random();
        }

        public Random Hizi { get; set; }

        public Random Sakatlanma { get; set; }

        public PictureBox Resmi { get; set; }
    }
}
