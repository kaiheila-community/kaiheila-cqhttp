﻿using System;
using Newtonsoft.Json.Linq;

namespace Kaiheila.Cqhttp.Cq.Events
{
    public abstract class CqEventBase
    {
        protected CqEventBase(CqContext context)
        {
            _context = context;
        }

        public JObject Result;

        /// <summary>
        /// CQHTTP上下文。
        /// </summary>
        protected readonly CqContext _context;
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    sealed class CqEventAttribute : Attribute
    {
        public CqEventAttribute(Type type) => Type = type;

        public readonly Type Type;
    }
}
