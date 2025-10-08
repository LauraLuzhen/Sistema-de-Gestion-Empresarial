using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundo
{
    public partial class _Default : Page
    {
        string nombre = txtNombre.Text.Trim();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullorEmpty(nombre))
            {
                lblSaludo.Text = "ERROR";
            }
            else
            {
                lblSaludo.Text = "Hola, " + txtNombre.Text + "!";
            }
        }
    }
}