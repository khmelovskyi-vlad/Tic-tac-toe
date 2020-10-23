using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_tac_toe_api
{
    public class ConfigureJwtBearerOptions : IPostConfigureOptions<JwtBearerOptions>
    {
        public void PostConfigure(string name, JwtBearerOptions options)
        {
            var first = options;
            var second = options.Events;
            var thirt = options.Events.OnMessageReceived;
            var originalOnMessageReceived = options.Events.OnMessageReceived;
            if (originalOnMessageReceived == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                options.Events.OnMessageReceived = async context =>
                {
                    await originalOnMessageReceived(context);

                    Console.WriteLine("okey");
                    if (string.IsNullOrEmpty(context.Token))
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (string.IsNullOrEmpty(accessToken))
                        {
                            Console.WriteLine($"accessToken = is null");
                        }
                        else
                        {
                            Console.WriteLine($"accessToken = {accessToken}");
                        }
                        if (string.IsNullOrEmpty(path))
                        {
                            Console.WriteLine($"path = is null");
                        }
                        else
                        {
                            Console.WriteLine($"path = {path}");
                        }

                        if (!string.IsNullOrEmpty(accessToken) &&
                            path.StartsWithSegments("/hubs"))
                        {
                            context.Token = accessToken;
                        }
                    }
                };
            }
        }
    }
}
