using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project4IdentityMessages_BusinessLayer.Abstract;
using Project4IdentityMessages_EntityLayer.Concrete;
using System.Drawing.Text;

namespace Project4IdentityMessages.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Inbox()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = _messageService.TGetMessagesByReceiver(currentUser.Email);
            return View(messages);
        }
    }
}
