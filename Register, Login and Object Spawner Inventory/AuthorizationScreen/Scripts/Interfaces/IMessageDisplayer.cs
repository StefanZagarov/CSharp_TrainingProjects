namespace Interface
{
    public interface IMessageDisplayer
    {
        public void ClearRegisterMessageField();
        public void WriteRegisterMessageRed(string message);
        public void WriteRegisterMessageGreen(string message);

        public void ClearLogInMessageField();
        public void WriteLogInMessageRed(string message);
    }
}