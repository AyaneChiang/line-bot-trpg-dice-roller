using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TRPG_bot.Model
{

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
}
