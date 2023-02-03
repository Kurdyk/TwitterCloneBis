using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebTest.Models;
using WebTest.Service;

namespace WebTest.Controllers;


[Route("/auth/register")]
[ApiController]
public class CustomRegister : ControllerBase
{

    private string email;
    private string password;
    private string username;

    /**
     * Instantiate a new Logger to try to log
     */
    public CustomRegister(string email, string password, string username) {
        this.email = email;
        this.username = username;
        this.password = password;
    }

    [HttpPost]
    public HttpResponseMessage AttemptRegister() {
        User user = new User(this.email, this.username, this.password);
        try {
            new Service.DbConnector().AddUser(user);
        }
        catch (Exception e) {
            return new HttpResponseMessage(HttpStatusCode.Conflict); // Already taken
        }
        HttpContext.Session.Set("username", Encoding.ASCII.GetBytes(this.username));
        Response.Redirect("/home");
        return new HttpResponseMessage(HttpStatusCode.Accepted);
    }

}