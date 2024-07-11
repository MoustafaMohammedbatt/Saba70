using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GueessPlayer : Base
    {
        public string PlayerName { get; set; }
        public string Hint1 { get; set; }
        public string Hint2 { get; set; }
        public string Hint3 { get; set; }
        public string Hint4 { get; set; }
        public string Hint5 { get; set; }
        public int Time { get; set; } = 45 ;
    }
}
