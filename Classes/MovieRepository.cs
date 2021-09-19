using System.Collections.Generic;

namespace DIO.Series
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> movies = new List<Movie>();
        public void Update(int id, Movie objeto)
        {
            movies[id] = objeto;
        }

        public void Delete(int id)
        {
            movies[id].Delete();
        }

        public void Insert(Movie entidade)
        {
            movies.Add(entidade);
        }

        public List<Movie> List()
        {
            return movies;
        }

        public int NextId()
        {
            return movies.Count;
        }

        public Movie GetById(int id)
        {
            return movies[id];
        }
    }
}