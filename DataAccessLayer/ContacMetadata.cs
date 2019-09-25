using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ContacMetadata
    {
        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string email { get; set; }

        [Required]
        public Nullable<int> phone_no { get; set; }
        public bool status { get; set; }
    }

    [MetadataType(typeof(ContacMetadata))]
    public partial class contact_info
    {
    }
}
