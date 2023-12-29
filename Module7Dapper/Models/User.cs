using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7Dapper.Models;

public class User
{
    public enum GenderItem
    {
        Жінка,
        Чоловік,
        Інша,
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public GenderItem Gender { get; set; }

    public string Email { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public List<Category> Categories { get; set; } = new();

}
