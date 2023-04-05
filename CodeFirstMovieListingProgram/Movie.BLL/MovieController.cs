using Movie.DAL.Entity;
using Movie.Model.Models;
using Movies.Model.Models;
using System.Text;

namespace Movie.BLL
{
    public static class MovieController
    {

        private static MoviesEntities _context = new MoviesEntities();

        public static List<Film> Films { get; set; } = _context.Films.ToList();
        public static List<Category> Categories { get; set; } = _context.Categories.ToList();
        public static List<FilmCategory> FilmCategories { get; set; } = _context.FilmCategories.ToList();

        public static List<Film> GetSearchedFilms(string searchingWord, int value)
        {
            
            foreach (Film film in Films)
            {
                foreach (FilmCategory item in FilmCategories)
                {
                    foreach (Category category in Categories)
                    {
                        if (film.Name.Contains(searchingWord) && category.CategoryID == value && item.FilmID == film.FilmID)
                        {
                            Films.Add(film);
                        }
                    }
                }
            }
            return Films;
        }
        public static List<Film> GetFilms()
        {
            return _context.Films.ToList();
        }
        public static List<string> GetCategories()
        {
            return _context.Categories.Select(cn => cn.Name).ToList();
        }
        public static void RefreshList()
        {
            _context.Films.ToList();
        }
        public static void GetFilmsByCategory(int categoryIndex)
        {
            _context.Films.Where(c => c.CategoryID == categoryIndex);
        }

    }
}