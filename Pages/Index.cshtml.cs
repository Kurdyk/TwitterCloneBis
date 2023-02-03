using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTest.Models;
using WebTest.Service;

namespace WebTest.Pages {
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private DbConnector DBConnector;
        public IEnumerable<User> users {get; private set;}

        public IndexModel(ILogger<IndexModel> logger,
            DbConnector dBConnector
        )
        {
            _logger = logger;
            this.DBConnector = dBConnector;
        }

        public void OnGet()
        {
            this.users = DBConnector.GetUsers();
        }
    }
}
