using BulkyWeb.Data;
using BulkyWeb.Models;

namespace BulkyWeb.Data.Repository
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
        }

        public void Update(Category category)
        {
            db.Update(category);
            //db.Update<Category>(category);
            Save();
        }

        public void UpdateRange(IEnumerable<Category> categories)
        {
            db.UpdateRange(categories);
            Save();
        }
    }
}
