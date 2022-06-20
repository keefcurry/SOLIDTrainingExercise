using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    public class WorkArea
    {
        public int? Id { get; internal set; }
        public string Name { get; set; }
        public string WorkAreaCode { get; set; }
        public bool HasRule { get; set; }
    }
}
