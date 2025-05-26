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

namespace D1_Modul1.UserControls
{
    public partial class UCMenu : UserControl
    {
        private HovSedhepDataClassesDataContext dataContext;

        public UCMenu()
        {
            InitializeComponent();

            string connString = ConfigurationManager.ConnectionStrings["D1_Modul1.Properties.Settings.HovSedhepDatabaseConnectionString"].ConnectionString;
            this.dataContext = new HovSedhepDataClassesDataContext(connString);

            LoadCategory();
            LoadMenu();
        }

        private void LoadCategory()
        {
            var listCategory = from c in dataContext.Categories
                               select c.Name;

            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
            cbCategory.SelectedValue = "Name";
        }

        private void LoadMenu()
        {
            dgMenu.Rows.Clear();

            var listMenu = (from m in dataContext.MenuItems
                            join c in dataContext.Categories on m.CategoryID equals c.CategoryID
                            select new
                            {
                                id = m.MenuItemID,
                                category = c.Name,
                                name = m.Name,
                                price = m.Price,
                                description = m.Description
                            }).ToList();

            int rowData = 0;

            for (int i = 0; i <= listMenu.Count - 1; i++)
            {
                rowData = dgMenu.Rows.Add();
                dgMenu.Rows[rowData].Cells[0].Value = listMenu[i].id;
                dgMenu.Rows[rowData].Cells[1].Value = listMenu[i].category;
                dgMenu.Rows[rowData].Cells[2].Value = listMenu[i].name;
                dgMenu.Rows[rowData].Cells[3].Value = listMenu[i].price;
                dgMenu.Rows[rowData].Cells[4].Value = listMenu[i].description;
            }
        }

        private void LoadMenuByMenuName(string menuName)
        {
            dgMenu.Rows.Clear();

            var filteredMenu = (from m in dataContext.MenuItems
                                join c in dataContext.Categories on m.CategoryID equals c.CategoryID
                                where m.Name.Equals(menuName)
                                select new
                                {
                                    id = m.MenuItemID,
                                    category = c.Name,
                                    name = m.Name,
                                    price = m.Price,
                                    description = m.Description
                                }).ToList();

            int rowData = 0;

            for (int i = 0; i <= filteredMenu.Count - 1; i++)
            {
                rowData = dgMenu.Rows.Add();
                dgMenu.Rows[rowData].Cells[0].Value = filteredMenu[i].id;
                dgMenu.Rows[rowData].Cells[1].Value = filteredMenu[i].category;
                dgMenu.Rows[rowData].Cells[2].Value = filteredMenu[i].name;
                dgMenu.Rows[rowData].Cells[3].Value = filteredMenu[i].price;
                dgMenu.Rows[rowData].Cells[4].Value = filteredMenu[i].description;
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue != null)
            {
                try
                {
                    dgMenu.Rows.Clear();

                    string categoryName = (string)cbCategory.SelectedValue;

                    var listMenu = (from m in dataContext.MenuItems
                                    join c in dataContext.Categories on m.CategoryID equals c.CategoryID
                                    where c.Name.Equals(categoryName)
                                    select new
                                    {
                                        id = m.MenuItemID,
                                        category = c.Name,
                                        name = m.Name,
                                        price = m.Price,
                                        description = m.Description
                                    }).ToList();

                    int rowData = 0;

                    for (int i = 0; i <= listMenu.Count - 1; i++)
                    {
                        rowData = dgMenu.Rows.Add();
                        dgMenu.Rows[rowData].Cells[0].Value = listMenu[i].id;
                        dgMenu.Rows[rowData].Cells[1].Value = listMenu[i].category;
                        dgMenu.Rows[rowData].Cells[2].Value = listMenu[i].name;
                        dgMenu.Rows[rowData].Cells[3].Value = listMenu[i].price;
                        dgMenu.Rows[rowData].Cells[4].Value = listMenu[i].description;
                    }
                } catch (Exception ex) { }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string menuName = tbMenuName.Text;
            if (string.IsNullOrWhiteSpace(menuName))
            {
                MessageBox.Show("Please fill menu name field before click the button!");
            } else
            {
                LoadMenuByMenuName(menuName);
            }
        }

        private void tbMenuName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
