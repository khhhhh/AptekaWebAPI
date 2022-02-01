namespace AptekaWebAPI.Services.Interfaces
{
    public interface IBuyService
    {
        public void EmailSend(int id);
        public void RemoveAllFromCart(int id);
    }
}
