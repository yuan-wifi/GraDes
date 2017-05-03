using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace test
{
    public partial class WaittingWindow : Form
    {
        
        DataBase db = new DataBase();
        public WaittingWindow()
        {
            InitializeComponent();
        }

        private void WaittingWindow_Load(object sender, EventArgs e)
        {
            while(true)
            {
                 int nosubmit = db.Selectissubmit();
                if(nosubmit == 0)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
