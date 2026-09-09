using DC_Plus.Exceptions;
using DC_Plus.Models;

namespace DC_Plus
{
    // Service réteg: üzleti logikát végzi
    internal class ContentService
    {
        private List<Content> contents;

        public ContentService(List<Content> contents)
        {
            this.contents = contents;
        }

        public Content GetById(int id)
        {
            if (contents.All(c => c.Id != id)) throw new ContentNotFoundException();
            return contents.First(c => c.Id == id);
        }

        public List<Content> SearchByTitle(string search)
        {
            return contents.Where(c => c.Title.ToLower().Contains(search.ToLower())).ToList();
        }

        public List<Film> GetFilms()
        {
            //return contents.Where(c => c is Film).Select(c => c as Film).ToList()!;
            //return contents.Where(c => c is Film).Select(c => (Film)c).ToList();
            //return contents.Where(c => c is Film).Cast<Film>().ToList();
            return contents.OfType<Film>().ToList();
        }
    }
}
