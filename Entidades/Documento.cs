using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Entidades
{
    public abstract class Documento
    {
        protected int anio;
        protected string autor;
        protected string barcode;
        protected string numNormalizado;
        protected string titulo;
        protected Paso estado;

        public int Anio
        {
            get => this.anio;
            private set => this.anio = value;
        }
        public string Autor
        {
            get => this.autor;
            private set => this.autor = value;
        }
        public string Titulo
        {
            get => this.titulo;
            private set => this.titulo = value;
        }
        protected string NumNormalizado
        {
            get => this.numNormalizado;
            private set => this.numNormalizado = value;
        }
        public string Barcode
        {
            get => this.barcode;
            private set => this.barcode = value;
        }

        public Paso Estado 
        {
            get => this.estado;
            private set { 
                if (this.estado != Paso.Inicio) 
                {
                    this.estado = value;
                } 
                this.estado = Paso.Inicio;
            } 
        }

        protected Documento (string titulo, string autor, int anio, string barcode)
        {
            this.autor = autor;
            this.titulo = titulo;
            this.anio = anio;
            this.barcode = barcode;
            this.numNormalizado = "";
        }
        protected Documento(string titulo, string autor, int anio, string barcode, string numNormalizado):
            this(titulo,autor,anio, barcode) 
        { this.numNormalizado = numNormalizado; }

        public bool AvanzarEstado()
        {
            if (this.estado == Paso.Terminado)
            { return false; }
            this.estado = this.estado++;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Titulo: {Titulo.ToUpper()}" +
                $"Autor: {Autor.ToUpper()}" +
                $"Año: {Anio}" +
                $"Cód. de barras: {Barcode}" +
                $"Estado: {Estado}\n");
            return sb.ToString();
        }


    }
}
