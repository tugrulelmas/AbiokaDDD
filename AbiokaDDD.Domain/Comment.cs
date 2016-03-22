using AbiokaDDD.Infrastructure.Common.Domain;
using System;

namespace AbiokaDDD.Domain
{
    public class Comment : IdEntity<Guid>
    {
        public string Text { get; set; }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
