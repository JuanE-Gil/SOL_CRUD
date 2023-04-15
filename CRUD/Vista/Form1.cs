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

            Refrescar();
            MessageBox.Show("!Nuevo Producto Actualizado¡", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            LimpiarDatos();
            Refrescar();
            MessageBox.Show("!Nuevo Producto agregado¡", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnEliminar_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("¿Estas seguro de querer eliminar este producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                productos.Delete(Convert.ToInt32(TxtCodigo.Text));
                LimpiarDatos();
                Refrescar();
                MessageBox.Show("!Producto Eliminado¡", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e) {
            LimpiarDatos();
        }

        private void Refrescar() {
            dgvProductos.DataSource = productos.listado_pr("%");
        }

        private void LimpiarDatos() {
            TxtCodigo.Text = "";
            TxtDrescripcion.Text = "";
            TxtMarca.Text = "";
            CboCategorias.SelectedIndex = 0;
            CboMedidas.SelectedIndex = 0;
            TxtStock.Text = "";
            DtpFecha.Value = DateTime.Today;
            TxtBuscar.Text = "";

            BtnActualizar.Visible = false;
            BtnEliminar.Enabled = false;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (string.IsNullOrEmpty(Convert.ToString(dgvProductos.CurrentRow.Cells["codigo_pr"].Value))) {
                MessageBox.Show("No se tiene información para visualizar",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            } else {
                TxtCodigo.Text = dgvProductos.CurrentRow.Cells["codigo_pr"].Value.ToString();
                TxtDrescripcion.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["descripcion_pr"].Value);
                TxtMarca.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["marca_pr"].Value);
                CboCategorias.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["descripcion_ca"].Value);
                CboMedidas.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["descripcion_me"].Value);
                TxtStock.Text = Convert.ToString(dgvProductos.CurrentRow.Cells["stock_actual"].Value);
                DtpFecha.Text = dgvProductos.CurrentRow.Cells["fecha_crea"].Value.ToString();
            }
            BtnActualizar.Visible = true;
            BtnEliminar.Enabled = true;
        }

        private void listado_pr(string cTexto) {
            dgvProductos.DataSource = productos.listado_pr(cTexto);
        }

        private void BtnBuscar_Click(object sender, EventArgs e) {
            this.listado_pr(TxtBuscar.Text);
        }
    }
}
