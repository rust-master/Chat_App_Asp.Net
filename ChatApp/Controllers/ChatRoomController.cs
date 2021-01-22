using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatApp.Models;
using System.Threading.Tasks;
using ChatApp.ViewModels;
using System.Data.Entity;


namespace ChatApp.Controllers
{
    public class ChatRoomController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChatRoom
        public ActionResult Index()
        {
            int userId = Convert.ToInt32(Session["UseId"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var Comments = db.Comments.Include(x => x.Replies).OrderByDescending(x => x.CreatedOn).ToList();
            return View(Comments);
        }
        [HttpPost]
        public ActionResult PostComment(string CommentText)
        {
            int userId = Convert.ToInt32(Session["UseId"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            Comment c = new Comment();
            c.Text = CommentText;
            c.CreatedOn = DateTime.Now;
            c.UserId = userId;
            db.Comments.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}