using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project4IdentityMessages_BusinessLayer.Abstract;
using Project4IdentityMessages_EntityLayer.Concrete;
using System.Drawing.Text;

namespace Project4IdentityMessages.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICategoryService _categoryService;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _messageService = messageService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Inbox()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageService.TGetMessagesByReceiver(currentUser.Email);
            return View(messages);
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var messageId = id;
            var value = _messageService.TMessageDetails(messageId);
            return View(value);
        }

        public async Task<IActionResult> Outbox()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageService.TGetMessagesBySender(currentUser.Email);
            return View(messages);
        }

        public async Task<IActionResult> MessageDetailSender(int id)
        {
            var messageId = id;
            var value = _messageService.TMessageDetailsSender(messageId);
            return View(value);
        }

        [HttpGet]
        public IActionResult NewMessage()
        {
            var categories = _categoryService.TGetAll();
            List<SelectListItem> categoryTypes = categories
         .Select(x => new SelectListItem
         {
             Text = x.CategoryName,
             Value = x.CategoryId.ToString()
         })
         .ToList();
            ViewBag.CategoryTypes = categoryTypes;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> NewMessage(Message message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            message.SenderMail = user.Email;
            message.CreatedAt = DateTime.Now;
            message.AppUserId = user.Id;
            _messageService.TInsert(message);
            return RedirectToAction("Outbox");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }


    }
}
