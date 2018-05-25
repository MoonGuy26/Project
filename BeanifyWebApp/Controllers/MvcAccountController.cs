using BeanifyWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BeanifyWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MvcAccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public MvcAccountController()
        {
        }

        public MvcAccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /MvcAccount
        public ActionResult Index()
        {
            return View(UserManager.Users.ToList());
        }

        //
        // GET: /MvcAccount/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //
        // POST: /MvcAccount/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.Email);
            if (!UserManager.GetRoles(user.Id).Contains("Admin"))
                return View();

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                    
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /MvcAccount/AddUser
        //[Authorize(Roles = "Admin")]
        
        public ActionResult AddUser()
        {
            return View();
        }

        //
        // POST: /MvcAccount/AddUser
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(RegisterViewModel model)
        {
           
                if (ModelState.IsValid)
                {
                var user = new ApplicationUser {Name=model.Name, UserName = model.Email, Email = model.Email, Company=model.Company, PhoneNumber=model.PhoneNumber };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                    // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        EmailService email = new EmailService();
                        IdentityMessage identityMessage = new IdentityMessage();

                        identityMessage.Destination = model.Email;
                        identityMessage.Subject = "New Beanify account";

                        string FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailTemplates/AccountChanged.html");
                        StreamReader str = new StreamReader(FilePath);
                        string MailText = str.ReadToEnd().ToString();
                        str.Close();

                        MailText = MailText.Replace("{0}", "Account updated");
                        MailText = MailText.Replace("{1}", String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now));
                        MailText = MailText.Replace("{2}", model.Name);
                        
                        MailText = MailText.Replace("{4}", model.Password);
                        

                        MailText = MailText.Replace("{5}", Path.Combine("http://93.113.111.183", VirtualPathUtility.ToAbsolute("~/MvcAccount/ForgotPassword")));

                        identityMessage.Body = MailText;

                        email.Send(identityMessage);

                    }).Start();
                    return RedirectToAction("Index");
                    }
                    AddErrors(result);
                }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: MvcAccount/Edit/5
        public ActionResult Edit(string id)
        {
             if (string.IsNullOrEmpty(id))
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             ApplicationUser applicationUser = UserManager.FindById(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }

            EditAccountBindingModel editedUser = new EditAccountBindingModel
            {
                Id = id,
                Name=applicationUser.Name,
                PhoneNumber = applicationUser.PhoneNumber,
                Company = applicationUser.Company,
                Email = applicationUser.UserName

            };
            
            return View(editedUser);

        }

        // POST: MvcAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit( EditAccountBindingModel editedUser)
        {
            if (ModelState.IsValid)
            {
                var newUser = UserManager.FindById(editedUser.Id);
                var oldEmail = newUser.Email;

                bool emailChanged = false;
                bool passwordChanged = false;
                if (editedUser.NewPassword != null)
                {
                    string code = await UserManager.GeneratePasswordResetTokenAsync(newUser.Id);
                    await UserManager.ResetPasswordAsync(newUser.Id, code, editedUser.NewPassword);
                    passwordChanged = true;
                }
                if (newUser.Email != editedUser.Email)
                {
                    emailChanged = true;
                }

                if (emailChanged || passwordChanged)
                {

                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        EmailService email = new EmailService();
                        IdentityMessage identityMessage = new IdentityMessage();

                        identityMessage.Destination = newUser.Email;
                        identityMessage.Subject = "Beanify account updated";

                        string FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailTemplates/AccountChanged.html");
                        StreamReader str = new StreamReader(FilePath);
                        string MailText = str.ReadToEnd().ToString();
                        str.Close();

                        MailText = MailText.Replace("{0}", "Account updated");
                        MailText = MailText.Replace("{1}", String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now));
                        MailText = MailText.Replace("{2}", editedUser.Name);
                        MailText = MailText.Replace("{3}", editedUser.Email);
                        if (passwordChanged)
                            MailText = MailText.Replace("{4}", editedUser.NewPassword);
                        else
                            MailText = MailText.Replace("{4}", "your password has not been changed");

                        MailText = MailText.Replace("{4}", Path.Combine("http://93.113.111.183", VirtualPathUtility.ToAbsolute("~/MvcAccount/ForgotPassword")));

                        identityMessage.Body = MailText;

                        email.Send(identityMessage);

                    }).Start();
                }

                
                newUser.Name = editedUser.Name;
                newUser.PhoneNumber = editedUser.PhoneNumber;
                newUser.Company = editedUser.Company;

                
                newUser.UserName = editedUser.Email;
                newUser.Email = editedUser.Email;
                await UserManager.UpdateAsync(newUser);

                return RedirectToAction("Index");
            }
            return View(editedUser);
        }

        // GET: MvcAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: MvcAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            
            UserManager.Delete(UserManager.FindById(id));

            return RedirectToAction("Index");
        }

        //
        // GET: /MvcAccount/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: MvcAccount/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                    var user = await UserManager.FindByNameAsync(model.Email);
                    if (user == null)
                    {
                        /*|| !(await UserManager.IsEmailConfirmedAsync(user.Id))*/
                        // Don't reveal that the user does not exist or is not confirmed
                        return View("ForgotPasswordConfirmation");
                    }

                    
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                    var callbackUrl = Url.Action("ResetPassword", "MvcAccount", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);

                    string FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/EmailTemplates/ResetPassword.html");
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd().ToString();
                    str.Close();

                    MailText = MailText.Replace("{0}", "Reset Password");
                    MailText = MailText.Replace("{1}", String.Format("{0:dddd, d MMMM yyyy}", DateTime.Now));
                    MailText = MailText.Replace("{2}", user.Name);
                    MailText = MailText.Replace("{3}", callbackUrl);


                    UserManager.SendEmailAsync(user.Id, "Reset Password", MailText);
                }).Start();

                //await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "MvcAccount");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //
        // GET: /MvcAccount/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /MvcAccount/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /MvcAccount/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "MvcAccount");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "MvcAccount");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /MvcAccount/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /MvcAccount/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}
