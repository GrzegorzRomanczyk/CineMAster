using CineMAster.Forms;
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
    public partial class FormHallParameters : Form
    {
        public FormHallParameters()
        {
            InitializeComponent();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            
            int columns = Convert.ToInt32(txtColumns.Text);
            int rows = Convert.ToInt32(txtRows.Text);



            var formNewCinemaHall = new FormFactory().CreateFormNewCinemaHall(columns, rows);
            formNewCinemaHall.Show();

            //var formNewCinemaHall = new FormFactory().CreateForm4();
            //formNewCinemaHall.Show();


            this.Close();
        }
    }
}
