using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysBurger
{
    public partial class frm_Login : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                BDUsuario obj_BDUsuario = new BDUsuario();
                Usuario obj_Usuario = new Usuario();

                obj_Usuario.Unm_Usuario = tbox_Unm_Usuario.Text;

                obj_Usuario = obj_BDUsuario.FindByUnmUsuario(obj_Usuario);

                if (obj_Usuario == null)
                {
                    MessageBox.Show("Nome do Usuário não encontrado.", "ENTRADA INVÁLIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbox_Unm_Usuario.Focus();
                }
                else
                {
                    if (obj_FuncGeral.Criptografa(tbox_Sen_Usuario.Text) == obj_Usuario.Sen_Usuario)
                    {
                        frm_Principal obj_frm_Principal = new frm_Principal();
                        obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario.Cod_Usuario.ToString() + " fez login.");
                        obj_frm_Principal.obj_Usuario_Logado = obj_Usuario;
                        obj_frm_Principal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Senha não encontrada.", "ENTRADA INVÁLIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbox_Sen_Usuario.Focus();
                    }
                }
            }

        }
    }
}
