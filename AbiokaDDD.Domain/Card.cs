﻿using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Domain
{
    public class Card : IdEntity<Guid>
    {
        public string Title { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Label> Labels { get; set; }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
