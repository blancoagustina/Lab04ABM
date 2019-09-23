using Negocio;
using System;


public partial class ListaUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.cargarDrpFechaNacDia();
            if (PaginaEnEstadoEdicion())
            {
                CargarDatosUsuario();
            }
            else
            {
                this.lblAccion.Text = "Alta de usuario";
            }
        }
       
    }

    private bool PaginaEnEstadoEdicion()
    {
        if (this.Request.QueryString["id"] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CargarDatosUsuario()
    {
        Usuario usuario = new ManagerUsuarios().GetOne(int.Parse(Request.QueryString["id"]));

        this.lblAccion.Text = "Edicion de usuario " + usuario.Id;
        this.txtApellido.Text = usuario.Apellido;
        this.txtNombre.Text = usuario.Nombre;
        this.rblTipoDoc.SelectedValue=usuario.TipoDoc.ToString();
        this.txtNroDoc.Text = usuario.NroDoc.ToString();

        string[] fecha = usuario.FechaNac.Split('/');
        this.drpFechaNacDia.SelectedValue = fecha[0];
        this.drpFechaNacMes.SelectedValue = fecha[1];
        this.txtFechaNacAnio.Text = fecha[2].Split(' ')[0];
        this.txtDireccion.Text = usuario.Direccion;
        this.txtTelefono.Text = usuario.Telefono;
        this.txtEmail.Text = usuario.Email;
        this.txtCelular.Text = usuario.Celular;
        this.txtNombreUsuario.Text = usuario.NombreUsuario;
        this.txtClave.Text = usuario.Clave;
        this.txtConfirmarClave.Text = usuario.Clave;
    }

    private void cargarDrpFechaNacDia()
    {
        this.drpFechaNacDia.Items.Add("-1");
        this.drpFechaNacDia.Items[0].Text = "Seleccione un dia";
        this.drpFechaNacDia.Items[0].Value = "-1";

        for (int i = 1; i < 10; i++)
        {
            this.drpFechaNacDia.Items.Add("0"+i);
            this.drpFechaNacDia.Items[i].Text = "0"+i;
            this.drpFechaNacDia.Items[i].Value = "0"+i;
        }
        for (int i = 10; i <= 31; i++)
        {
            this.drpFechaNacDia.Items.Add(i+"");
            this.drpFechaNacDia.Items[i].Text = i+"";
            this.drpFechaNacDia.Items[i].Value = i+"";
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();

        usuario.Apellido = this.txtApellido.Text;
        usuario.Nombre = this.txtNombre.Text;
        usuario.TipoDoc = int.Parse(this.rblTipoDoc.SelectedValue);
        usuario.NroDoc = int.Parse(this.txtNroDoc.Text);

        usuario.FechaNac = this.drpFechaNacDia.SelectedValue+"/";
        usuario.FechaNac = usuario.FechaNac + this.drpFechaNacMes.SelectedValue+"/";
        usuario.FechaNac = usuario.FechaNac + this.txtFechaNacAnio.Text;
        usuario.Direccion = this.txtDireccion.Text;
        usuario.Telefono = this.txtTelefono.Text;
        usuario.Email = this.txtEmail.Text;
        usuario.Celular = this.txtCelular.Text;
        usuario.NombreUsuario = this.txtNombreUsuario.Text;
        usuario.Clave = this.txtClave.Text;

        ManagerUsuarios mu = new ManagerUsuarios();
        if (PaginaEnEstadoEdicion())
        {
            usuario.Id = int.Parse(Request.QueryString["id"]);
            mu.ActualizarUsuario(usuario);
        }
        else
        {
            mu.AgregarUsuario(usuario);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaUsuarios.aspx");
    }
}