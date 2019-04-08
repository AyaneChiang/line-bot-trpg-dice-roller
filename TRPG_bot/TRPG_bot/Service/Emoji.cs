using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Service
{
    public static class LineEmoji
    {
        public static string GetShock() => char.ConvertFromUtf32(0x10007D);
        public static string GetRabbitHeart() => char.ConvertFromUtf32(0x100096);
        public static string GetRabbitProud() => char.ConvertFromUtf32(0x100097);
        public static string GetJamesHandsome() => char.ConvertFromUtf32(0x10008A);
        public static string GetCuteCry() => char.ConvertFromUtf32(0x100018);        
    }
    public static class Emoji
    {
        public static string GetMomDaughter() => char.ConvertFromUtf32(0x1f469) + char.ConvertFromUtf32(0x200d) + char.ConvertFromUtf32(0x1f467);
    }
}
