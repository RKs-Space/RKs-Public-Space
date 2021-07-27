namespace UserService.Service
{
    /*
     * Interface for TokenGeneratorService
     */

    public interface ITokenGeneratorService
    {
        string GetJWTToken(string UserId);
    }
}