using UrlShortener.Data;
using UrlShortener.Entities;
using UrlShortener.Models.Dto;


namespace UrlShortener.Services
{
    public class UserServices
    {
        private readonly UrlShortenerContext _context;
        public UserServices(UrlShortenerContext context)
        {
            _context = context;
        }

        public User? GetByUserName(string Name)
        {
            return _context.Users.SingleOrDefault(u => u.Name == Name);
        }

        public bool ValidateCredentials(string Name, string password)
        {
            User? UserForLoggin = GetByUserName(Name);
            if (UserForLoggin != null)
            {
                if (UserForLoggin.Password != password)
                    return true;
            }
            return false;

        }

        public User? ValidateUser(AuthenticationDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Name == authRequestBody.Name && p.Password == authRequestBody.Password);
        }

    }
}
