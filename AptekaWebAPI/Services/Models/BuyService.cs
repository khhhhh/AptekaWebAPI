using AptekaWebAPI.Database;
using AptekaWebAPI.Entities;
using AptekaWebAPI.Services.Interfaces;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AptekaWebAPI.Services.Models
{
    public class BuyService : IBuyService
    {
        private readonly PharmacyContext _context;
        public void EmailSend(int id)
        {
            string email = "systemymedycznetest@gmail.com";
            string password = "12345Q#we6789";
            User user = _context.Users
                .ToList()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var cartItems = _context.Carts
                .ToList()
                .Where(x => x.UserId == id);

            var address = user.Address;

            StringBuilder sb = new StringBuilder();
            foreach(var cartItem in cartItems)
            {
                sb.AppendFormat("<li>{0}, {1} piece{2} : {3} zł.</li>\n",
                    cartItem.ProductName,
                    cartItem.Count,
                    (cartItem.Count > 1) ? "s" : string.Empty,
                    cartItem.ProductPrice * cartItem.Count);
            }
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(email, password),
                EnableSsl = true,
            };

            string body = string.Format(@" <h1>Hello, {0}!</h1><br>
             <p> Thank you for purchasing next items:
                  <ul>
                        {1}
                  </ul>
            </p>
            <br>
            <p> It's gonna be send on this address: <br>
                {2} <br>
                {3} <br>
                {4} <br>
            </p>

            <p> With love, <b> Apteka Web Api. </b> </p>
            ", 
            user.Name, sb.ToString(), address?.City, address?.Street, address?.PostalCode);

            smtpClient.Send(email, user.Email, "Thank you for purchase!", body);
        }
        public BuyService(PharmacyContext context)
        {
            _context = context;
        }
    }
}
