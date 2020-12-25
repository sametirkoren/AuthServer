using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.Configuration
{
    public class Client
    {
        public string Id { get; set; }

        public string Secret { get; set; }

        // Hangi API'lara erişeceği bilgisini tutuyoruz.
        public List<String> Audiences { get; set; }
    }
}
