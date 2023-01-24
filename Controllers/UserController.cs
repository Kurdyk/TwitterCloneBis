using Microsoft.AspNetCore.Mvc;
using WebTest.Models;
using WebTest.Service;

namespace WebTest.Controllers {
    [Route("/users")]
    [ApiController]
    public class UsersController : ControllerBase {
        
        [HttpGet]
        public IEnumerable<User> Get() {
            return DbConnector.GetInstance().GetUsers();
        }
    }
}