using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactInformationAPI.Controllers
{
    //Implemented Token based authentication using OWIN 
    [Authorize]
    public class ContactController : ApiController
    {
        private IDataModel businessLayerObj;

        //Injected business logic layer object using depedency injection
        public ContactController(IDataModel provider)
        {
            businessLayerObj = provider;
        }

        [HttpGet]
        [Route("api/contact/getContacts")]
        public HttpResponseMessage GetContacts()
        {
            try
            {
                var contacts = businessLayerObj.GetContacts();
                if (contacts != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, contacts);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No contacts exist");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/contact/getContact/{id}")]
        public HttpResponseMessage GetContact(int id)
        {
            try
            {
                var contact = businessLayerObj.GetContact(id);
                if (contact != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, contact);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact with id =" + id.ToString() + "not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/contact/addcontact")]
        public HttpResponseMessage AddContact([FromBody] contact_info contactInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = businessLayerObj.AddContact(contactInfo);

                    var message = Request.CreateResponse(HttpStatusCode.Created, contact);
                    message.Headers.Location = new Uri(Request.RequestUri + contact.contact_id.ToString());
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //
        [HttpPut]
        [Route("api/contact/updateContact/{id}")]
        public HttpResponseMessage UpdateContact(int id, [FromBody] contact_info contactDetails)
        {
            try
            {
                    var contact = businessLayerObj.GetContact(id);
                    if (contact == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact with id =" + id.ToString() + "not found");
                    }
                    else
                    {
                        businessLayerObj.UpdateContact(id, contactDetails);
                        return Request.CreateResponse(HttpStatusCode.OK, contact);
                    }               
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/contact/deleteContact/{id}")]
        public HttpResponseMessage DeleteContact(int id)
        {
            try
            {
                var contact = businessLayerObj.GetContact(id);

                if (contact == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact with id = + " + id.ToString() + "not found to delete");
                }
                else
                {
                    businessLayerObj.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }    
    }
}
