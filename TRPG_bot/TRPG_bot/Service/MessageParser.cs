using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TRPG_bot.Model;

namespace TRPG_bot.Service
{
    public static class MessageParser
    {
        public static List<string> Parse(TextEventMessage eventMessage)
        {
            string text = eventMessage.Text;
            string action = string.IsNullOrWhiteSpace(Regex.Split(text, Global.REG_SPACE)[0]) ? text : Regex.Split(text, Global.REG_SPACE)[0];
            List<string> result = new List<string>();

            if (Regex.Match(action, Global.REG_DICE_DEFAULT).Success)
                result.Add(DiceRoller.rowNormalDice(text));


            return result;
        }
    }
}
