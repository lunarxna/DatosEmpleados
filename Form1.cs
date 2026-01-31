using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DatosEmpleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidarCampos()
        {
            
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
       private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo de texto (*.txt)|*.txt";
            saveDialog.Title = "Guardar Datos del Empleado";
            saveDialog.FileName = "Empleado_" + txtID.Text; 

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        
                        writer.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-15} | {4,-10}", "ID", "NOMBRE", "APELLIDOS", "CARGO", "SALARIO");
                        writer.WriteLine(new string('-', 85)); 

                       
                        writer.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-15} | {4,-10}",
                            txtID.Text,
                            txtNombre.Text,
                            txtApellido.Text,
                            txtCargo.Text,
                            txtSalario.Text);

                       
                    }
                    MessageBox.Show("Archivo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            
        }
    }

      
    private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Archivos de texto (*.txt)|*.txt";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
              
                System.Diagnostics.Process.Start("notepad.exe", openDialog.FileName);
            }
        
    }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea salir de la aplicación?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtCargo.Clear();
            txtSalario.Clear();
            txtTelefono.Clear();

            if (cmbGenero.Items.Count > 0)
                cmbGenero.SelectedIndex = 0;

            dtpFechaIngreso.Value = DateTime.Now;

           
            txtID.Focus();
        }

        private void cmbGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
