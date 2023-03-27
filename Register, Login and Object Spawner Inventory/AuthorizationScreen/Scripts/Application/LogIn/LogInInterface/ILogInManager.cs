namespace App.LogInInterface
{
    public interface ILogInManager
    {
        public bool UserExists(string username, string password);
    }
}