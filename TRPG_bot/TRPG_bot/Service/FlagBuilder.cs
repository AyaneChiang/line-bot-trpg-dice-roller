using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRPG_bot.Service
{
    public static class FlagBuilder
    {
        public static string Get()
        {
            return FLAG_COMMENT_ARRAY[DiceRoller.GetRandom(FLAG_COMMENT_ARRAY.Length-1)];
        }

        private static readonly string[] FLAG_COMMENT_ARRAY =
        {
            $"玩完這局，我就要回老家結婚了{LineEmoji.GetRabbitHeart()}",
            $"家鄉的老婆和女兒還在等我回去{Emoji.GetMomDaughter()}",
            $"已經沒什麼好怕的了！{LineEmoji.GetRabbitProud()}",
            $"我這麼帥，怎麼可能會死呢？{LineEmoji.GetJamesHandsome()}",
            $"我一定會活著回來的！{LineEmoji.GetRabbitProud()}",
            $"要像乖孩子一樣等我回來喔{LineEmoji.GetCuteCry()}",
            $"我去去就回來！{LineEmoji.GetJamesHandsome()}",
            $"你們先走，我很快就會跟上的。",
            $"這票幹完我就要金盆洗手了",
            $"明天是女兒的生日…",
            $"我的小孩就快要出生了…",
            $"這是我女兒的照片，很可愛吧？",
            $"真希望這份幸福可以永遠持續下去。",
            $"等到一切結束後，我有些話想跟妳說！",
            $"拜託了…你們是這個世界最後的希望！",
            $"這段時間我過的很開心啊。",
            $"這把劍給你，等一切結束之後記得還給我啊！"
        };
    }
}
