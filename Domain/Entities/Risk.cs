using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Risk :Base
    {
        public string Category { get; set; }
        public string EasyQuestion { get; set; }
        public string EasyQuestionAnswer { get; set; }
        public string RegularQuestion { get; set; }
        public string RegularQuestionAnswer { get; set; }
        public string MeduimQuestion { get; set; }
        public string MeduimQuestionAnswer { get; set; }
        public string HardQuestion { get; set; }
        public string HardQuestionAnswer { get; set; }
        public int Time { get; set; } = 60;
    }
}
