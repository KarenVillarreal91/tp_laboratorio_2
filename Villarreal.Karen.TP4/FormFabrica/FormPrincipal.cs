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
using System.Data.SqlClient;
using System.Threading;

namespace FormFabrica
{

    public partial class frmFabrica : Form
    {
        public delegate void Delegado(PictureBox pB, string path);

        private Fabrica fabrica;
        private int desecharFlag = 0;

        private SqlConnection conexion;
        private SqlDataAdapter dataA;

        private DataTable dataT;

        private Thread hiloPerifericos;
        private Thread hiloDesechar;
        public event Delegado eventoImagen;

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmFabrica()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.fabrica = new Fabrica("Mi fábrica"); //Crea la fabrica
            this.Text = "Fábrica ";

            this.eventoImagen += this.MostrarImagen; //Se agrega el manejador al evento

            this.hiloPerifericos = new Thread(this.EjecutarPerifericos); //Se asocia la dirección de memoria del método al hilo

            this.hiloDesechar = new Thread(this.EjecutarDesechar);  //Se asocia la dirección de memoria del método al hilo del gif

            if (!this.hiloPerifericos.IsAlive) //Verifica que el hilo esté muerto
            {
                this.hiloPerifericos.Start(); //Inicia el hilo de perifericos
            }

            if (!this.hiloDesechar.IsAlive) //Verifica que el hilo esté muerto
            {
                this.hiloDesechar.Start(); //Inicia el hilo de desechar
            }

            this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD); //Se establece la conexión
            this.ConfigurarDataAdapter(); //Configura el DataAdapter
            this.ConfigurarDataTable(); //Configura el DataTable

            this.dgvListado.DataSource = this.dataT; //Se vincula la grilla con el DataTable

            this.btnDesechar.Enabled = false; //Se desabilita el botón de desechar y ComboBox de defectuoso
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
                        this.AgregarADataT(frm.PerifericoDelForm); //Se agrega al DataTable

