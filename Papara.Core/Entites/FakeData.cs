using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Core.Entity
{
    public class FakeData
    {
        [Key]
        public int fakeDataId { get; set; }
        public int postId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}
