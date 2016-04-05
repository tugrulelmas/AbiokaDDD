using AbiokaDDD.Domain;
using AbiokaDDD.Infrastructure.Common;
using AbiokaDDD.Infrastructure.Common.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    [BsonIgnoreExtraElements]
    internal class UserMongoDB : MongoEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ProviderToken { get; set; }

        public string AuthProvider { get; set; }

        public string Token { get; set; }

        public string ImageUrl { get; set; }

        public string Password { get; set; }

        public string Initials { get; set; }

        public override void CopyToDomainObject(IEntity entity) {
            if (entity == null)
                entity = new User();

            var user = (User)entity;
            user.Id = this.Id;
            user.Name = this.Name;
            user.Email = this.Email;
            user.ProviderToken = this.ProviderToken;
            user.AuthProvider = Util.EnumParse<AuthProvider>(this.AuthProvider.ToString());
            user.Token = this.Token;
            user.ImageUrl = this.ImageUrl;
            user.Password = this.Password;
            user.Initials = this.Initials;
        }

        public override void SetDefault() {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }
    }
}
