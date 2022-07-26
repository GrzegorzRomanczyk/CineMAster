using System;
using System.Windows.Forms;

namespace CineMAster
{
    public partial class FormNewCinemaHall : Form
    {
        //CinemaHall cinemaHall = new CinemaHall();
        private IDataBaseOperations _operations;
        private NewCinemaHall _newCinemaHall;
        public FormNewCinemaHall(IDataBaseOperations operations, NewCinemaHall newCinema, int collumns, int rows)
        {
            InitializeComponent();

            _newCinemaHall = newCinema;
            _operations = operations;

            _newCinemaHall.columns = collumns;
            _newCinemaHall.rows = rows;
            _newCinemaHall.chairsInHall = rows * collumns;
            textBox2.Text = collumns.ToString();
            textBox3.Text = rows.ToString();

            
        }
        private void FormNewCinemaHall_Load(object sender, EventArgs e)
        {
            
            _newCinemaHall.CreateHall(panel1, _newCinemaHall.columns, _newCinemaHall.rows);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _newCinemaHall.hallName = textBox1.Text;

            _operations.Save(_newCinemaHall);

            MessageBox.Show("Zapisano do bazy danych");
            this.Close();
            
        }
    }
}
