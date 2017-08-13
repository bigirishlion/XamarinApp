using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.Models
{
    public class Search
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Period {
            get
            {
                return string.Format("{0:MMM d yyyy} - {1:MMM d yyyy}", CheckIn, CheckOut);
            }
        }
    }
}
