using System;
using System.Windows.Forms;

using CRUD.Controlador;
using CRUD.Modelo;

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
            Refrescar();
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
            int codigo_pr = Convert.ToInt32(TxtCodigo.Text);
            string descripcion = TxtDrescripcion.Text;
            string marca = TxtMarca.Text;
            int categoria = Convert.ToInt32(CboCategorias.SelectedValue);
            int medidas = Convert.ToInt32(CboMedidas.SelectedValue);
            decimal stock = Convert.ToDecimal(TxtStock.Text);
            DateTime fecha = DtpFecha.Value;

            TB_PRODUCTOS _PRODUCTOS = new TB_PRODUCTOS(codigo_pr, descripcion, marca, categoria, medidas, stock, fecha);

            productos.Update(_PRODUCTOS);

            MessageBox.Show("!Nuevo Producto Actualizado¡", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refrescar();

        }

        private void BtnGuardar_Click(object sender, EventArgs e) {
            int codigo_pr = Convert.ToInt32(TxtCodigo.Text);
            string descripcion = TxtDrescripcion.Text;
            string marca = TxtMarca.Text;
            int categoria = Convert.ToInt32(CboCategorias.SelectedValue);
            int medidas = Convert.ToInt32(CboMedidas.SelectedValue);
            decimal stock = Convert.ToDecimal(TxtStock.Text);
            DateTime fecha = DtpFecha.Value;

            TB_PRODUCTOS _PRODUCTOS = new TB_PRODUCTOS(codigo_pr, descripcion, marca, categoria, medidas, stock, fecha);

            productos.Insert(_PRODUCTOS);

            MessageBox.Show("!Nuevo Producto agregado¡", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Refrescar();

        }

        private void BtnEliminar_Click(object sender, EventArgs e) {

        }

        private void BtnCancelar_Click(object sender, EventArgs e) {

        }

        private void Refrescar() {
            dgvProductos.DataSource = productos.FindAll();
        }

        private void LimpiarDatos() {
            TxtCodigo.Text = "";
            TxtDrescripcion.Text = "";
            TxtMarca.Text = "";
            CboCategorias.SelectedIndex = 0;
            CboMedidas.SelectedIndex = 0;
            TxtStock.Text = "";
            DtpFecha.Value = DateTime.Now;

            Refrescar();
            BtnActualizar.Visible = false;
            BtnCancelar.Enabled = false;
        }
    }
}
