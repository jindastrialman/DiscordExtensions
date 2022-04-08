using Discord.WebSocket;
using Discord;

namespace Shared.Abstractions
{
    public abstract class BaseBot : IDisposable
    {
        protected string _discordToken;
        protected DiscordSocketClient _client;

        public BaseBot(string discordToken)
        {
            _discordToken = discordToken;
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.Ready += Prepare;
        }
        protected virtual Task Log(LogMessage msg)
        {
	        Console.WriteLine(msg.ToString());
	        return Task.CompletedTask;
        }
        protected virtual Task Prepare()
        {
            return Task.CompletedTask;
        }
        public async Task StartUp()
        {
            await _client.LoginAsync(TokenType.Bot, _discordToken);
            await _client.StartAsync();
        }
        public async void Dispose()
        {
            await _client.StopAsync();
        }
    }
}