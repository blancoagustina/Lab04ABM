using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        public int Id
        {
            get; set;
        }
        public Nullable<int> TipoDoc
        {
            get; set;
        }
        public Nullable<int> NroDoc
        {
            get; set;
        }
        public string FechaNac
        {
            get; set;
        }
        public string Apellido
        {
            get; set;
        }
        public string Nombre
        {
            get; set;
        }
        public string Direccion
        {
            get; set;
        }
        public string Telefono
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public string Celular
        {
            get; set;
        }
        public string NombreUsuario
        {
            get; set;
        }
        public string Clave
        {
            get; set;
        }


    }
}
