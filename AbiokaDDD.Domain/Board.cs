﻿using AbiokaDDD.Infrastructure.Common.Domain;
using System;
using System.Collections.Generic;

namespace AbiokaDDD.Domain
{
    public class Board : IdEntity<Guid>
    {
        public string Name { get; set; }

        public IEnumerable<List> Lists { get; set; }

        public override void Validate() {
            throw new NotImplementedException();
        }
    }
}
