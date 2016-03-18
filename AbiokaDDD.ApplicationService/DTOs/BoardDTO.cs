using System;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.DTOs
{
    public class BoardDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ListDTO> Lists { get; set; }
    }
}
