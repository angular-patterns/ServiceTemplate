using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ResultSetTag
    {
        public int ResultSetTagId { get; set; }

        [ForeignKey("ResultSet")]
        public int ResultSetId { get; set; }

        public string Name { get; set; }

    }
}
