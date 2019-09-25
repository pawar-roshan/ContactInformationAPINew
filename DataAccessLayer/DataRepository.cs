using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace DataAccessLayer
{
    public class DataRepository : IDataRepository
    {
        ContactDBEntities contactDbSet;
        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ContactDBEntities"];

        public DataRepository()
        {
            var con = settings.ConnectionString;
            contactDbSet = new ContactDBEntities(con);
        }

        public contact_info AddContact(contact_info contact)
        {
            contactDbSet.contact_info.Add(contact);
            contactDbSet.SaveChanges();
            return contact;
        }

        public contact_info Delete(int ContactID)
        {
            var contact = contactDbSet.contact_info.FirstOrDefault(x => x.contact_id == ContactID);
            if (contact != null)
            {
                contactDbSet.contact_info.Remove(contact);
                contactDbSet.SaveChanges();
            }
            return contact;
        }

        public contact_info GetContact(int ContactID)
        {
            return contactDbSet.contact_info.FirstOrDefault(x => x.contact_id == ContactID);
        }

        public IEnumerable<contact_info> GetContacts()
        {
            return contactDbSet.contact_info.ToList();
        }

        public contact_info UpdateContact(contact_info contact)
        {
            contact_info contactDetails = contactDbSet.contact_info.FirstOrDefault(x => x.contact_id == contact.contact_id);

            if (contactDetails != null)
            {
                contactDetails.first_name = contact.first_name;
                contactDetails.last_name = contact.last_name;
                contactDetails.phone_no = contact.phone_no;
                contactDetails.email = contact.email;
                contactDetails.status = contact.status;

                contactDbSet.Entry(contactDetails).State = EntityState.Modified;
                contactDbSet.SaveChanges();

            }
            return contactDetails;
        }
    }
}
