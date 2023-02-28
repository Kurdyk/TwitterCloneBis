using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTest.Models;

namespace WebTest.Pages.home; 

public class Feed : PageModel {

    public IList<Tweet> tweetsList;
    public void OnGet() {
        
    }
}