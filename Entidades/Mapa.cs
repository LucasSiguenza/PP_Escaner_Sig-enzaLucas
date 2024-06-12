using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        int alto;
        int ancho;
        int superficie;
        
        public int Alto
        {
            get => alto;
            private set => this.alto = value;
        }
        public int Ancho
        {
            get => ancho;
            private set => this.ancho = value;
        }
        public int Superficie
        {
            get => superficie = ancho*alto;
        }

        public Mapa(string titulo, string autor, int anio,string barcode, int alto, int ancho):
            base(titulo, autor, anio, barcode)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public override int GetHashCode()
        {
            return (Titulo, Autor, Barcode, Anio, Superficie).GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Mapa mapa)
            { return this == mapa; }
            return false;
        }
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return (m1.barcode == m2.barcode ||
                (m1.titulo == m2.titulo &&
                m1.autor == m2.autor &&
                m1.anio == m2.anio &&
                m1.superficie == m2.superficie));
        }

        public static bool operator !=(Mapa m1, Mapa m2) 
        { return !(m1 == m2); }

        public override string ToString()
        {
            var texto = new StringBuilder(base.ToString());
            texto.AppendLine($"Ancho: {Ancho}.\n" +
                $"Alto: {Alto}.\n" +
                $"Superficie: {Ancho} * {Alto} = {Superficie}cm2.");
            return texto.ToString();
        }



    }
}
