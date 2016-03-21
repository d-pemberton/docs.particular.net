﻿using System;
using NServiceBus;

namespace Snippets4.Callback.Int
{

    class Usage
    {

        Usage(IBus bus)
        {
            #region IntCallback

            Message message = new Message();
            bus.Send(message)
                .Register<int>(response =>
                {
                    Console.WriteLine("Callback received with response:" + response);
                });

            #endregion
        }

    }
}