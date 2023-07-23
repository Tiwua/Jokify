namespace Jokify.Core.Contracts
{
    using Jokify.Core.Models.Joke;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJokeCategoryService
    {
        Task<IEnumerable<JokeCategoryViewModel>> GetAllCategoriesAsync();

        Task<IEnumerable<string>> GetAllCategoriesNamesAsync();

        Task<int> GetCategoryIdAsync(Guid id);

        Task<bool> CategoryExistsAsync(int categoryId);
    }
}
