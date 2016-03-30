using System;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.DTOs
{
    public class CardDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<CommentDTO> Comments { get; set; }

        public IEnumerable<LabelDTO> Labels { get; set; }
    }
}
