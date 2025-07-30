
namespace BLL.Services
{
    public class UniqCode
    {
        public static string GenerateNewRandom()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
    }
}
