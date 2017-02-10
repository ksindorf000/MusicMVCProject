using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Controllers
{
    public class SearchController : Controller
    {
        /****************************************************
         * I didn't need to make this Search Controller but 
         * I'm leaving it here for the notes on the 
         * RIGHT WAY to add search functionality
         ***************************************************/

        // Initial Set-Up:
        // Create new class to the model that you'll be searching
        // Add a search to your viewbag in your controller
        // Add a BeginForm with textbox to your View
        // Add textbox for class variable
        // Submit button

        //--------

        // Didn't work - no error, just refreshes page
        //	  Debugging shows string is being passed to Index
        //    but not received

        //    Add new Index() in Controller to accept parameters
        //    of the type of your Search class

        //        Add breakpoint to make sure the breakpoint
        //		is only hit when the search is submitted and
        //        that the argument is being passed


        //    Add logic to Index(Class varName) that searches the
        //    table

        //    Add ActionLink to refresh Index()


        //--------

        //Extra Credit:
        //Clear out duplicated code between Index() and Index(search)
        //    Create a helper method that returns an IQueriable<>

        /*
        private IQueryable<Book> GetBooks()
        {
            var userId = User.Identity.GetUserId();
            return db.Books.Include(b => b.Owner)
        .Where(b => b.Owner.Id == userId);
        }

        // GET: Book
        public ActionResult Index()
        {
            //Get logged in user and only list books belonging to that user
            var books = GetBooks();
            return View(books.ToList());
        }

        //EDIT: Book
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Only allow edits to books that belong to the current user
            var userId = User.Identity.GetUserId();
            var book =
        GetBook()
                .FirstOrDefault();
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email", book.OwnerId);
            return View(book);
        }
        */

        //        IQueriable<> = Interface collection
        //*****Challenge: understand what an IQueriable / Interface is
    }    
}