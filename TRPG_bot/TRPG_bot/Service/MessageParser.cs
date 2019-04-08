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
            string text = eventMessage.Text.ToLower();
            string action = string.IsNullOrWhiteSpace(Regex.Split(text, Global.REG_SPACE)[0]) ? text : Regex.Split(text, Global.REG_SPACE)[0];
            List<string> result = new List<string>();

            // 基本骰
            if (Regex.Match(action, Global.REG_DICE_DEFAULT).Success)
                result.Add(DiceRoller.RowNormalDice(text));

            // 多次基本骰
            if (Regex.Match(action, Global.REG_DICE_DEFAULT_MULTIPLE).Success)
                result.Add(DiceRoller.RowMultiNormalDice(text));

            if (Regex.Match(action, Global.REG_FLAG_BUILDER).Success)
                result.Add(FlagBuilder.Get());

            return result;
        }
    }
}
