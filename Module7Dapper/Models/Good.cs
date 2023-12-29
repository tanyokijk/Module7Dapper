using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7Dapper.Models;

public class Good
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Promotion? GoodsPromotion { get; set; }

    public int? PromotionId { get; set; }
}