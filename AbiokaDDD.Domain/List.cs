using AbiokaDDD.Infrastructure.Common.Domain;
using System;

namespace AbiokaDDD.Domain
{
    public class List : IdEntity<Guid>
    {
        public string Name { get; set; }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
