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
            string email = "";
            string password = "";
            User user = _context.Users
                .ToList()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            var cartItems = _context.Carts
                .ToList()
                .Where(x => x.UserId == id);


            var address = user.Address;

            long inTotal = 0L; 

            StringBuilder sb = new StringBuilder();
            foreach(var cartItem in cartItems)
            {
                var product = _context.Products.Where(x => x.Id == cartItem.ProductId).FirstOrDefault();
                sb.AppendFormat("<li>{0}, {1} piece{2} : {3} zł.</li>\n",
                    product.Name,
                    cartItem.Count,
                    (cartItem.Count > 1) ? "s" : string.Empty,
                    cartItem.ProductPrice);
                inTotal += cartItem.ProductPrice;
            }
            string body = string.Format(@" <h1>Hello, {0}!</h1><br>
             <p> Thank you for purchasing next items:
                  <ul>
                        {1}
                  </ul>
            </p>
            <p> <b> Total price is: {2} zł. </b> </p>
            <br>
            <p> It's gonna be send on this address: <br>
                {3} <br>
                {4} <br>
                {5} <br>
            </p>

            <p> With love, <b> Apteka Web Api. </b> </p>
            ", 
            user.Name, sb.ToString(), inTotal, address?.City, address?.Street, address?.PostalCode);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(email);
                mail.To.Add(user.Email);
                mail.Subject = "Thank you for purchase!";
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(email, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
        public BuyService(PharmacyContext context)
        {
            _context = context;
        }
    }
}
