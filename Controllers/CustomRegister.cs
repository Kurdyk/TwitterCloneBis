using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebTest.Models;
using WebTest.Service;

namespace WebTest.Controllers;


[Route("/auth/register")]
[ApiController]
public class CustomRegister : ControllerBase {

    /**
     * Instantiate a new Logger to try to log
     */
    public CustomRegister() {
    }

    [HttpPost]
    public IActionResult AttemptRegister() {
        var email = Request.Form["email"];
        var username = Request.Form["username"];
        var password = Request.Form["password"];
        User user = new User(email, username, password);
        try {
            new Service.DbConnector().AddUser(user);
        }
        catch (MySqlException e) {
            Console.Out.WriteLine("bdazodbao" + e.ToString() );
            return new UnauthorizedResult(); // Already taken
        }
        HttpContext.Session.SetString("username", username);
        return RedirectToPage("/home/feed");
    }

}