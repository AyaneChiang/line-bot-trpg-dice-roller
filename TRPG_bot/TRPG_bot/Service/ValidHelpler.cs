using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TRPG_bot.Service
{
    public static class ValidHelpler
    {
        private const int DICE_ROW_MAX = 20;

        public static bool NormalDice(string action, out string msg)
        {
            int times = int.Parse(Regex.Split(action, "d")[0]);
            bool isValid = true;
            msg = string.Empty;
            if (times > DICE_ROW_MAX)
            {
                msg = $"{action}\n擲骰超過20次，機器人要死掉了{LineEmoji.GetShock()}";
                isValid = false;
            }

            return isValid;
        }

        public static bool MultiNormalDice(int count, out string msg)
        {
            bool isValid = true;
            msg = string.Empty;
            if (count > DICE_ROW_MAX)
            {
                msg = $"擲骰超過20次，機器人要死掉了{LineEmoji.GetShock()}";
                isValid = false;
            }

            return isValid;
        }
    }
}
