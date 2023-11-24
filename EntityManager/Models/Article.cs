using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManager.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime PubDate { get; set; } = DateTime.UtcNow;
    }
}
