using Pharmacy_Management_System.AdministratorUC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System
{
    public partial class Pharmacist1 : Form
    {
        public Pharmacist1()
        {
            InitializeComponent();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uC_P_Dashboard1.Visible = true;

            uC_P_Dashboard1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uC_P_Dashboard1_Load(object sender, EventArgs e)
        {
            uC_P_Dashboard1.Visible = false;
            uC_P_Addmedicin1.Visible = false;
            uC_P_ViewMedicine1.Visible = false;
            uC_ModifiyMedicine1.Visible = false;
            uC_P_SellMedicine1.Visible = false;


        }

        private void btnExitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uC_P_Addmedicin1.Visible = true;
            uC_P_Addmedicin1.BringToFront();
        }

        private void uC_P_Addmedicin1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uC_P_ViewMedicine1.Visible = true;
            uC_P_ViewMedicine1.BringToFront();
        }

        private void uC_P_ViewMedicine1_Load(object sender, EventArgs e)
        {

        }

        private void btnModifyMedicine_Click(object sender, EventArgs e)
        {
            uC_ModifiyMedicine1.Visible = true;
            uC_ModifiyMedicine1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_P_SellMedicine1.Visible = true;
            uC_P_SellMedicine1.BringToFront();
        }

        private void uC_P_SellMedicine1_Load(object sender, EventArgs e)
        {

        }
    }
}
