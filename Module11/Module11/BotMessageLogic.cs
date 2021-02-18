using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Module11
{
    public class BotMessageLogic
    {
        private Messenger messanger;

        private Dictionary<long,
        Conversation> chatList;

        private ITelegramBotClient botClient;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            messanger = new Messenger();
            chatList = new Dictionary<long,
            Conversation>();
            this.botClient = botClient;
        }

        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);

            await SendTextMessage(chat);
        }

        private async Task SendTextMessage(Conversation chat)
        {
            var text = messanger.CreateTextMessage(chat);

            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text);
        }

        private async Task SendTextWithKeyBoard(Conversation chat, string text, InlineKeyboardMarkup keyboard)
        {
            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text, replyMarkup: keyboard);
        }


    }
}
