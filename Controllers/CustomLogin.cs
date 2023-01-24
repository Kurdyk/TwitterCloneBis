using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using WebTest.Service;

namespace WebTest.Controllers;


[Microsoft.AspNetCore.Components.Route("/login")]
//[ApiController]
public class CustomLogin : ControllerBase
{

    private string email;
    private string password;

    /**
     * Instantiate a new Logger to try to log
     */
    public CustomLogin(string email, string password) {
        this.email = email;
        this.password = password;
    }

    [HttpPost]
    public HttpResponseMessage AttemptLogin() {
        string knownPassword;
        try {
            knownPassword = new Service.DbConnector().GetPassword(email);
        } catch (NullReferenceException exception) {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        if (this.password == knownPassword) {
            HttpContext.Session.Set("username", Encoding.ASCII.GetBytes(new Service.DbConnector().GetUsername(email)));
            Response.Redirect("/home");
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        return new HttpResponseMessage(HttpStatusCode.Conflict);
    }

}

    