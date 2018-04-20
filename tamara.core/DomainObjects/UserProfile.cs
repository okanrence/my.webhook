using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamara.webhook.core.domain
{ 
    [Table("UserProfile")]
    public class UserProfile
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public string AccountNo { get; set; }
        public string FacebookId { get; set; }
        public string DeviceId { get; set; }
        public string GoogleId { get; set; }
        public string SkypeId { get; set; }
        public string PreferredName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string Pin { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
      
        public string EncrytedPin
        {
            get
            {
                return EncryptPin(this.Pin);
            }
        }


        private string EncryptPin(string Pin)
        {
            return Pin;
        }
    }

    
}
