using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using CarManager.Api2.Models;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CarManager.Api2.Controllers
{
    public class BooksController : ApiController
    {
        private SampleDbContext db = new SampleDbContext();

        [EnableCors( origins: "http://localhost:45371",headers:"*",methods:"*")]
        // GET: api/Books
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        // GET: api/Books/5
        //[ResponseType(typeof(Book))]
        //public IHttpActionResult GetBook(int id)
        //{
        //    Book book = db.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(book);
        //}




        //public HttpResponseMessage GetBooks(string  callBack)
        //{
        //    string func= string.Format("{0}({1})", callBack,Newtonsoft.Json.JsonConvert.SerializeObject(db.Books));

        //    return new  HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content=new StringContent(func, Encoding.UTF8,"text/javascript")
        //    };

        //}


        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.ID)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public Book PostBook(Book book)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Books.Add(book);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = book.ID }, book);
            return book;
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]

        public IHttpActionResult DeleteBook(int id)//通过命名获或者打标记的形式标记  该方法是 删除的方法 1.命名DeleteBook 2.打标记[HttpDelete]
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.ID == id) > 0;
        }


        private Book GetBook2(string id,[FromBody] string name) {
            Book book = new Book();

            return book;
        }

        private Book GetBook3(string id, [FromUri] string name)
        {
            Book book = new Book();

            return book;
        }
    }
}