using System.Threading.Tasks;
using System;
using System.Text;
using Discord.WebSocket;
using SIVA.Core.JsonFiles;
using Discord;

namespace SIVA.Core.Bot
{
    public static class Logging
    {
        public static async Task HandleBans(SocketUser user, SocketGuild server)
        {
            var config = GuildConfig.GetGuildConfig(server.Id);
            var loggingChannel = server.GetTextChannel(config.ServerLoggingChannel);
            var embed = new EmbedBuilder()
                .AddField("User", $"{user.Username}#{user.Discriminator}")
                .WithTitle("User Banned")
                .AddField("Time", DateTime.UtcNow + " UTC")
                .WithThumbnailUrl("https://pbs.twimg.com/media/C9kEEmbXUAEX3r6.png")
                .WithAuthor(user)
                .WithColor(config.EmbedColour1, config.EmbedColour2, config.EmbedColour3);

            await loggingChannel.SendMessageAsync("", false, embed);
        }

        public static async Task HandleKicks(SocketUser user, SocketGuild server)
        {

        }
    }
}
