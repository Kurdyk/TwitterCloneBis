using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebTest.Controllers;


[Route("/auth/login")]
[ApiController]
public class CustomLogin : ControllerBase
{

    /**
     * Instantiate a new Logger to try to log
     */
    public CustomLogin() { }

    [HttpPost]
    public IActionResult AttemptLogin() {
        var email = Request.Form["email"];
        var password = Request.Form["password"];
        string knownPassword;
        try {
            knownPassword = new Service.DbConnector().GetPassword(email);
        } catch (NullReferenceException exception) {
            return NotFound();
        }

        if (password == knownPassword) {
            HttpContext.Session.SetString("username",new Service.DbConnector().GetUsername(email));
            return RedirectToPage("/home/feed");
        }
        
        return NotFound();
    }

}

    