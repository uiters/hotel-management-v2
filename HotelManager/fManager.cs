using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fManager: Form
    {
        public fManager()
        {
            InitializeComponent();
            fLoad();
        }
        void fLoad()
        {

            panelLeft.Width = 177;
            
        }

       
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }

 

       
        private void btnNavigationPanel_Click_1(object sender, EventArgs e)
        {
            if (panelLeft.Width == 42)
            {
                panelLeft.Width = 177;
                panelRight.Width = 939;
                this.Width = 1116;
            }
            else
            {
                panelLeft.Width = 42;
                panelRight.Width = 807;
                this.Width = 981;
            }
        }

        private void titleSignUpRoom_Click(object sender, EventArgs e)
        {
            Hide();
            fBookRoom f = new fBookRoom();
            f.ShowDialog();
            Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void titleRecieveRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            fReceiveRoom f = new fReceiveRoom();
            f.ShowDialog();
            this.Show();
        }

        private void titleSendRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            fUseService f = new fUseService();
            f.ShowDialog();
            this.Show();
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            this.Hide();
            fCustomer customer = new fCustomer();
            customer.ShowDialog();
            this.Show();
        }
    }
}
