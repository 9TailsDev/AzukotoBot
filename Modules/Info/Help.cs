using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Azukoto.Modules.Info
{
    public class Help : ModuleBase
    {
        [Command("help")]
        public async Task Helpasync()
        {
            var embed = new EmbedBuilder()
                .WithTitle("Help Menu")
                .WithThumbnailUrl("https://cdn.discordapp.com/app-icons/798526044134834186/fd80098ece933f2ee79a379c5ecdbe8d.png?size=256")
                .AddField("Fun", "Ping", false)
                .AddField("Admin", "HAHAH PEDO", false)
                .AddField("Info", "Info <user>", false)
                .WithColor(new Color(252, 255, 84))
                .Build();

            await ReplyAsync(embed: embed);
        }
    }
}
