using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        public static void MostrarDistribuidos(Escaner e, out int cantidad, out string resumen)
        {
            MostrarEstado(e, Paso.Distribuido, out cantidad, out resumen);
        }

        public static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int cantidad, out string resumen)
        {
            MostrarEstado(e, estado, out cantidad, out resumen);
        }

        private static void MostrarEstado(Escaner e, Paso estado, out int cantidad, out string resumen)
        {
            var documentosEnEstado = e.ListaDocumentos.Where(d => d.Estado == estado).ToList();
            cantidad = documentosEnEstado.Count;

            StringBuilder sb = new StringBuilder();
            foreach (var doc in documentosEnEstado)
            {
                sb.AppendLine(doc.ToString());
            }
            resumen = sb.ToString();
        }

        public static void MostrarEnEscaner(Escaner e, out int cantidad, out string resumen)
        {
            MostrarEstado(e, Paso.EnEscaner, out cantidad, out resumen);
        }

        public static void MostrarEnRevision(Escaner e, out int cantidad, out string resumen)
        {
            MostrarEstado(e, Paso.EnRevision, out cantidad, out resumen);
        }

        public static void MostrarTerminados(Escaner e, out int cantidad, out string resumen)
        {
            MostrarEstado(e, Paso.Terminado, out cantidad, out resumen);
        }
    }
}
