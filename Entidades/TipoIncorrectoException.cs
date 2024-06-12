using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoIncorrectoException : Exception
    {
        string nombreClase;
        string nombreMetodo;

        public string NombreClase
        { get => this.nombreClase; private set => this.nombreClase = value; }
        public string NombreMetodo
        { get => this.nombreMetodo; private set => this.nombreMetodo = value;}

        public TipoIncorrectoException(string mensaje, string clase, string metodo) :
            base(mensaje)
        {
            this.nombreClase = clase;
            this.nombreMetodo = metodo;
        }
        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo, Exception innerException)
            : base(mensaje, innerException)
        {
            this.nombreClase = nombreClase;
            this.nombreMetodo = nombreMetodo;
        }

        public override string ToString()
        {
            return $"Excepcion en el método {NombreMetodo.ToUpper()} de la clase{NombreClase.ToUpper()}\n" +
                $"Mensaje: {Message}\n" +
                $"Detalles: {InnerException?.Message}";
        }
    }
}
