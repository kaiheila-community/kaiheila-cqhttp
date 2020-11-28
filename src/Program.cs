﻿using System;
using System.Composition;
using System.Linq;
using Kaiheila.Cqhttp.Cq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kaiheila.Cqhttp
{
    /// <summary>
    /// 应用程序的入口点。
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// 应用程序的入口点。
        /// </summary>
        /// <param name="args">应用程序初始化命令参数。</param>
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
            {
                Console.WriteLine("出现异常。这个异常是由kaiheila-cqhttp引起的。");
                Console.WriteLine(eventArgs.ExceptionObject);
            };

            IHost host = CreateHostBuilder(args).Build();

            _ = host.Services.GetService<CqHost>();

            host.Run();
        }

        /// <summary>
        /// 创建泛型主机构建器。
        /// </summary>
        /// <param name="args">应用程序初始化命令参数。</param>
        /// <returns>泛型主机构建器。</returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x =>
                        x.GetTypes()
                            .Where(type => Attribute.GetCustomAttribute(type, typeof(ExportAttribute)) is not null)))
                        services.AddSingleton(type);
                });
    }
}
