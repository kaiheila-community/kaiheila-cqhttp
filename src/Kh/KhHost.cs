﻿using System;
using System.Composition;
using Kaiheila.Client;
using Kaiheila.Client.V2;
using Kaiheila.Cqhttp.Storage;
using Microsoft.Extensions.Logging;

namespace Kaiheila.Cqhttp.Kh
{
    /// <summary>
    /// Kaiheila主机。
    /// </summary>
    [Export]
    public class KhHost : IDisposable
    {
        #region Constructor

        /// <summary>
        /// 初始化Kaiheila主机。
        /// </summary>
        /// <param name="logger">Kaiheila主机日志记录器。</param>
        /// <param name="configHelper">提供访问应用配置能力的帮助类型。</param>
        public KhHost(
            ILogger<KhHost> logger,
            ConfigHelper configHelper)
        {
            _logger = logger;
            _configHelper = configHelper;

            _logger.LogInformation(
                $"使用{_configHelper.Config.KhConfig.KhClientMode}的Bot提供程序初始化Kaiheila主机。");

            switch (_configHelper.Config.KhConfig.KhClientMode)
            {
                case KhClientMode.WebHook:
                    throw new NotImplementedException();
                case KhClientMode.WebSocket:
                    throw new NotImplementedException();
                case KhClientMode.V2:
                    Bot = new V2Client(
                        _configHelper.Config.KhConfig.KhAuthConfig.CookieAuth,
                        new Uri(
                            $"ws://{_configHelper.Config.KhConfig.KhClientV2Config.Host}:{_configHelper.Config.KhConfig.KhClientV2Config.Port}"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Lifecycle

        public void Dispose()
        {
            Bot.Dispose();
        }

        #endregion

        #region Bot

        /// <summary>
        /// Kaiheila机器人。
        /// </summary>
        public readonly IBot Bot;

        #endregion

        /// <summary>
        /// Kaiheila主机日志记录器。
        /// </summary>
        private readonly ILogger<KhHost> _logger;

        /// <summary>
        /// 提供访问应用配置能力的帮助类型。
        /// </summary>
        private readonly ConfigHelper _configHelper;
    }
}
