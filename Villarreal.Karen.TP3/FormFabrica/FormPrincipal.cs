using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormFabrica
{
    public partial class frmFabrica : Form
    {
        private Fabrica fabrica;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmFabrica()
        {
            InitializeComponent();

            this.fabrica = new Fabrica("Mi fábrica"); //Crea la fabrica
            this.Text = "Fábrica ";
        }

        /// <summary>
        /// Abre un dialogo para seleccionar un archivo.
        /// Lee los datos y los deserializa en la Fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();

            try 
            { 
                if(path.ShowDialog() == DialogResult.OK)
                {
                    this.fabrica = Fabrica.Leer(path.FileName); //Lee los datos y los deserializa en la Fabrica.
                    this.Text = "Fábrica " + this.fabrica.nombre; //Cambia el nombre de la ventana de form

                    MessageBox.Show("Se cargó el archivo correctamente!", "Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.MostrarEnVisor(); //Actualiza el visor
        }

        private void MostrarEnVisor()
        {
            this.lstVisor.Items.Clear(); //Limpia el visor

            //Recorre la lista de perifericos y los agrega al visor.
            foreach (Periferico item in this.fabrica.Perifericos)
            {
                this.lstVisor.Items.Add(item.ToString());
            }

            this.btnDesechar.Enabled = false;
            this.cmbDefectuoso.Enabled = false;
        }

        /// <summary>
        /// Según el tipo de perifico seleccionado se abre un form, 
        /// se ingresan los datos y se agrega a la fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFabricar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormPeriferico frm = null;
            try
            {
                switch (this.cmbFabricar.SelectedIndex)
                {
                    case 0:
                        frm = new FormMouse();
                        break;
                    case 1:
                        frm = new FormTeclado();
                        break;
                    case 2:
                        frm = new FormAuricular();
                        break;
                }

                frm.StartPosition = FormStartPosition.CenterScreen;
                
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //Se agrega el periferico creado a la fabrica
                    if (this.fabrica + frm.PerifericoDelForm)
                    {
                        MessageBox.Show("Se fabricó correctamente!", "Fabricado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.MostrarEnVisor(); //Se actualiza el visor
                }
            }
            catch(PerifericosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se desecha o elimina un periferico de la fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesechar_Click(object sender, EventArgs e)
        {
            int i = this.lstVisor.SelectedIndex; //Se obtiene el indice del seleccionado

            if(i > -1)
            {
                try 
                { 
                    //Se elimina el periferico seleccionado
                    if(this.fabrica - this.fabrica.Perifericos[i])
                    {
                        MessageBox.Show("Se desechó correctamente!", "Desechado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.MostrarEnVisor(); //Se actualiza el visor
                }
                catch(PerifericosException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Al seleccionar un periferico se habilita el botón Desechar y el ComboBox Defectuoso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnDesechar.Enabled = true;
            this.cmbDefectuoso.Enabled = true;
        }

        /// <summary>
        /// Cambia el valor del atributo "defectuoso" de un periferico
        /// según lo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDefectuoso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.lstVisor.SelectedIndex; //Se obtiene el indice del seleccionado

            if(i > -1)
            {
                //Si selecciono True es 0 y False es 1, se asignan los valores
                if(this.cmbDefectuoso.SelectedIndex == 0)
                {
                    this.fabrica.Perifericos[i].Defectuoso = true;
                }
                else
                {
                    this.fabrica.Perifericos[i].Defectuoso = false;
                }

                this.MostrarEnVisor(); //Se actualiza el visor
            }
        }

        /// <summary>
        /// Abre un dialogo para guardar un archivo.
        /// Escribe los datos de la fábrica en el archivo xml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEscribirXml_Click(object sender, EventArgs e)
        {
            SaveFileDialog path = new SaveFileDialog();

            path.Filter = "Archivos XML|*.xml|Todos los archivos|*.*"; //Se agregan filtros

            try
            {
                if(path.ShowDialog() == DialogResult.OK)
                {
                    Fabrica.Escribir(this.fabrica, path.FileName); //Escribe los datos

                    MessageBox.Show($"Se guardaron los datos en {path.FileName}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(ArchivosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Asigna un nombre nuevo a la fabrica y lo cambia en el titulo del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            if(this.txbNombre.Text != "") //Verifica que no esté vacío
            {
                this.Text = "Fábrica " + this.txbNombre.Text;
                this.fabrica.nombre = this.txbNombre.Text;

                MessageBox.Show($"Se cambió el nombre de la fabrica a {this.txbNombre.Text}.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ingrese el nombre primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Abre un dialogo para consultar la salida al cerrar el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFabrica_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if(rta == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
