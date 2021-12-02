using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace Azukoto.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Alias("p")]
        public async Task PingAsync()
        {
            await Context.Channel.TriggerTypingAsync();
            await Context.Channel.SendMessageAsync("Pong!");
            // await Context.User.SendMessageAsync("Sends a message to user.");
        }
    }
}
