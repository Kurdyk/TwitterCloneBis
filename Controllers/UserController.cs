using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using WebTest.Connector;

namespace WebTest.Controller {
    [route("/users")]
    [ApiController]
    public class UsersController : ControllerBase {
        
        private DBConnector dBConnector {get; }

        public UsersController(DBConnector dBConnector) {
            this.dBConnector = dBConnector;
        }

        [HttpGet]
        public IEnumerable<User> Get() {
            return this.dBConnector.getUsers();
        }
    }
}