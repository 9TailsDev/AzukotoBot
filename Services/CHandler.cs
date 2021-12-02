using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AzukotoBot.Services
{
        public class CHandler : DiscordClientService
            {
                private readonly IServiceProvider provider;
                private readonly DiscordSocketClient client;
                private readonly CommandService service;
                private readonly IConfiguration configuration;
                private readonly ILogger<DiscordClientService> logger;

        public CHandler(DiscordSocketClient client, ILogger<DiscordClientService> logger, IServiceProvider provider, CommandService service, IConfiguration configuration) 
            : base(client, logger)
        {
                this.provider = provider;
                this.client = client;
                this.service = service;
                this.configuration = configuration;
                this.logger = logger;
        }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                this.client.MessageReceived += OnMessageReceved;
                this.service.CommandExecuted += CommandExecuted;
                await this.service.AddModulesAsync(Assembly.GetEntryAssembly(), this.provider);
            }

            private async Task CommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
            {
                if (result.IsSuccess)
                {
                    return;
                }

                await commandContext.Channel.SendMessageAsync(result.ErrorReason);
            }

            private async Task OnMessageReceved(SocketMessage socketMessage)
            {
                if (!(socketMessage is SocketUserMessage message)) return;
                if (message.Source != MessageSource.User) return;

                var argPos = 0;
                if (!message.HasStringPrefix(this.configuration["Prefix"], ref argPos) && !message.HasMentionPrefix(this.client.CurrentUser, ref argPos)) return;

                var context = new SocketCommandContext(this.client, message);
                await this.service.ExecuteAsync(context, argPos, this.provider);
        }
    }
}
