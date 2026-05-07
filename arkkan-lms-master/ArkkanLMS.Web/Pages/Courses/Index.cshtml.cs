using ArkkanLMS.Core.Entities;
using ArkkanLMS.Core.Types;
using ArkkanLMS.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArkkanLMS.Web.Pages.Courses
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<Course> Courses { get; set; }
        public bool HasCurrentUser { get; private set; }

        public async Task OnGetAsync()
        {
            HasCurrentUser = await LoadCurrentUserAsync();
            Courses = await DbContext.Courses.AsNoTracking().ToListAsync();
        }
    }
}


