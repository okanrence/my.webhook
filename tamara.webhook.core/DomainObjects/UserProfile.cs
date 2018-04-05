using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamara.webhook.core.DomainObjects
{

    [Table("UserProfile")]
    public class UserProfile
    {
        public string ID { get; set; }
        public string Username { get; set; }
      

    }
}
