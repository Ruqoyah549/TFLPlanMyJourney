using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLUITestAutomation
{
    public static class EnvironmentData
    {
        public static string baseUrl { get; } = TestContext.Parameters["baseUrl"];
        public static string browser { get; } = TestContext.Parameters["browser"];
    }
}
