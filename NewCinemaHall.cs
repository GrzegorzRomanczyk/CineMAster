using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMAster
{
    public class NewCinemaHall : CinemaHall, INewCinemaHall
    {
       
        int currentColumn = 1; 
        int currentRow = 1;
   
        int chairSize = 50;
        int spaceBetweenChairs = 5;

        public int ChairPosition
        {
            get => chairSize + spaceBetweenChairs;
            set => ChairPosition = value;
        }
        public void CreateHall(Panel panel,int columns,int rows)
        {
            chairsInHall = 1;
            for (int j = 0; j < columns * rows; j++)
            {
                for (int i = 1; i <= currentColumn; i++)
                {
                    Button b = new Button();
                    b.Text = chairsInHall.ToString();
                    b.Name = chairsInHall.ToString();
                    b.Size = new Size(chairSize, chairSize);
                    b.Location = new Point(ChairPosition * (i), ChairPosition * currentRow);
                    panel.Controls.Add(b);
                }
                if (currentColumn == columns)
                {
                    currentColumn = 0;
                    currentRow++;
                }
                if (chairsInHall == columns * rows)
                {
                    MessageBox.Show("utworzone");
                    break;
                }
                chairsInHall++;
                currentColumn++;
            }
            
        }
    }
}
