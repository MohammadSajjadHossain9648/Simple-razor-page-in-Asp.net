using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleOnline.Data;
using SampleOnline.Model;

namespace SampleOnline.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }

        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Category = _context.Category.Find(id);
        }

        public async Task<IActionResult> OnPost() //without bindproperty write OnPost(Category category) and .AddAsync(category)
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly same with the name.");
            }
            if (ModelState.IsValid) //The ModelState has two purposes: to store the value submitted to the server, and to store the validation errors associated with those values.
            {
                _context.Category.Update(Category);
                await _context.SaveChangesAsync(); // for update database otherwise not add in database
                TempData["success"] = "Category Update Successfully";
                return RedirectToPage("Index");
            }
            return Page(); // if give wrong input, after click create button then reload same page 

        }

    }
}
