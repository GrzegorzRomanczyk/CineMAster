using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMAster
{
    public partial class Form1 : Form
    {
        public Form1(INewCinemaHall hall, IDataBaseOperations db)
        {
            InitializeComponent();

            string status = DataBase.dbInstance.OpenConnection();
            MessageBox.Show(status);

        }

        private void nowaSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHallParameters parameters = new FormHallParameters();
            parameters.Show();
        }
    }
}
