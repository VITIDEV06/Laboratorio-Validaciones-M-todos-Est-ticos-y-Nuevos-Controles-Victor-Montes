using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace EjemploGrid
{
    public partial class Form1 : Form
    {
        //ArrayList para almacenar los objetos Persona
        //ArrayList pertenece al espacio de nombres System.Collections

        ArrayList listaPersonas = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona miColaborador1 = new Persona();

            miColaborador1.Id = 1;
            miColaborador1.Nombres = "Elena Carolina";
            miColaborador1.Apellidos = "González Rodríguez";
            miColaborador1.Correo = "elena.gonzalez@ejemplo.com";
            miColaborador1.FechaNacimiento = new DateTime(1990, 5, 15);
            listaPersonas.Add(miColaborador1);
            dgvDatos.DataSource = listaPersonas;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            if (txtIDEmpleado.Text == "")
            {
                errorProvider1.SetError(txtIDEmpleado, "Ingrese un ID");
                txtIDEmpleado.Focus();
                return; // <-- Interrumpe y finaliza la ejecución del método actual
            }
            else
            {
                errorProvider1.SetError(txtIDEmpleado, "");
            }


            if (txtNombres.Text == "")
            {
                errorProvider1.SetError(txtNombres, "Ingrese los nombres del Colaborador");
                txtNombres.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtNombres, "");
            }


            if (txtApellidos.Text == "")
            {
                errorProvider1.SetError(txtApellidos, "Ingrese los apellidos del Colaborador");
                txtApellidos.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtApellidos, "");
            }


            if (Utilidades.EsCorreoValido(txtEmail.Text) == false)
            {
                errorProvider1.SetError(txtEmail, "Ingrese un correo válido");
                txtEmail.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }


            decimal salario1;
            if (!decimal.TryParse(txtSalario.Text, out salario1))
            {
                errorProvider1.SetError(txtSalario, "Ingrese un salario válido");
                txtSalario.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtSalario, "");
            }


            Persona colaborador1 = new Persona();
            colaborador1.Id = int.Parse(txtIDEmpleado.Text);
            colaborador1.Nombres = txtNombres.Text;
            colaborador1.Apellidos = txtApellidos.Text;
            colaborador1.Correo = txtEmail.Text;
            colaborador1.Salario = salario1;
            colaborador1.FechaNacimiento = dtpFechaNacimiento.Value;
            listaPersonas.Add(colaborador1);
            dgvDatos.DataSource = null; // Limpiar el DataSource antes de asignar la nueva lista
            dgvDatos.DataSource = listaPersonas;
        }

        private void tsbLimpiar_Click(object sender, EventArgs e)
        {
            txtIDEmpleado.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtSalario.Clear();

            // Limpiar mensajes del ErrorProvider
            errorProvider1.Clear();

            // Regresar el foco al primer TextBox
            txtIDEmpleado.Focus();
        }
    }
}
