using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace twitterapi
{
    public class Program
    {
             /*
            The goal of this lab is to create a RESTful api for a clone of Twitter we are creating.

            We wan to be able to create new Tweets (enforcing a max character limit of 240), delete tweets, list tweets
            and update a tweet.

            Assume that everyone is sharing the same user account.

            You will need to at the least:

            1. Create a Tweet class
            2. Create a TweetController
            3. Add methods for CRUD to the TweetController
            4. Ensure all data coming in and out is valid and throw proper errors when it is not

             */
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
