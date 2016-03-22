using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal class CardMongoDB : MongoValueObject
    {
        public string Title { get; set; }
    }
}
