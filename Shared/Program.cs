namespace Shared
{
    public class Program{        
        public static async Task Main(string[] args)
        {   
            using var client = new LoginBot(Keys.KeyHolder.DiscordKey);
            await client.StartUp();

            await Task.Delay(-1);
        }
    }
} // there should be some tests =b