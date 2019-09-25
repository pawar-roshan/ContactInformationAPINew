using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IDataModel
    {
        IEnumerable<contact_info> GetContacts();
        contact_info AddContact(contact_info contact);
        contact_info GetContact(int ContactID);
        contact_info UpdateContact(int id,contact_info contact);
        contact_info Delete(int ContactID);
    }
}
