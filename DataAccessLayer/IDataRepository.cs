using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataRepository
    {
        IEnumerable<contact_info> GetContacts();
        contact_info AddContact(contact_info contact);
        contact_info GetContact(int ContactID);
        contact_info UpdateContact(contact_info contact);
        contact_info Delete(int ContactID);

    }
}
