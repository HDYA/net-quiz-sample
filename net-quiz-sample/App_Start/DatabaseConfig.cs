using Microsoft.Owin;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System.Data.SqlClient;

[assembly: OwinStartup(typeof(net_quiz_sample.App_Start.DatabaseConfig))]

namespace net_quiz_sample.App_Start
{
    public class DatabaseConfig
    {
        public static void Configuration()
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            string dbServiceName = ConfigurationManager.AppSettings["DBServiceName"];
            string vcapServices = System.Environment.GetEnvironmentVariable("VCAP_SERVICES");

            // if we are in the cloud and DB service was bound successfully...
            ConfigurationManager.AppSettings["UseEnvironmentDatabase"] = "false";
            if (vcapServices != null)
            {
                dynamic json = JsonConvert.DeserializeObject(vcapServices);
                foreach (dynamic obj in json.Children())
                {
                    if (((string)obj.Name).ToLowerInvariant().Contains(dbServiceName))
                    {
                        dynamic credentials = (((JProperty)obj).Value[0] as dynamic).credentials;

                        // Construct connection string with environment variables
                        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                        builder.DataSource = credentials.host + ',' + credentials.port;
                        builder.InitialCatalog = credentials.database;
                        builder.UserID = credentials.username;
                        builder.Password = credentials.password;
                        builder.IntegratedSecurity = false;
                        builder.PersistSecurityInfo = false;
                        builder.MultipleActiveResultSets = false;
                        builder.Encrypt = true;
                        builder.TrustServerCertificate = false;
                        builder.ConnectTimeout = 30;

                        // replace connection string
                        var settings = ConfigurationManager.ConnectionStrings["QuizDbContext"];
                        var fi = typeof(ConfigurationElement).GetField(
                                      "_bReadOnly",
                                      BindingFlags.Instance | BindingFlags.NonPublic);
                        if (settings != null)
                        {
                            fi?.SetValue(settings, false);
                            settings.ConnectionString = builder.ToString();

                            ConfigurationManager.AppSettings["UseEnvironmentDatabase"] = "true";
                        }
                        break;
                    }
                }
            }
        }
    }
}
