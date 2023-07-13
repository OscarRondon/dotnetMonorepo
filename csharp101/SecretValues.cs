using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class SecretValues
{
    public string? Enviroment { get; set; }
    public string? Username { get; set; }

    public string? Password { get; set; }

    public SecretValues()
    {
        // source https://www.programmingwithwolfgang.com/use-net-secrets-in-console-application/

        string? enviroment;
        string? userName;
        string? password;

        var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddUserSecrets<Program>()
                        .AddEnvironmentVariables();

        var configurationRoot = builder.Build();



        configurationRoot.Providers.ElementAt(0).TryGet("Enviroment", out enviroment);
        if (enviroment.Equals("Development"))
        {
            configurationRoot.Providers.ElementAt(1).TryGet("MySecretValues:Username", out userName);
            configurationRoot.Providers.ElementAt(1).TryGet("MySecretValues:Password", out password);
        }
        else
        {
            configurationRoot.Providers.ElementAt(0).TryGet("MySecretValues:Username", out userName);
            configurationRoot.Providers.ElementAt(0).TryGet("MySecretValues:Password", out password);
        }

        Enviroment = enviroment;
        Username = userName;
        Password = password;

    }
}

