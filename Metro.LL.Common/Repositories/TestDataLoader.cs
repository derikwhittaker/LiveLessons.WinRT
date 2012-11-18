using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metro.LL.Common.Models;

namespace Metro.LL.Common.Repositories
{
    public class TestDataLoader
    {
        public IList<Episode> LoadTestData()
        {
            var episodes = new List<Episode>
            {
                new Episode{Id = 1, Number = 1, Name = "Silverlight - Learning how to use Value Converters", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 2, Number = 2, Name = "Silverlight - Learning how to use Behaviors", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 3, Number = 3, Name = "Postsharp - Working with Advanced Aspects", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 4, Number = 4, Name = "NuGet - Getting Started w/ NuGet", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 5, Number = 5, Name = "WP7 - Creating and Using Associations w/ SQL CE", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 6, Number = 6, Name = "WP7 - Getting Started w/ SQL CE ", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 7, Number = 7, Name = "Postsharp - Getting Started with AOP using Postsharp ", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 8, Number = 8, Name = "WP7 - Learning how to use Live Tiles", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 9, Number = 9, Name = "MVVM - How to create a ViewModelLocater", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 10, Number = 10, Name = "WCF: How to create Custom Message Interceptors", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 11, Number = 11, Name = "WP7: Using Location Services & Bing Maps", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 12, Number = 12, Name = "WP7: Learning to read/write to isolated storage", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 13, Number = 13, Name = "Rake: Learning to use Rake With MSBuild", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 14, Number = 14, Name = "Entity Framework: Making changes to the T4 Templates", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 15, Number = 15, Name = "WP7: Learning how to detect Themes", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 16, Number = 16, Name = "WP7: Writing and Reading from Isolated Storage", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 17, Number = 17, Name = "Entity Framework: Intro to Database First Design", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 18, Number = 18, Name = "Entity Framework: Intro to Model First Design", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 19, Number = 19, Name = "Load Testing WCF Services w/ VS2010", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } },
                new Episode{Id = 20, Number = 20, Name = "Using Property/Method Exports in MEF", Description = "", Released = DateTime.Parse("11/01/2011"), Tags = new List<Tag>{ new Tag{ Id = 1, Name = "Silverlight" } } }
            };

            return episodes;
        }
    }
}
