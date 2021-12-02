using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Azukoto.Modules.Info
{
    public class user : ModuleBase
    {
        [Command("user")]
        public async Task InfoAsync(SocketGuildUser socketGuildUser = null)
        {
            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            var embed = new EmbedBuilder()
                .WithTitle($"{socketGuildUser.Username}'s Info")
                .WithThumbnailUrl(socketGuildUser.GetAvatarUrl() ?? socketGuildUser.GetDefaultAvatarUrl())
                .AddField("Name", $"{socketGuildUser.Username}#{socketGuildUser.Discriminator}", false)
                .AddField("Nickname", socketGuildUser.Nickname ?? "N/A", false)
                .AddField("Created at", socketGuildUser.CreatedAt, false)
                .WithFooter(footer => footer.Text = $"Status: {socketGuildUser.Status}")
                .WithCurrentTimestamp()
                .WithColor(new Color(252, 255, 84))
                .Build();

            await ReplyAsync(embed: embed);
        }
    }
}
