using DataAccess.Models;

namespace BusinessLogic.Validation
{
    public interface ICreativePersonValidator
    {
        Task<bool> IsExistInDb(CreativePersonModel person);
        
    }
}