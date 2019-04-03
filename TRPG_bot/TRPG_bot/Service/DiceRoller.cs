using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TRPG_bot.Model;

namespace TRPG_bot.Service
{
    public class DiceRoller
    {
        private static readonly Random random = new Random();

        /// <summary>
        /// 取得隨機數字
        /// </summary>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static int GetRandom(int max, int min = 1)
        {
            return random.Next(min, max+1);
        }

        /// <summary>
        /// 基礎骰子
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string rowNormalDice(string input)
        {
            var matchList = Regex.Matches(input, Global.REG_SPACE);
            string action = matchList.First().Value;
            int times = int.Parse(Regex.Split(action, "d")[0]);
            int sides = int.Parse(Regex.Split(action, "d")[1].Split("+")[0]);

            string comment = matchList.Count > 1 ? matchList.Last().Value : string.Empty;
            string history = string.Empty;
            string plus = string.Empty;
            int dice_total = 0;
            int total = 0;

            for(int i = 0; i < times; i++)
            {
                int num_dice = GetRandom(sides);
                dice_total += num_dice;
                history += num_dice;
                history += i+1 == times ? string.Empty : "+";
            }

            total += dice_total;

            if (Regex.Split(action, "d")[1].Split("+").Length > 1)
            {
                int num_plus = int.Parse(action.Split("+")[1]);
                total += num_plus;
                plus += "+" + num_plus;
            }

            return $"{comment} {dice_total}[{history}]{plus} = {total}";

        }
    }
}
