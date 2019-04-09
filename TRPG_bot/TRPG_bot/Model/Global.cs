using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{
    public class Global
    {
        #region Request URL
        public const string LINE_API_URL_REPLY = "https://api.line.me/v2/bot/message/reply";
        #endregion

        /// <summary>
        /// 基本骰子(多次)
        /// </summary>
        public const string REG_DICE_DEFAULT_MULTIPLE = @"^\d+\s+\d+d\d+(\+\d+)?";
        /// <summary>
        /// 基本骰子
        /// </summary>
        public const string REG_DICE_DEFAULT = @"^\d+d\d+(\+\d+)?";
        /// <summary>
        /// 空白
        /// </summary>
        public const string REG_SPACE = @"\s+";
        /// <summary>
        /// 非空白字元
        /// </summary>
        public const string REG_NOT_SPACE = @"\S+";
        /// <summary>
        /// 死亡Flag
        /// </summary>
        public const string REG_FLAG_BUILDER = @"(立|死亡)flag";
        /// <summary>
        /// 猜拳
        /// </summary>
        public const string REG_ROCK_PAPER_SCISSORS = @"來猜拳\s+(剪刀|石頭|布)";
        /// <summary>
        /// 查詢指令
        /// </summary>
        public const string REG_HELP_COMMAND = @"bothelp";
    }
}
