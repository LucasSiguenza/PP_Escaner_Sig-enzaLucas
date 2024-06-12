using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum Paso
    {
        Inicio,
        Distribuido,
        EnEscaner,
        EnRevision,
        Terminado
    }
    public enum Departamento
    {
        nulo,
        mapoteca,
        procesosTecnicos
    }
    
    public enum TipoDoc
    { libro, mapa }
}
