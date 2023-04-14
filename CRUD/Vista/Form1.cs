using System;
using System.Windows.Forms;

using CRUD.Controlador;

namespace CRUD.Vista
{
    public partial class Form1 : Form
    {
        private CtrProductos productos = new CtrProductos();
        private CtrMedidas medidas = new CtrMedidas();
        private CtrCategorias categoria = new CtrCategorias();

        public Form1() {
            InitializeComponent();
            CargarMedidas();
            CargarCategorias();
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvProductos.DataSource = productos.FindAll();
        }

        private void CargarMedidas() {
            CboMedidas.DataSource = medidas.FindAll(); //Obtiene los datos de la tabla
            CboMedidas.ValueMember = "codigo_me"; // Se le asigna los valores a los items
            CboMedidas.DisplayMember = "descripcion_me";
        }
        private void CargarCategorias() {
            CboCategorias.DataSource = categoria.FindAll();
            CboCategorias.ValueMember = "codigo_ca";
            CboCategorias.DisplayMember = "descripcion_ca";
        }

        private void BtnActualizar_Click(object sender, EventArgs e) {

        }

        private void BtnGuardar_Click(object sender, EventArgs e) {
            int codigo_pr = Convert.ToInt32(TxtCodigo.Text);
            string descripcion = TxtDrescripcion.Text;
            string marca = TxtMarca.Text;
        }

        private void BtnEliminar_Click(object sender, EventArgs e) {

        }

        private void BtnCancelar_Click(object sender, EventArgs e) {

        }
    }
}
