namespace MessageSystem.View.Interface
{
    public interface IMessageDisplayerView
    {
        void DisplayExceptionMessage(string exceptionMessage, string stackTrace);
        void DisplayMessage(string message);
    }
}