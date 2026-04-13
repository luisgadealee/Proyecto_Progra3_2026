using Sistema_Alquiler_Vehiculos.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Alquiler_Vehiculos.Forms
{
    public partial class FrmPrincipalAdministrador : Form
    {

        private readonly Usuarios _usuarioActivo;

        public FrmPrincipalAdministrador(Usuarios usuarioActivo)
        {
            InitializeComponent();
            _usuarioActivo = usuarioActivo;
        }

        private void FrmPrincipalAdministrador_Load(object sender, EventArgs e)
        {

        }
    }
}
