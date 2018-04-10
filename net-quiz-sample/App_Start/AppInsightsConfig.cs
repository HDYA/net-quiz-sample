using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace net_quiz_sample.App_Start
{
    public class AppInsightsConfig
    {
        public static void Configure()
        {
            String ikey = Environment.GetEnvironmentVariable(ConfigurationManager.AppSettings["AppinsightInstrumentKeyName"]);
            if (ikey != null && ikey.Length != 0)
            {
                TelemetryConfiguration.Active.InstrumentationKey = ikey;

                new TelemetryClient().TrackEvent("Application started");
            }
        }
    }
}