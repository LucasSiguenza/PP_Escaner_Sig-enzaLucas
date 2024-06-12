using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Entidades
{
    public class Libro : Documento
    {
        int numPaginas;
        public int NumPaginas
        { 
            get => this.numPaginas; 
            private set => this.numPaginas = value; 
        }
        public string ISBN
        { get => numNormalizado; }
        

        public Libro(string titulo, string autor, int anio, string barcode, string numNormalizado, int numPaginas)
            : base(titulo, autor, anio, barcode,numNormalizado)
        {
            this.numPaginas = numPaginas;
        }

        public override int GetHashCode()
        {
            return (Titulo, Autor, Barcode, ISBN).GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Libro libro)
            { return this == libro; }
            return false;
        }
        public static bool operator ==(Libro l1, Libro l2) 
        {
            return l1.barcode == l2.barcode ||
                l1.ISBN == l2.ISBN ||
                (l1.titulo == l2.titulo && l1.autor == l2.autor);
        }

        public static bool operator !=(Libro l1, Libro l2) 
        {
            return !(l1 == l2); 
        }

        public override string ToString()
        {
            var texto = new StringBuilder(base.ToString());
            texto.AppendLine($"Número de Páginas: {NumPaginas}\n" +
                $"ISBN: {this.numNormalizado}\n");
            return texto.ToString();
        }

    }
}
