namespace Milkman.End2end.Tests.Pages.Login
{
    public interface ICommon
    {
        public T WithPhoneNo<T>(string phoneNo) where T : class;
        public T WithPassword<T>(string password) where T : class;
        public T WithEmailAddress<T>(string email) where T : class;
    }
}
