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
        public static string GetCuteSatisfy() => char.ConvertFromUtf32(0x10000A);
        public static string GetRock() => char.ConvertFromUtf32(0x100032);
        public static string GetPaper() => char.ConvertFromUtf32(0x100031);
        public static string GetScissors() => char.ConvertFromUtf32(0x100030);
    }
    public static class Emoji
    {
        public static string GetMomDaughter() => char.ConvertFromUtf32(0x1f469) + char.ConvertFromUtf32(0x200d) + char.ConvertFromUtf32(0x1f467);
        public static string GetThumbs() => char.ConvertFromUtf32(0x1F44D);
        public static string GetSteamNose() => char.ConvertFromUtf32(0x1F624);
        public static string GetGirl() => char.ConvertFromUtf32(0x1F467);
        public static string GetBirthdayCake() => char.ConvertFromUtf32(0x1F382);
        public static string GetBaby() => char.ConvertFromUtf32(0x1F476);
        public static string GetBabyBottle() => char.ConvertFromUtf32(0x1F37C);
    }
}
