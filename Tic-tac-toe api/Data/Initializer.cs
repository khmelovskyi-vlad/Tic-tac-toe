using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tic_tac_toe_api.Models.EntityFramework;

namespace Tic_tac_toe_api.Data
{
    public class Initializer : IInitializer
    {
        public void Run(ModelBuilder modelBuilder)
        {
            var section = GetSections();


            modelBuilder.Entity<Section>().HasData(section);
        }

        private List<Section> GetSections()
        {
            List<Section> sections = new List<Section>();
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 100; j++)
                {
                    sections.Add(new Section() { Id = Guid.NewGuid(), XCoordinate = i, YCoordinate = j });
                }
            }
            return sections;
        }
    }
}
