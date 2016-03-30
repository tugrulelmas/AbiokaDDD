using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Domain
{
    public class Label : IdEntity<Guid>
    {
        public string Name { get; set; }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
