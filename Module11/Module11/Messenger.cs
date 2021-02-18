using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace Module11
{
    public class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            var text = "";


            switch (chat.GetLastMessage())
            {
                case "/saymehi":
                    text = "привет";
                    break;
                case "/askme":
                    text = "как дела";
                    break;
                default:
                    var delimiter = ",";
                    text = "История ваших сообщений: " + string.Join(delimiter, chat.GetTextMessages().ToArray());
                    break;
            }

            return text;
        }

        public InlineKeyboardMarkup ReturnKeyBoard()
        {
            var buttonList = new List<InlineKeyboardButton>
  {
    new InlineKeyboardButton
    {
      Text = "Пушкин",
      CallbackData = "pushkin"
    },

    new InlineKeyboardButton
    {
      Text = "Есенин",
      CallbackData = "esenin"
    }
  };

            var keyboard = new InlineKeyboardMarkup(buttonList);

            return keyboard;
        }

        
    }
}
