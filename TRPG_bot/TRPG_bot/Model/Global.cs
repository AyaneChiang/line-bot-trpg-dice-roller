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
        public const string REG_SPACE = @"\S+";
        /// <summary>
        /// 死亡Flag
        /// </summary>
        public const string REG_FLAG_BUILDER = @"(立|死亡)flag";
    }
}
