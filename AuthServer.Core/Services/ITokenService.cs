﻿using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Core.Services
{
    public interface ITokenService
    {
        // usera özgü token üretmesi için
        TokenDto CreateToken(UserApp userApp);

        ClientTokenDto CreateTokenByClient(Client client);
    }
}
