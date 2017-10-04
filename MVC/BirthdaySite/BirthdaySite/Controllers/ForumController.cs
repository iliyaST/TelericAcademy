using System.Linq;
using System.Web.Mvc;
using BirthdaySite.ViewModels.Forum;
using MVCTemplate.Services.Data;

namespace BirthdaySite.Controllers
{
    public class ForumController : Controller
    {
        private IGroupService groups;

        public ForumController(IGroupService groups)
        {
            this.groups = groups;
        }

        [Authorize]
        public ActionResult Index()
        {
            var groups = this.groups.GetAll()
                .Select(x => new GroupViewModel()
                {
                    Name = x.Name,
                    Messages = x.Messages.Select(y => new MessageViewModel()
                    {
                        Author = y.Author,
                        Content = y.Content
                    }).ToList()

                })
                .ToList();


            return View(groups);
        }

        [Authorize]
        [HttpGet]
        public ActionResult RenderMessages(string groupName)
        {
            var group = this.groups.GetAll()
                .Where(x => x.Name.ToLower() == groupName.ToLower())
                .Select(x => new GroupViewModel()
                {
                    Name = x.Name,
                    Messages = x.Messages.Select(y => new MessageViewModel()
                    {
                        Author = y.Author,
                        Content = y.Content
                    }).ToList()
                })
                .SingleOrDefault();

            return View("_MessagesPartial", group);
        }

        //[Authorize]
        //public ActionResult Send(string groupName, string message)
        //{
        //    var messageAuthor = this.User.Identity.Name;
        //    var index = messageAuthor.IndexOf('@');
        //    var author = messageAuthor.Substring(0, index);

        //    this.groups.AddMessageToGroup(groupName, author, message);


        //}

        //TODO: Add Functionality!
        [Authorize]
        public ActionResult AddGroup()
        {
            return null;
        }
    }
}