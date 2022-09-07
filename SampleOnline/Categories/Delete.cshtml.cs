using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleOnline.Data;
using SampleOnline.Model;

namespace SampleOnline.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Category = _context.Category.Find(id);
        }

        public async Task<IActionResult> OnPost() //without bindproperty write OnPost(Category category) and .AddAsync(category)
        {
            var CategoryFromDb = _context.Category.Find(Category.Id);
            if (CategoryFromDb != null)
            {
                _context.Category.Remove(CategoryFromDb);
                await _context.SaveChangesAsync(); // for update database otherwise not add in database
                TempData["delete"] = "Category Delete Successfully";
                return RedirectToPage("Index");
            }
            return Page(); // if give wrong input, after click create button then reload same page 
        }

    }
}
