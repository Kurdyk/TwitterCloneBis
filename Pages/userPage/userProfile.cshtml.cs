using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTest.Models;

namespace WebTest.Pages.userPage; 

public class UserProfile : PageModel {
    
    public new User User { get; private set; }
    public bool OwnProfile { get; private set; }
    public IList<Tweet> Tweets { get; private set; }
    public int NbFollowers { get; private set; }
    public bool AlreadyFollows { get; private set; }

    public IActionResult OnGet() {
        var username = GetUsername();
        this.User = new User(username);
        if (!ValidateUser(username)) {
            return RedirectToPage("/errors/Error");
        }
        this.OwnProfile = username == HttpContext.Session.GetString("username");
        this.Tweets = new List<Tweet>();
        this.NbFollowers = 42;
        this.AlreadyFollows = true;
        return Page();
    }

    /**
     * Recover the username from the url
     */ 
    private string GetUsername() {
        string strPathAndQuery = HttpContext.Request.Path;
        return strPathAndQuery.Split("/")[2];
    }

    /**
     * Ask a validation from the database
     */
    private static bool ValidateUser(string username) {
        return new Service.DbConnector().ValidateUsername(username);
    }

    private IList<Tweet> GetTweets() {
        return new Service.DbConnector().GetUserTweets(this.User);
    }
}