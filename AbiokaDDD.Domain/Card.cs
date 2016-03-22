using AbiokaDDD.Infrastructure.Common.Domain;
using System;

namespace AbiokaDDD.Domain
{
    public class Card : IdEntity<Guid>
    {
        public string Title { get; set; }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
