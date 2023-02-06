using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebTest.Pages; 

public class Login : PageModel {

    public string PageAction { get; private set; }
    
    public IActionResult OnGet() {
        string strPathAndQuery = HttpContext.Request.Path;
        if (strPathAndQuery == "/auth/login") {
            this.PageAction = "login";
        }
        else if (strPathAndQuery == "/auth/register") {
            this.PageAction = "register";
        }
        else {
            return RedirectToPage("/errors/Error");
        }

        return Page();
    }
}