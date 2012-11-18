using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metro.LL.Common.Models;

namespace Metro.LL.Common.Repositories
{
    public class EpisodeRepository
    {
        private static IList<Episode> _episodes; 

        public EpisodeRepository()
        {
            if (_episodes == null )
            {
                _episodes = new TestDataLoader().LoadTestData();
            }
        }

        public IList<Episode> Episodes()
        {
            return _episodes;
        }

        public IList<Episode> Search(string keyword)
        {
            var asLower = keyword.ToLower();

            var results = _episodes.Where(x => x.Name.ToLower().Contains(asLower)).ToList();
            
            return results;
        }
    }
}
