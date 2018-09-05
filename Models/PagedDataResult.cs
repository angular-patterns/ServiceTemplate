using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PagedDataResult<T>
    {
        public T[] Data { get; set; }
        public int Total { get; set; }
    }
}
