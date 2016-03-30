using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal class ListMongoDB : MongoValueObject
    {
        public string Name { get; set; }

        public IEnumerable<CardMongoDB> Cards { get; set; }

        public IEnumerable<CommentMongoDB> Comments { get; set; }

        public IEnumerable<LabelMongoDB> Labels { get; set; }

        public override void SetDefault() {
            base.SetDefault();

            if (Cards == null)
                return;

            foreach (var cardItem in Cards)
            {
                cardItem.SetDefault();
            }

            if (Comments == null)
                return;

            foreach (var commentItem in Comments)
            {
                commentItem.SetDefault();
            }
        }
    }
}
