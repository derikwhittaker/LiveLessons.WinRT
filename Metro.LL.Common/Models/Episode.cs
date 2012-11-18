using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.LL.Common.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Released { get; set; }

        public IList<Tag> Tags { get; set; }

    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
