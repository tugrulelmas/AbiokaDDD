using System;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.DTOs
{
    public class ListDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CardDTO> Cards { get; set; }
    }
}
