using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CategoryRepository repository = new CategoryRepository();

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var categoria = repository.Obtener();
            dgvCategory.DataSource = categoria;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtObtenerTodos.Text);
            var categoria = repository.ObtenerPorID(id);
            List<Categories> lista1 = new List<Categories> {categoria};
            if (categoria != null)
            {
                llenarCampos(categoria);
            }
            dgvCategory.DataSource = lista1;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var categoria = CrearCategoria();
            var resultado = repository.InsertarCategoria(categoria);
            MessageBox.Show($"Se inserto {resultado}");
        }

        private Categories CrearCategoria()
        {
            var categoria = new Categories
            {
                CategoryID = int.Parse(tbxCategoryID.Text),
                CategoryName = tbxCategoryName.Text,
                Description = tbxDescription.Text,
            };
            return categoria;
        }

        private void llenarCampos(Categories categories)
        {
            tbxCategoryID.Text = categories.CategoryID.ToString();
            tbxCategoryName.Text = categories.CategoryName;
            tbxDescription.Text = categories.Description;
        }
    }
}
