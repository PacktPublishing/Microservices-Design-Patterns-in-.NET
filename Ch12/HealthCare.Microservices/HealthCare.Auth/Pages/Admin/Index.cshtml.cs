using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthCare.Auth.Pages.Admin
{
    [SecurityHeaders]
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}