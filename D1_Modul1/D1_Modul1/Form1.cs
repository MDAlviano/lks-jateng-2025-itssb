using D1_Modul1.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D1_Modul1
{
    public partial class Form1 : Form
    {
        private HovSedhepDataClassesDataContext dataContext;

        public Form1()
        {
            InitializeComponent();

            string connString = ConfigurationManager.ConnectionStrings["D1_Modul1.Properties.Settings.HovSedhepDatabaseConnectionString"].ConnectionString;
            this.dataContext = new HovSedhepDataClassesDataContext(connString);

            bTableSeating.BackColor = Color.Blue;

            UCTableSeating uCTableSeating = new UCTableSeating();
            flpMain.Controls.Add(uCTableSeating);
        }

        private void bTableSeating_Click(object sender, EventArgs e)
        {
            flpMain.Controls.Clear();

            bTableSeating.BackColor = Color.Blue;
            bMenu.BackColor = SystemColors.ActiveBorder;
            bHistory.BackColor = SystemColors.ActiveBorder;

            UCTableSeating uCTableSeating = new UCTableSeating();
            flpMain.Controls.Add(uCTableSeating);
        }

        private void bMenu_Click(object sender, EventArgs e)
        {
            flpMain.Controls.Clear();

            bTableSeating.BackColor = SystemColors.ActiveBorder;
            bMenu.BackColor = Color.Blue;
            bHistory.BackColor = SystemColors.ActiveBorder;

            UCMenu uCMenu = new UCMenu();
            flpMain.Controls.Add(uCMenu);
        }

        private void bHistory_Click(object sender, EventArgs e)
        {
            flpMain.Controls.Clear();

            bTableSeating.BackColor = SystemColors.ActiveBorder;
            bMenu.BackColor = SystemColors.ActiveBorder;
            bHistory.BackColor = Color.Blue;

            UCHistory uCHistory = new UCHistory();
            flpMain.Controls.Add(uCHistory);
        }
    }
}
