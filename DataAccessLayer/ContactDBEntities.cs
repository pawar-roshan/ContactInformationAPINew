using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial class ContactDBEntities : DbContext
    {
        public ContactDBEntities(string ContactDBEntities = "ContactDBEntities")
            : base(ContactDBEntities)
        {
        }
    }
}
