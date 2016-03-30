using System;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal class LabelMongoDB : MongoValueObject
    {
        public string Name { get; set; }

        public Guid CardId { get; set; }
    }
}
