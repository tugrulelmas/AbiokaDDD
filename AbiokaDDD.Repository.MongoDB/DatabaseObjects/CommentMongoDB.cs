using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal class CommentMongoDB : MongoValueObject
    {
        public Guid CardId { get; set; }

        public string Text { get; set; }
    }
}
