using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void logins() 
        {
            try
            {
                string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cadena)) 
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT NUSUARIO,NCLAVE FROM LIUSUARIO WHERE NUSUARIO='"+ UsuarioTextBox.Text+"' AND NCLAVE='"+ ContrasenaTextBox.Text +"'",conexion)) 
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            MessageBox.Show(" Usuario Exitoso. ");
                        }
                        else 
                        {
                            MessageBox.Show(" Datos Incorrectos. ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void AseptarButton_Click(object sender, EventArgs e)
        {
            logins();
        }
    }
}
