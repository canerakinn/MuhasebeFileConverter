using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuhasebeFileConverter
{
    public partial class LoginMenu : Form
    {
        public LoginMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IslemDefteri islemDefteri= new IslemDefteri();

            islemDefteri.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IslemDefteri islemDefteri = new IslemDefteri();
            islemDefteri.Show();
        }
    }
}