                        MessageBox.Show("Se fabricó correctamente!", "Fabricado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (PerifericosException ex)
            {
                MessageBox.Show(ex.InformarPerifericoRepetido(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se desecha o elimina un periferico de la fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesechar_Click(object sender, EventArgs e)
        {
            int i = this.dgvListado.CurrentRow.Index; //Obtiene el indice de la fila seleccionada

            //Obtiene la fila seleccionada de la grilla
            DataRowView filaActual = (DataRowView)this.dgvListado.CurrentRow.DataBoundItem;

            if (i > -1)
            {
                try
                { 
                    //Se elimina el periferico seleccionado
                    if (this.fabrica - this.fabrica.Perifericos[i])
                    {
                        //Busca la fila en el DataTable que coincida con los atributos de la fila de la grilla y lo elimina
                        this.dataT.Rows.Find(new object[] { filaActual.Row[2], filaActual.Row[4] }).Delete();

                        this.desecharFlag = 1;
                        MessageBox.Show("Se desechó correctamente!", "Desechado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (PerifericosException ex)
                {
                    this.desecharFlag = 2;
                    MessageBox.Show(ex.InformarPerifericoNoDefectuoso(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Al seleccionar un periferico se habilita el botón Desechar y el ComboBox Defectuoso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            //Si el listado de la grilla no está vácio habilita el botón y el combobox
            if (this.dgvListado.CurrentRow != null)
            {
                this.btnDesechar.Enabled = true;
                this.cmbDefectuoso.Enabled = true;
            }
            else
            {
                this.btnDesechar.Enabled = false;
                this.cmbDefectuoso.Enabled = false;
            }
        }

        /// <summary>
        /// Cambia el valor del atributo "defectuoso" de un periferico
        /// según lo seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDefectuoso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = this.dgvListado.CurrentRow.Index; //Obtiene el indice de la fila seleccionada

            //Obtiene la fila seleccionada de la grilla
            DataRowView filaActual = (DataRowView)this.dgvListado.CurrentRow.DataBoundItem;

            if (i > -1)
            {
                //Si selecciono True es 0 y False es 1, se asignan los valores
                if (this.cmbDefectuoso.SelectedIndex == 0)
                {
                    this.fabrica.Perifericos[i].Defectuoso = true;

                    //Busca la fila en el DataTable que coincida con los atributos de la fila de la grilla
                    //y setea en true el atributo Defectuoso
                    this.dataT.Rows.Find(new object[] { filaActual.Row[2], filaActual.Row[4] })[5] = true;
                }
                else
                {
                    this.fabrica.Perifericos[i].Defectuoso = false;

                    //Busca la fila en el DataTable que coincida con los atributos de la fila de la grilla
                    //y setea en false el atributo Defectuoso
                    this.dataT.Rows.Find(new object[] { filaActual.Row[2], filaActual.Row[4] })[5] = false;
                }
            }
        }

        /// <summary>
        /// Abre un dialogo para seleccionar un archivo.
        /// Lee los datos y los deserializa en la Fabrica.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerXml_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("Si cargó un periférico anteriormente se borrará.\n¿Está seguro?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (rta == DialogResult.OK) //Si acepta continua
            {
                OpenFileDialog path = new OpenFileDialog();

                try
                {
                    if (path.ShowDialog() == DialogResult.OK)
                    {
                        this.fabrica = Fabrica.Leer(path.FileName); //Lee los datos y los deserializa en la Fabrica.
                        this.Text = "Fábrica " + this.fabrica.nombre; //Cambia el nombre de la ventana de form

                        this.dataT.Rows.Clear(); //Limpia el DataTable

                        //Agrega cada periférico de la lista al DataTable
                        foreach (Periferico item in this.fabrica.Perifericos)
                        {
                            this.AgregarADataT(item);
                        }

                        MessageBox.Show("Se cargó el archivo correctamente!", "Cargado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (ArchivosException ex)
                {
                    MessageBox.Show(ex.InformarArchivoErroneo(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (path.ShowDialog() == DialogResult.OK)
                {
                    Fabrica.Escribir(this.fabrica, path.FileName); //Escribe los datos

                    MessageBox.Show($"Se guardaron los datos en {path.FileName}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.InformarArchivoErroneo(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Asigna un nombre nuevo a la fabrica y lo cambia en el titulo del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarNombre_Click(object sender, EventArgs e)
        {
            if (this.txbNombre.Text != "") //Verifica que no esté vacío
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
        /// Carga el listado de periféricos desde la base de datos, eliminando la listado cargado anteriormente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarBD_Click(object sender, EventArgs e)
        {
            bool aux;

            DialogResult rta = MessageBox.Show("Si cargó un periférico anteriormente se borrará.\n¿Está seguro?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(rta == DialogResult.OK) //Si acepta continua
            {
                try
                {
                    this.fabrica.Perifericos.Clear(); //Borra la lista de la fábrica
                    this.dataT.Clear(); //Borra el listado del DataTable

                    this.dataA.Fill(this.dataT); //Obtiene el listado de la base de datos

                    //Agrega el listado de DataTable al listado de la fábrica según el tipo de periférico
                    foreach (DataRow fila in this.dataT.Rows)
                    {
                        try
                        {
                            if (fila.RowState != DataRowState.Deleted) //Verifica que la fila no esté marcada como eliminada
                            {
                                if (fila[0].ToString() == "Auricular")
                                {
                                    Auricular aur = new Auricular((EColor)fila[1], (EMarca)fila[2], (bool)fila[3], bool.Parse(fila[6].ToString()));

                                    aur.NroSerie = fila[4].ToString();
                                    aur.Defectuoso = (bool)fila[5];

                                    aux = this.fabrica + aur;
                                }
                                else
                                {
                                    if (fila[0].ToString() == "Teclado")
                                    {
                                        Teclado teclado = new Teclado((EColor)fila[1], (EMarca)fila[2], (bool)fila[3], (ETipoTeclado)fila[7]);

                                        teclado.NroSerie = fila[4].ToString();
                                        teclado.Defectuoso = (bool)fila[5];

                                        aux = this.fabrica + teclado;
                                    }
                                    else
                                    {
                                        Mouse mouse = new Mouse((EColor)fila[1], (EMarca)fila[2], (bool)fila[3], (int)fila[8]);

                                        mouse.NroSerie = fila[4].ToString();
                                        mouse.Defectuoso = (bool)fila[5];

                                        aux = this.fabrica + mouse;
                                    }
                                }
                            }
                        }
                        catch (PerifericosException)
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Guarda/Actualiza la lista de periféricos actual en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarBD_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataA.Update(this.dataT); //Actualiza la base de datos con el listado de DataTable

                MessageBox.Show("Datos sincronizados.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo sincronizar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (rta == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                if (this.hiloPerifericos.IsAlive) //Verifica que el hilo de perifericos esté vivo 
                {
                    this.hiloPerifericos.Abort(); //Lo aborta
                }

                if (this.hiloDesechar.IsAlive) //Verifica que el hilo de desechar no sea null
                {
                    this.hiloDesechar.Abort(); //Lo aborta
                }
            }
        }

        #region Metodos
        /// <summary>
        /// Agrega el periférico al DataTable.
        /// </summary>
        /// <param name="periferico">Periférico a agregar.</param>
        private void AgregarADataT(Periferico periferico)
        {
            DataRow fila = this.dataT.NewRow();

            fila[0] = periferico.Tipo;
            fila[1] = periferico.Color;
            fila[2] = periferico.Marca;
            fila[3] = periferico.Inalambrico;
            fila[4] = periferico.NroSerie;
            fila[5] = periferico.Defectuoso;

            //Según el tipo asigna su respectivo atributo
            if (periferico.Tipo == "Auricular")
            {
                fila[6] = ((Auricular)periferico).conMicrofono.ToString();
            }
            else
            {
                if (periferico.Tipo == "Teclado")
                {
                    fila[7] = ((Teclado)periferico).tipo;
                }
                else
                {
                    fila[8] = ((Mouse)periferico).cantBotones;
                }
            }

            this.dataT.Rows.Add(fila); //Lo agrega
        }

        /// <summary>
        /// Configura las columnas del DataTable.
        /// </summary>
        private void ConfigurarDataTable()
        {
            this.dataT = new DataTable("Perifericos");

            this.dataT.Columns.Add("Tipo", typeof(string));
            this.dataT.Columns.Add("Color", typeof(EColor));
            this.dataT.Columns.Add("Marca", typeof(EMarca));
            this.dataT.Columns.Add("EsInalambrico", typeof(bool));
            this.dataT.Columns.Add("NroSerie", typeof(string));
            this.dataT.Columns.Add("Defectuoso", typeof(bool));
            this.dataT.Columns.Add("ConMicrofono", typeof(string));
            this.dataT.Columns.Add("Teclas", typeof(ETipoTeclado));
            this.dataT.Columns.Add("CantBotones", typeof(int));

            //Agrega la marca y el nroSerie como primary key
            this.dataT.PrimaryKey = new DataColumn[] { this.dataT.Columns[2], this.dataT.Columns[4] };
        }

        /// <summary>
        /// Configura los comandos del DataAdapter.
        /// </summary>
        private void ConfigurarDataAdapter()
        {
            try
            {
                this.dataA = new SqlDataAdapter();

                this.dataA.SelectCommand = new SqlCommand($"SELECT * FROM tablaPerifericos", this.conexion);
                this.dataA.InsertCommand = new SqlCommand($"INSERT INTO tablaPerifericos (tipo, color, marca, esInalambrico, nroSerie, defectuoso, conMicrofono, teclas, cantBotones)" +
                                                            $" VALUES (@tipo, @color, @marca, @esInalambrico, @nroSerie, @defectuoso, @conMicrofono, @teclas, @cantBotones)", this.conexion);
                this.dataA.UpdateCommand = new SqlCommand($"UPDATE tablaPerifericos SET tipo=@tipo, color=@color, marca=@marca, esInalambrico=@esInalambrico, nroSerie=@nroSerie, defectuoso=@defectuoso, conMicrofono=@conMicrofono, teclas=@teclas, cantBotones=@cantBotones" +
                                                            " WHERE marca=@marca AND nroSerie=@nroSerie", this.conexion);
                this.dataA.DeleteCommand = new SqlCommand($"DELETE FROM tablaPerifericos WHERE marca=@marca AND nroSerie=@nroSerie", this.conexion);

                this.dataA.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.dataA.InsertCommand.Parameters.Add("@color", SqlDbType.Int, 10, "color");
                this.dataA.InsertCommand.Parameters.Add("@marca", SqlDbType.Int, 10, "marca");
                this.dataA.InsertCommand.Parameters.Add("@esInalambrico", SqlDbType.Bit, 10, "esInalambrico");
                this.dataA.InsertCommand.Parameters.Add("@nroSerie", SqlDbType.VarChar, 50, "nroSerie");
                this.dataA.InsertCommand.Parameters.Add("@defectuoso", SqlDbType.Bit, 10, "defectuoso");
                this.dataA.InsertCommand.Parameters.Add("@conMicrofono", SqlDbType.Bit, 10, "conMicrofono");
                this.dataA.InsertCommand.Parameters.Add("@teclas", SqlDbType.Int, 10, "teclas");
                this.dataA.InsertCommand.Parameters.Add("@cantBotones", SqlDbType.Int, 10, "cantBotones");

                this.dataA.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.dataA.UpdateCommand.Parameters.Add("@color", SqlDbType.Int, 10, "color");
                this.dataA.UpdateCommand.Parameters.Add("@marca", SqlDbType.Int, 10, "marca");
                this.dataA.UpdateCommand.Parameters.Add("@esInalambrico", SqlDbType.Bit, 10, "esInalambrico");
                this.dataA.UpdateCommand.Parameters.Add("@nroSerie", SqlDbType.VarChar, 50, "nroSerie");
                this.dataA.UpdateCommand.Parameters.Add("@defectuoso", SqlDbType.Bit, 10, "defectuoso");
                this.dataA.UpdateCommand.Parameters.Add("@conMicrofono", SqlDbType.Bit, 10, "conMicrofono");
                this.dataA.UpdateCommand.Parameters.Add("@teclas", SqlDbType.Int, 10, "teclas");
                this.dataA.UpdateCommand.Parameters.Add("@cantBotones", SqlDbType.Int, 10, "cantBotones");

                this.dataA.DeleteCommand.Parameters.Add("@marca", SqlDbType.Int, 10, "marca");
                this.dataA.DeleteCommand.Parameters.Add("@nroSerie", SqlDbType.VarChar, 50, "nroSerie");
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cambia el gif de desechar según el parametro.
        /// </summary>
        /// <param name="path">Nombre del archivo del gif.</param>
        private void EjecutarDesechar()
        {
            do
            {
                if(this.desecharFlag == 1)
                {
                    for (int i = 1; i < 13; i++) //Secuencia de 12 imágenes
                    {
                        this.eventoImagen.Invoke(this.pBBasura, $"correcto{i}.png");
                        Thread.Sleep(80);
                    }
                    this.desecharFlag = 0;
                }
                else
                {
                    if(this.desecharFlag == 2)
                    {
                        for (int i = 1; i < 13; i++) //Secuencia de 12 imágenes
                        {
                            this.eventoImagen.Invoke(this.pBBasura, $"error{i}.png");
                            Thread.Sleep(60);
                        }
                        this.desecharFlag = 0;
                    }
                    else
                    {
                        for (int i = 1; i < 10; i++) //Secuencia de 9 imágenes
                        {
                            this.eventoImagen.Invoke(this.pBBasura, $"basura{i}.png");
                            Thread.Sleep(100);
                        }
                    }
                }

            }while(true);
        }

        /// <summary>
        /// Cambia la ruta de la imagen/gif del PictureBox.
        /// </summary>
        /// <param name="pB">PictureBox a ser cambiado.</param>
        /// <param name="path">Nombre del archivo de la imagen/gif.</param>
        private void MostrarImagen(PictureBox pB, string path)
        {
            pB.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + $@"\img\{path}";
        }

        /// <summary>
        /// Ejecuta una secuencia de tres imagenes que cambian continuamente.
        /// </summary>
        private void EjecutarPerifericos()
        {
            do
            {
                this.eventoImagen.Invoke(this.pBPerifericos, "mouse.png");  //Invoca al evento
                Thread.Sleep(2500);
                this.eventoImagen.Invoke(this.pBPerifericos, "teclado.png");
                Thread.Sleep(2500);
                this.eventoImagen.Invoke(this.pBPerifericos, "auricular.png");
                Thread.Sleep(2500);
           
            } while (true);
        }

        #endregion
    }
}
