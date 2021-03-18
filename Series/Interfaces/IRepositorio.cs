using System;
using System.Collections.Generic;
using System.Text;

namespace Series.Interfaces
{
    interface IRepositorio <T>
    {
        void Atualiza(int id, T entidade);
        void Excluir(int id);
        void Insere(T entidade);
        List<T> Lista();
        int ProximoId();
        T RetornaPorId(int id);


    }
}
