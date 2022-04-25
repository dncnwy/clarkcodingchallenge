using ClarkCodingChallenge.BusinessLogic;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        
        private readonly IContactsService _service;

        public ContactsController(IContactsService service)
        {           
            _service = service;
        }
        /** I was unable to complete the filter and sort functions.
          
        For filter I would add an additional parameter that would check for a filter based on last name. If it would be anything besides nullorempty.
        I would use the repository to limit the results and only return those results. 
        
        Return contacts.where(x => x.LastName == filteredLastName)

        For sort I would do something similiar checking for a sort based on the view and contacts.Orderby(x => x.LastName).ThenBy(x => x.FirstName)

        And the a combination of the logic for both of those items to filter by lastName and sort as appropiate.
        
        **/
        
        public IActionResult Index(string msg)
        {
            ViewBag.Message = msg;
            var results = _service.GetContacts();
            return View(results);
        }        

        public IActionResult AddContactIndex()
        {
            
            return View();
        }

        public IActionResult AddContact(ContactModel model)
        {
            _service.AddContact(model);
            
            //if I had more time I would rewrite this save confirmation with a javascript dialog as it is quite rudimentary instead of passing the value back to index to show on the redirect.
            string saveMessage = "Form has been saved successfully!";
            return RedirectToAction(nameof(Index), new { msg = saveMessage });

        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
