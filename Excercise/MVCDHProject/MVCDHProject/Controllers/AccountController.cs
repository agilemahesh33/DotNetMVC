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

        #region Email Sending Confirmation Logic
        public void SendEmail(IdentityUser identityUser, string requestURL, string subject)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("Hello " + identityUser.UserName + "<br /><br />");
            if (subject == "Email Confirmation Link")
            {
                mailBody.Append("Click on the link below to confirm Email : ");
            }
            else if (subject == "Change Password Link")
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
            smtpClient.Authenticate("mahesh.baradkar18@gmail.com", "lgcb ypxj tdzi kbmi");
            smtpClient.Send(mailMessage);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId != null && token != null)
            {
                var User = await userManager.FindByIdAsync(userId);
                if (User != null)
                {
                    var result = await userManager.ConfirmEmailAsync(User, token);
                    if (result.Succeeded)
                    {
                        TempData["Title"] = "Email Confirmation Success.";
                        TempData["Message"] = "Email confirmation is completed. You can now login into the application.";
                        return View("DisplayMessages");
                    }
                    else
                    {
                        StringBuilder Errors = new StringBuilder();
                        foreach (var Error in result.Errors)
                        {
                            Errors.Append(Error.Description + ". ");
                        }
                        TempData["Title"] = "Confirmation Email Failure";
                        TempData["Message"] = Errors.ToString();
                        return View("DisplayMessages");
                    }
                }
                else
                {
                    TempData["Title"] = "Invalid User Id.";
                    TempData["Message"] = "User Id which is present in confirm email link is in-valid.";
                    return View("DisplayMessages");
                }
            }
            else
            {
                TempData["Title"] = "Invalid Email Confirmation Link.";
                TempData["Message"] = "Email confirmation link is invalid, either missing the User Id or Confirmation Token.";
                return View("DisplayMessages");
            }
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
                //Code to check whether Email is confirmed or not
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

        #region Forgot Password
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByNameAsync(model.Name);
                if (User != null && await userManager.IsEmailConfirmedAsync(User))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(User);
                    var confirmationUrlLink = Url.Action("ChangePassword", "Account", new { UserId = User.Id, Token = token }, Request.Scheme);
                    SendEmail(User, confirmationUrlLink, "Change Password Link");
                    TempData["Title"] = "Change Password Link";
                    TempData["Message"] = "Change password link has been sent to your mail, click on it and change password.";
                    return View("DisplayMessages");
                }
                else
                {
                    TempData["Title"] = "Change Password Mail Generation Failed.";
                    TempData["Message"] = "Either the Username you have entered is in-valid or your email is not confirmed.";
                    return View("DisplayMessages");
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByIdAsync(model.UserId);
                if (User != null)
                {
                    var result = await userManager.ResetPasswordAsync(User, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        TempData["Title"] = "Reset Password Success";
                        TempData["Message"] = "Your password has been reset successfully.";
                        return View("DisplayMessages");
                    }
                    else
                    {
                        foreach (var Error in result.Errors)
                            ModelState.AddModelError("", Error.Description);
                    }
                }
                else
                {
                    TempData["Title"] = "Invalid User";
                    TempData["Message"] = "No user exists with the given User Id.";
                    return View("DisplayMessages");
                }
            }
            return View(model);
        }
        #endregion ForgotPassword

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion Logout
    }
}
