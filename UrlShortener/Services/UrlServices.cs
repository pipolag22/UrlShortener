using static UrlShortener.Entities.Category;
using System.Text;
using UrlShortener.Entities;
using UrlShortener.Data;

namespace UrlShortener.Services
{
    public class UrlServices
    {
        private readonly UrlShortenerContext _context;
        public UrlServices(UrlShortenerContext context)
        {
            _context = context;
        }

        public List<Category> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public string CrearShortUrl(string url)
        {
            // Genera una cadena aleatoria para la URL corta
            StringBuilder shortUrl = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                shortUrl.Append(CharSet[random.Next(CharSet.Length)]);
            }

            return shortUrl.ToString();
        }

        public string GuardarURL(string URLUser, string ShortURL, string? categoria, int IdUser)
        {


            Url URLToCreate = new Url();
            URLToCreate.UrlLong = URLUser;
            URLToCreate.UrlShort = ShortURL;
            URLToCreate.IdUser = IdUser;

            if (categoria != null)
            { URLToCreate.IdCategoria = _context.Categorias.SingleOrDefault(u => u.Name == categoria).Id; }
            else URLToCreate.IdCategoria = 1;



            _context.URLs.Add(URLToCreate);
            Console.WriteLine(URLToCreate.ToString());
            _context.SaveChanges();

            return URLToCreate.ToString();
        }

        public int SumarContador(string URLUser)
        {
            Url URLToCreate = new Url();
            if (URLUser.Length > 6)
                URLToCreate = _context.URLs.SingleOrDefault(u => u.UrlLong == URLUser);
            else { URLToCreate = _context.URLs.SingleOrDefault(u => u.UrlShort == URLUser); }
            URLToCreate.contador++;
            _context.URLs.Update(URLToCreate);
            _context.SaveChanges();

            return URLToCreate.contador;

        }

        public List<string> GetUrlsPorUsuario(int IdUserClient)
        {
            List<string> URLSPorUsuario = _context.URLs.Where(x => x.IdUser == IdUserClient).Select(x => x.UrlLong).ToList();


            return URLSPorUsuario;
        }

        public string GetURLLongForShort(string URLCliente)
        {

            string URLLong = _context.URLs.SingleOrDefault(x => x.UrlShort == URLCliente).UrlLong;


            return URLLong;
        }
        public List<string> GetUrls()
        {
            List<string> todasLasURLS = _context.URLs.Select(x => x.UrlLong).ToList();

            return todasLasURLS;
        }
    }
}
