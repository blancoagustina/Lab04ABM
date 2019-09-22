using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class ManagerUsuarios
    {
        protected SqlConnection Conn
        {
            get;set;
        }

        public ManagerUsuarios()
        {
            this.Conn = new SqlConnection("Data Source = localhost; Initial Catalog = academia; Integrated Security = true;");
        }

        public List<Usuario> GetAll()
        {
            
            List<Usuario> listaUsuarios = new List<Usuario>();
            
            Usuario usuarioActual;
            
            SqlCommand cmdGetUsuarios = new SqlCommand("select * from usuarios", this.Conn);
            
            this.Conn.Open();
            
            SqlDataReader rdrUsuarios = cmdGetUsuarios.ExecuteReader();
            
            while (rdrUsuarios.Read())
            {
                usuarioActual = new Usuario();
                usuarioActual.Id = (int)rdrUsuarios["id"];
                usuarioActual.TipoDoc = (Nullable<int>)rdrUsuarios["tipo_doc"];
                usuarioActual.NroDoc = (Nullable<int>)rdrUsuarios["nro_doc"];
                usuarioActual.FechaNac = rdrUsuarios["fecha_nac"].ToString();
                usuarioActual.Apellido = rdrUsuarios["apellido"].ToString();
                usuarioActual.Nombre = rdrUsuarios["nombre"].ToString();
                usuarioActual.Direccion = rdrUsuarios["direccion"].ToString();
                usuarioActual.Telefono = rdrUsuarios["telefono"].ToString();
                usuarioActual.Email = rdrUsuarios["email"].ToString();
                usuarioActual.Celular = rdrUsuarios["celular"].ToString();
                usuarioActual.NombreUsuario = rdrUsuarios["usuario"].ToString();
                usuarioActual.Clave = rdrUsuarios["clave"].ToString();
                
                listaUsuarios.Add(usuarioActual);

            }
            
            this.Conn.Close();
            
            return listaUsuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usuarioActual=null;

            SqlCommand cmdGetUsuarios = new SqlCommand("select * from usuarios where id=@id", this.Conn);
            cmdGetUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;

            this.Conn.Open();

            SqlDataReader rdrUsuarios = cmdGetUsuarios.ExecuteReader();

            if (rdrUsuarios!=null && rdrUsuarios.Read())
            {
                usuarioActual = new Usuario();
                usuarioActual.Id = (int)rdrUsuarios["id"];
                usuarioActual.TipoDoc = (Nullable<int>)rdrUsuarios["tipo_doc"];
                usuarioActual.NroDoc = (Nullable<int>)rdrUsuarios["nro_doc"];
                usuarioActual.FechaNac = rdrUsuarios["fecha_nac"].ToString();
                usuarioActual.Apellido = rdrUsuarios["apellido"].ToString();
                usuarioActual.Nombre = rdrUsuarios["nombre"].ToString();
                usuarioActual.Direccion = rdrUsuarios["direccion"].ToString();
                usuarioActual.Telefono = rdrUsuarios["telefono"].ToString();
                usuarioActual.Email = rdrUsuarios["email"].ToString();
                usuarioActual.Celular = rdrUsuarios["celular"].ToString();
                usuarioActual.NombreUsuario = rdrUsuarios["usuario"].ToString();
                usuarioActual.Clave = rdrUsuarios["clave"].ToString();
            }

            this.Conn.Close();

            return usuarioActual;
        }

        public void BorrarUsuario(Usuario usuarioActual)
        {
            SqlCommand cmdDeleteUsuario = new SqlCommand(" DELETE FROM usuarios WHERE id=@id ", this.Conn);

            cmdDeleteUsuario.Parameters.Add(new SqlParameter("@id", usuarioActual.Id.ToString()));

            this.Conn.Open();

            cmdDeleteUsuario.ExecuteNonQuery();
            
            this.Conn.Close();
        }

        public void ActualizarUsuario(Usuario usuarioActual)
        {
            
            SqlCommand cmdActualizarUsuario = new SqlCommand(" UPDATE usuarios " +
                                               " SET tipo_doc = @tipo_doc, nro_doc = @nro_doc, fecha_nac = @fecha_nac, " +
                                               " apellido = @apellido, nombre = @nombre, direccion = @direccion, " +
                                               " telefono = @telefono, email = @email, celular = @celular, usuario = @usuario, " +
                                               " clave = @clave WHERE id=@id ", this.Conn);
            
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@tipo_doc", usuarioActual.TipoDoc.ToString()));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@nro_doc", usuarioActual.NroDoc.ToString()));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@fecha_nac", usuarioActual.FechaNac));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@apellido", usuarioActual.Apellido));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@nombre", usuarioActual.Nombre));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@direccion", usuarioActual.Direccion));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@telefono", usuarioActual.Telefono));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@email", usuarioActual.Email));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@celular", usuarioActual.Celular));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@usuario", usuarioActual.NombreUsuario));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@clave", usuarioActual.Clave));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@id", usuarioActual.Id.ToString()));
            
            this.Conn.Open();
            
            cmdActualizarUsuario.ExecuteNonQuery();
            
            this.Conn.Close();
        }

        public void AgregarUsuario(Usuario usuarioActual)
        {
           
            SqlCommand cmdInsertarUsuario = new SqlCommand(" INSERT INTO usuarios(tipo_doc,nro_doc,fecha_nac,apellido, " +
                                               " nombre,direccion,telefono,email,celular,usuario,clave) " +
                                               " VALUES (@tipo_doc,@nro_doc,@fecha_nac,@apellido,@nombre,@direccion, " +
                                               " @telefono,@email,@celular, @usuario, @clave  )", this.Conn);
            
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@tipo_doc", usuarioActual.TipoDoc.ToString()));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@nro_doc", usuarioActual.NroDoc.ToString()));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@fecha_nac", usuarioActual.FechaNac));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@apellido", usuarioActual.Apellido));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@nombre", usuarioActual.Nombre));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@direccion", usuarioActual.Direccion));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@telefono", usuarioActual.Telefono));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@email", usuarioActual.Email));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@celular", usuarioActual.Celular));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@usuario", usuarioActual.NombreUsuario));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@clave", usuarioActual.Clave));
            
            this.Conn.Open();
            
            int ID = (int)cmdInsertarUsuario.ExecuteScalar();
            usuarioActual.Id = ID;

            this.Conn.Close();
        }



    }
}
