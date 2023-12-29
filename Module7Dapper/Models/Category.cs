using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7Dapper.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; } = new();

        public List<Promotion> Promotions { get; set; } = new();
    }
}
