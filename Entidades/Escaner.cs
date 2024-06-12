using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        Departamento locacion;
        TipoDoc tipo;
        string marca;

        public List<Documento> ListaDocumentos
        {
            get=> listaDocumentos;
            private set=> listaDocumentos = value;
        }
        public Departamento Locacion
        {
            get => this.locacion;
            private set => this.locacion = value;
        }
        public TipoDoc Tipo
        {
            get => this.tipo;
            private set => this.tipo = value;
        }
        public string Marca
        {
            get => this.marca;
            private set => this.marca = value;
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();
        }

        public bool CambiarEstadoDocumento(Documento d)
        {
            foreach(var doc in listaDocumentos) 
            {
                if (doc.Barcode == d.Barcode)
                { return doc.AvanzarEstado(); } 
            }
            return false;
        }
        public static bool operator==(Escaner e, Documento d)
        {
            if ((e.tipo == TipoDoc.libro && d is Mapa)||(e.tipo == TipoDoc.mapa && d is Libro))
            {
                throw new TipoIncorrectoException("El documento ya existe en la lista.",nameof(Escaner), MethodBase.GetCurrentMethod().Name );
            }
            return e.ListaDocumentos.Exists(doc => doc.Barcode == d.Barcode);
        }
        public static bool operator!=(Escaner e, Documento d)
        { return !(e == d); }
        
        public static Escaner operator+(Escaner e, Documento d)
        {
            try 
            {
                if(e==d)
                {
                    throw new TipoIncorrectoException("El documento ya existe en la lista.", nameof(Escaner), MethodBase.GetCurrentMethod().Name);

                }
                if (d.Estado != Paso.Inicio)
                {
                    throw new TipoIncorrectoException("El documento no está en estado 'Inicio'.", nameof(Escaner), MethodBase.GetCurrentMethod().Name);
                }

                d.AvanzarEstado();
                e.ListaDocumentos.Add(d);
            }
            catch (TipoIncorrectoException ex) 
            {
                throw new TipoIncorrectoException("El documento no se pudo añadir a la lista.",nameof(Escaner), MethodBase.GetCurrentMethod().Name, ex);
            }

            return e;
        }
        public override bool Equals(object obj)
        {
            if (obj is Escaner escaner)
            {
                return this.Marca == escaner.Marca && this.Tipo == escaner.Tipo;
            }
            return false;
        }

        public override int GetHashCode()
            {
                return HashCode.Combine(Marca, Tipo);
            }
    }
}
