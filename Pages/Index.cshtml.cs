using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTest.Connector;
using WebTest.Models;

namespace WebTest.Pages {
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private DBConnector DBConnector;
        public IEnumerable<User> users {get; private set;}

        public IndexModel(ILogger<IndexModel> logger,
            DBConnector dBConnector
        )
        {
            _logger = logger;
            this.DBConnector = dBConnector;
        }

        public void OnGet()
        {
            this.users = DBConnector.getUsers();
        }
    }
}
