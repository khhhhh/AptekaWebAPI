using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptekaWebAPI.Token
{
    public class Token
    {
        public static List<string> Tokens;

        public string generateNewToken()
        {
            var token = Guid.NewGuid().ToString();
            Tokens.Add(token);
            return token;
        }

        ~Token()
        {
            Tokens.Clear();
        }
    }
}
