using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorEntity.Models;

namespace RazorEntity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Article articles { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var db = new MyBlogContext();

            var kq = from article in db.articles
                     select article;

            ViewData["articles"] = kq.ToList();
        }
    }
}