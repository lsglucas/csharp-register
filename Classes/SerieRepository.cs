using System.Collections.Generic;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> series = new List<Serie>();
        public void Update(int id, Serie objeto)
        {
            series[id] = objeto;
        }

        public void Delete(int id)
        {
            series[id].Delete();
        }

        public void Insert(Serie entidade)
        {
            series.Add(entidade);
        }

        public List<Serie> List()
        {
            return series;
        }

        public int NextId()
        {
            return series.Count;
        }

        public Serie GetById(int id)
        {
            return series[id];
        }
    }
}