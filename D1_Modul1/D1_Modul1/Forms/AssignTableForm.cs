using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D1_Modul1.Forms
{
    public partial class AssignTableForm : Form
    {
        string tableName;

        public AssignTableForm(string tableName)
        {
            InitializeComponent();

            this.tableName = tableName;

            this.Text = "Assign Table - " + tableName;
        }
    }
}
