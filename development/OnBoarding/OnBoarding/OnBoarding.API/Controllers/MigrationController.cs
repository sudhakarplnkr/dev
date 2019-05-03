using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using OnBoarding.EntityContext;

namespace OnBoardingWEB.Controllers
{
    [RoutePrefix("api/migration")]
    public class MigrationController : ApiController
    {
        [HttpGet]
        [Route("generate")]
        public void Get()
        {
            var folderPath = $"{AppDomain.CurrentDomain.BaseDirectory}Seed\\";

            var allModels = GetTypesInNamespace(Assembly.Load("OnBoarding.Entities"), "OnBoarding.Entities");

            allModels.ToList().ForEach((classType) =>
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var filePath = $"{folderPath}{classType.Name}.json";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                using (var fileStream = File.Create(filePath))
                {
                    var tableEntity = Type.GetType($"{classType.Namespace}.{classType.Name}, {classType.Assembly}");
                    var fileBytes = (byte[])GetType()
                        .GetMethod("GetSerializedData")
                        .MakeGenericMethod(tableEntity)
                        .Invoke(this, new object[] { });
                    fileStream.Write(fileBytes, 0, fileBytes.Length);
                }
            });
        }

        [NonAction]
        public object GetSerializedData<T>() where T : class
        {
            var ser = new JavaScriptSerializer();
            using (var databaseContext = new OnBoardingContext("OnBoarding"))
            {
                databaseContext.Configuration.LazyLoadingEnabled = false;

                var data = databaseContext.Set<T>().ToList();

                var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                var info = new UTF8Encoding(true).GetBytes(json);
                return info;
            }
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
    }
}
