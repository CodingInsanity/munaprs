﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ICanSendHttpResponse
    {
        void SendResponse(HttpResponse responseToSend);
    }
}
