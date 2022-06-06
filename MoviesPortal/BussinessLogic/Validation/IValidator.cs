using DataAccess.Models;

namespace BusinessLogic.Validation
{
    public interface IValidator
    {
        Task<bool> IsExistInDb(CreativePersonModel person);
        
    }
}