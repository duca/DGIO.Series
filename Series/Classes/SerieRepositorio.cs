using System;
using System.Collections.Generic;
using System.Text;

using Series.Interfaces;

namespace Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>();

        public SerieRepositorio ()
        {
            this.ListaSerie = new List<Serie>();
        }

        public SerieRepositorio(List<Serie> listaSerie)
        {
            this.ListaSerie = listaSerie;
        }

        public void Atualiza(int id, Serie entidade)
        {
            this.ListaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            this.ListaSerie[id].Excluir();
        }

        public void Insere(Serie entidade)
        {
            this.ListaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return this.ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if (!this.ListaSerie[id].GetExcluido())
                return this.ListaSerie[id];
            else
                throw new ArgumentException();
        }
    }
}
