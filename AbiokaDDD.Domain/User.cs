using AbiokaDDD.Infrastructure.Common;
using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Linq;

namespace AbiokaDDD.Domain
{
    public class User : IdEntity<Guid>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ProviderToken { get; set; }

        public AuthProvider AuthProvider { get; set; }

        public string Token { get; set; }

        public string ImageUrl { get; set; }

        public string Password { get; set; }

        public string Initials { get; set; }

        public string GetHashedPassword() {
            var hashedPassword = Util.GetHashText(string.Concat(Email.ToLowerInvariant(), "#", Password));
            return hashedPassword;
        }

        public string GetInitials() {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException("Name");

            string[] names = Name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length < 2)
                return names.First();

            var result = $"{names.First().First().ToString().ToUpper()}{names.Last().First().ToString().ToUpper()}";
            return result;
        }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
