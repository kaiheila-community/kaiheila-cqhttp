﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kaiheila.Cqhttp.Storage
{
    /// <summary>
    /// 应用配置。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Config
    {
        /// <summary>
        /// CQHTTP配置。
        /// </summary>
        [JsonProperty("cqhttp")]
        public CqConfig CqConfig { get; set; } = new CqConfig();
    }

    /// <summary>
    /// CQHTTP配置。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CqConfig
    {
        /// <summary>
        /// CQHTTP HTTP主机配置。
        /// </summary>
        [JsonProperty("http")]
        public CqHttpHostConfig CqHttpHostConfig { get; set; } = new CqHttpHostConfig();

        /// <summary>
        /// CQHTTP HTTP POST主机配置。
        /// </summary>
        [JsonProperty("http_post")]
        public CqHttpPostHostConfig CqHttpPostHostConfig { get; set; } = new CqHttpPostHostConfig();
    }

    /// <summary>
    /// CQHTTP HTTP主机配置。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CqHttpHostConfig
    {
        /// <summary>
        /// 是否启用HTTP。
        /// </summary>
        [JsonProperty("enable")]
        public bool Enable { get; set; } = true;

        /// <summary>
        /// HTTP服务器监听的IP。
        /// </summary>
        [JsonProperty("host")]
        public string Host { get; set; } = "0.0.0.0";

        /// <summary>
        /// HTTP服务器监听的端口。
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; } = 5700;
    }

    /// <summary>
    /// CQHTTP HTTP POST主机配置。
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CqHttpPostHostConfig
    {
        /// <summary>
        /// HTTP POST事件上报 URL。
        /// </summary>
        /// <remarks>
        /// 键为Url，值为对应Url的Secret。
        /// </remarks>
        [JsonProperty("urls")]
        public Dictionary<string, string> UrlList { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 以秒为单位的HTTP POST超时时间。
        /// </summary>
        /// <remarks>
        /// 0表示不设置超时。
        /// </remarks>
        [JsonProperty("timeout")]
        public int Timeout { get; set; }
    }
}
