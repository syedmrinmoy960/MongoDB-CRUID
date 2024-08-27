namespace MongoDB_CRUID.Managers.IManager
{
    public interface ILoginManager
    {
        Task<string> AuthenticateAsync(string email, string password);
    }
}
