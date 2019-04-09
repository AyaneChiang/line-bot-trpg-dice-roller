using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TRPG_bot.Service;

namespace TRPG_bot.Model
{
    public static class EnumExt
    {
        public static T GetRandom<T>()
        {
            Array array = Enum.GetValues(typeof(T));
            return (T)array.GetValue(DiceRoller.GetRandom(array.Length - 1, 0));
        }

        public static string GetEmoji(this JiankenType type)
        {
            switch (type)
            {
                case JiankenType.Paper:
                    return LineEmoji.GetPaper();
                case JiankenType.Rock:
                    return LineEmoji.GetRock();
                case JiankenType.Scissors:
                    return LineEmoji.GetScissors();
                default:
                    return string.Empty;
            }
        }

        public static T ToEnum<T>(this string str)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }
            //throw exception or whatever handling you want or
            return default(T);
        }
    }

    /// <summary>
    /// Webhook Event Type
    /// </summary>
    public enum WebhookEventType
    {
        Message,
        Follow,
        Unfollow,
        Join,
        Leave,
        Postback,
        Beacon,
        AccountLink,
        MemberJoined,
        MemberLeft,
        Things
    }

    /// <summary>
    /// Webhook Event Source Type.
    /// </summary>
    public enum EventSourceType
    {
        User,
        Group,
        Room
    }

    /// <summary>
    /// Webhook event message types.
    /// </summary>
    public enum EventMessageType
    {
        Text,
        Image,
        Video,
        Audio,
        Location,
        Sticker,
        File
    }

    /// <summary>
    /// Reply message types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType
    {
        [EnumMember(Value ="text")]
        Text,
        [EnumMember(Value = "image")]
        Image,
        [EnumMember(Value = "video")]
        Video,
        [EnumMember(Value = "audio")]
        Audio,
        [EnumMember(Value = "location")]
        Location,
        [EnumMember(Value = "sticker")]
        Sticker,
        [EnumMember(Value = "imagemap")]
        Imagemap,
        [EnumMember(Value = "template")]
        Template,
        [EnumMember(Value = "file")]
        File,
        [EnumMember(Value = "flex")]
        Flex,
    }

    public enum JiankenType
    {
        [EnumMember(Value = "布")]
        Paper,
        [EnumMember(Value = "石頭")]
        Rock,
        [EnumMember(Value = "剪刀")]
        Scissors
    }
}
