﻿using System.Collections.Generic;

namespace AbiokaDDD.Repository.MongoDB.DatabaseObjects
{
    internal class ListMongoDB : MongoValueObject
    {
        public string Name { get; set; }

        public List<CardMongoDB> Cards { get; set; }

        public override void SetDefault() {
            base.SetDefault();

            if (Cards == null)
                return;
            foreach (var cardItem in Cards)
            {
                cardItem.SetDefault();
            }
        }
    }
}
