using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    interface Metodos
    {
        void Insertar(object obj);
        void mostrar(object obj);
        void Editar(object obj);
        void Eliminar(object obj);
        object Buscar(object obj);
    }
}
