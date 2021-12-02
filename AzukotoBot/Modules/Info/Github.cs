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
    public class GitHub : ModuleBase
    {
        //Sends my github
        [Command("github")]
        public async Task Githubasync()
        {

            var embed = new EmbedBuilder()
                .WithTitle("Github")
                .WithUrl("https://github.com/KontonDev")
                .Build();


            await ReplyAsync(embed: embed);
        }
    }
}
