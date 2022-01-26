using Pregatit.MonkeyFinder.Core.Entities;
using Pregatit.MonkeyFinder.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregatit.MonkeyFinder.Services.Mappings
{
    public static class MapMonkey
    {
        public static MonkeyDto ToDto (this Monkey m)
        {
            return m != null ? new MonkeyDto
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.ImageUri,
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            }
            : null;
        }

        public static Monkey FromDto (this MonkeyDto m)
        {
            return new Monkey
            {
                Name = m.Name,
                Details = m.Details,
                Image = m.Image.ToString(),
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            };
        }

        public static Monkey FromDto(this MonkeyDto m, int id)
        {
            return new Monkey
            {
                Id = id,
                Name = m.Name,
                Details = m.Details,
                Image = m.Image.ToString(),
                Latitude = m.Latitude,
                Location = m.Location,
                Longitude = m.Longitude,
                Population = m.Population
            };
        }
    }
}
