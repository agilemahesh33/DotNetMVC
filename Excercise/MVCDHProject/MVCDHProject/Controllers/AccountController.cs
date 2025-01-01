using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVCDHProject.Models;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace MVCDHProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        #region Fields and Constructor
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #endregion Fields and Constructor

        #region Registration
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel userModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser()
                {
                    UserName = userModel.Name,
                    Email = userModel.Email,
                    PhoneNumber = userModel.Mobile
                };
                var result = await userManager.CreateAsync(identityUser, userModel.Password);
                if (result.Succeeded)
                {
                    //1. Instead of login user after registration send email for confirmation of email
                    //await signInManager.SignInAsync(identityUser, false);
                    //return RedirectToAction("Index", "Home");
                    #region Email Sending
                    // 2. Once Email is sent message should be like please confirm email by clicking on url sent through email
                    // 3. Once Email is Confirmed by clicking on URL sent, then
                    // message should be shown like Your Email is confirmed and you can try login
                    // 4. To display all the above messages create generic view page
                    var _Token = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var confirmationURLLink = Url.Action("ConfirmEmail", "Account", new { UserId = identityUser.Id, Token = _Token }, Request.Scheme);
                    //Passing Email information to SendMail method
                    SendEmail(identityUser, confirmationURLLink, "Email Confirmation Link");
                    TempData["Title"] = "Email Confirmation Link";
                    @TempData["Message"] = "A Email Confirmation Link has been sent to your registered Email, Please Click to Confirm";
                    return View("DisplayMessages");
                    #endregion Email Sending
                }
                else
                {
                    foreach (var Error in result.Errors)
                    {
                        ModelState.AddModelError("", Error.Description);
                    }
                }
            }
            return View(userModel);
        }
        #endregion Registration

        #region Email Sending Logic
        public void SendEmail(IdentityUser identityUser, string requestURL, string subject)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("Hello " + identityUser.UserName + "<br /><br />");
            if (subject== "Email Confirmation Link")
            {
                mailBody.Append("Click on the link below to confirm Email : ");
            }
            else if (subject== "Change Password Link")
            {
                mailBody.Append("Click on the link below to reset password : ");
            }
            mailBody.Append("<br />");
            mailBody.Append(requestURL);
            mailBody.Append("<br /><br />Regards<br /><br />Customer Support");

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailBody.ToString();

            MailboxAddress fromAddress = new MailboxAddress("Customer Support", "mahesh.baradkar18@gmail.com");
            MailboxAddress toAddress = new MailboxAddress(identityUser.UserName, identityUser.Email);

            MimeMessage mailMessage = new MimeMessage();
            mailMessage.From.Add(fromAddress);
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, true);
            smtpClient.Authenticate("mahesh.baradkar18@gmail.com","");
            smtpClient.Send(mailMessage);
        }
        #endregion Email Sending Logic
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null && (await userManager.CheckPasswordAsync(user, loginModel.Password)) && user.EmailConfirmed == false)
                {
                    ModelState.AddModelError("", "Your Email is not comfirmed");
                    return View(loginModel);
                }

                var result = await signInManager.PasswordSignInAsync(loginModel.Name, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {

                    if (string.IsNullOrEmpty(loginModel.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginModel.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Credentials");
                }
            }
            return View(loginModel);
        }
        #endregion Login

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion Logout
    }
}
