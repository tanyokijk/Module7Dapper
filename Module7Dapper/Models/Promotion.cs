using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7Dapper.Models;

public class Promotion
{
    public int Id { get; set; }

    public string Country { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public List<Good> Goods { get; set; } = new();

    public Category? PromotionsCategory { get; set; }

    public int? CategoryId { get; set; }
}