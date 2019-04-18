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
            return random.Next(min, max + 1);
        }

        #region 基本骰子
        /// <summary>
        /// 基礎骰子
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RowNormalDice(string input)
        {
            var fullCmd = Regex.Match(input, Global.REG_NOT_SPACE).Value;
            var cmdList = fullCmd.Split(new char[] { '+', '-' });
            string result = string.Empty;
            int total = 0;
            int count = 1;

            foreach (var cmd in cmdList)
            {
                var math = count == 1 ? "+" : fullCmd.FirstOrDefault().ToString();
                var subLength = count == 1 ? 0 : 1;
                fullCmd = fullCmd.Substring(subLength, fullCmd.Length - subLength);

                if (count > 1)
                    result += math;

                // 骰子
                if (Regex.IsMatch(cmd, Global.REG_DICE_DEFAULT))
                {
                    if (!ValidHelpler.NormalDice(cmd, out string msg))
                        return msg;
                    result += RowDice(cmd, out int cmdTotal);
                    switch (math)
                    {
                        case "+":
                            total += cmdTotal;
                            break;
                        case "-":
                            total -= cmdTotal;
                            break;
                        default:
                            break;
                    }
                }
                // 數字
                else if (Regex.IsMatch(cmd, Global.REG_NUMS))
                {
                    result += cmd;
                    switch (math)
                    {
                        case "+":
                            total += int.Parse(cmd);
                            break;
                        case "-":
                            total -= int.Parse(cmd);
                            break;
                        default:
                            break;
                    }
                }
                fullCmd = fullCmd.Substring(cmd.Length, fullCmd.Length - cmd.Length);
                count++;
            }

            return $"{result} = {total.ToString().PadLeft(2)}";

        }

        /// <summary>
        /// 處理骰子
        /// </summary>
        /// <param name="command"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static string RowDice(string command, out int total)
        {
            total = 0;
            int times = int.Parse(Regex.Split(command, "d")[0]);
            int sides = int.Parse(Regex.Split(command, "d")[1]);
            string history = string.Empty;

            for (int i = 0; i < times; i++)
            {
                int num_dice = GetRandom(sides);
                total += num_dice;
                history += num_dice.ToString().PadLeft(2);
                history += i + 1 == times ? string.Empty : "+";
            }

            return $"{total.ToString().PadLeft(2)}[{history}]";
        }

        /// <summary>
        /// 基本骰子輸出字串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetNormalDiceResult(string input)
        {
            return $"{input}\n{RowNormalDice(input)}";
        }
        #endregion

        #region 多次基本骰子
        /// <summary>
        /// 多次基本骰子
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RowMultiNormalDice(string input)
        {
            var matchList = Regex.Matches(input, Global.REG_NOT_SPACE);
            int times = int.Parse(matchList.First().Value);
            string action = matchList[1].Value;

            #region 防呆
            string msg = string.Empty;
            if (!ValidHelpler.MultiNormalDice(times, out msg))
                return msg;
            #endregion

            string result =
                $"{input}\n" +
                $"==================\n";

            for (int i = 0; i < times; i++)
            {
                result += $"{i + 1}# ";
                result += RowNormalDice(action);
                result += i == times - 1 ? string.Empty : "\n";
            }

            return result;
        }
        #endregion

        #region 猜拳
        /// <summary>
        /// 猜拳
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DoJianken(string input)
        {
            Match match = Regex.Match(input, Global.REG_ROCK_PAPER_SCISSORS);
            if (match.Success)
            {
                string action = match.Value;
                string player = Regex.Split(action, Global.REG_SPACE).Last();
                JiankenType type = player.ToEnum<JiankenType>();
                return $"{EnumExt.GetRandom<JiankenType>().GetEmoji()} vs {type.GetEmoji()}";
            }
            else
            {
                return EnumExt.GetRandom<JiankenType>().GetEmoji();
            }
        }
        #endregion
    }
}
