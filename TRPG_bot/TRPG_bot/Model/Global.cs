using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{
    public class Global
    {
        public const string CHANNEL_ACCESS_TOKEN = "sdWqXqgT5MB8upxueEnKLZqOuwY2g+a62JqOI1YYBlt7SGmiFGBRZ/6V+XQxvh1GHDC/UdhqUeyWHwxSAgcXMJMgDqu5e4sDiGVucuAEYxqIXQWW9UsdC3vdfloiTw788HzOPNElSpxhndoonMQ/uwdB04t89/1O/w1cDnyilFU=";

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
        public const string REG_SPACE = @"\S+";
    }
}
