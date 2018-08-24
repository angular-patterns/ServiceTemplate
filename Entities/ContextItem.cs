using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ContextItem
    {
        public int ContextItemId { get; set; }

        [ForeignKey("Context")]
        public int ContextId { get; set; }

        public string Key { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        public string JsonValue { get; set; }


    }
}
