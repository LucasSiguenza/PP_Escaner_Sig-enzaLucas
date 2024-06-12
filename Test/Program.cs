

namespace Test
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Escaner escanerLibros = new Escaner("Epson", TipoDoc.Libro);
                Escaner escanerMapas = new Escaner("Canon", TipoDoc.Mapa);

                Libro libro = new Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "123456", "978-3-16-148410-0", 417);
                Mapa mapa = new Mapa("Mapa de Colombia", "IGN", 2020, "654321", 100, 150);

                // Intentar agregar un libro al escáner de mapas
                escanerMapas += libro;
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                Escaner escanerLibros = new Escaner("Epson", TipoDoc.Libro);
                Libro libro = new Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "123456", "978-3-16-148410-0", 417);

                // Agregar el libro al escáner de libros
                escanerLibros += libro;

                // Mostrar documentos distribuidos
                Informes.MostrarDistribuidos(escanerLibros, out int cantidad, out string resumen);
                Console.WriteLine($"Documentos distribuidos: {cantidad}");
                Console.WriteLine(resumen);

                // Cambiar estado del libro a EnEscaner
                escanerLibros.CambiarEstadoDocumento(libro);

                // Mostrar documentos en el escáner
                Informes.MostrarEnEscaner(escanerLibros, out cantidad, out resumen);
                Console.WriteLine($"Documentos en el escáner: {cantidad}");
                Console.WriteLine(resumen);

                // Cambiar estado del libro a EnRevision
                escanerLibros.CambiarEstadoDocumento(libro);

                // Mostrar documentos en revisión
                Informes.MostrarEnRevision(escanerLibros, out cantidad, out resumen);
                Console.WriteLine($"Documentos en revisión: {cantidad}");
                Console.WriteLine(resumen);

                // Cambiar estado del libro a Terminado
                escanerLibros.CambiarEstadoDocumento(libro);

                // Mostrar documentos terminados
                Informes.MostrarTerminados(escanerLibros, out cantidad, out resumen);
                Console.WriteLine($"Documentos terminados: {cantidad}");
                Console.WriteLine(resumen);
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex);
            }
        }
    
    }
}
