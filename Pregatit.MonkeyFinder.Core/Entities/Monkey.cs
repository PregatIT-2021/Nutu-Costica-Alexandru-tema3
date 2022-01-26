using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregatit.MonkeyFinder.Core.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Monkey")]
    public class Monkey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }

        private string _image;
        public string Image { get { return _image; } set { _image = value; } }

        [Computed]
        public Uri ImageUri { get { return string.IsNullOrWhiteSpace(_image) ? new Uri("http://localhost") : new Uri(_image); } }
        public long Population { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
