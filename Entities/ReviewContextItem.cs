using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ReviewContextItem
    {
        public int ReviewContextItemId { get; set; }

        [ForeignKey("ReviewContext")]
        public int ReviewContextId { get; set; }

        [ForeignKey("ContextItem")]
        public int ContextItemId { get; set; }

        public string Key { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        public string JsonValue { get; set; }
    }
}
