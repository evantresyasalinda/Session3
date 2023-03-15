using Session3.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Session3.Tests.TestData
{
    public class GeneratePet
    {
        public static UserJsonModel demoPet()
        {
            return new UserJsonModel
            {
                Id = 1035,
                Name = "Milo",
                Status = "Available",
                Tags = new Category[] { new Category { Id = 1035, Name = "Milo Tag" } },
                PhotoUrls = new string[] { "http://www.Milo.com" },
                Category = new Category()
                {
                    Id = 1035,
                    Name = "Cat"
                },
            };
        }

    }
}
