namespace OnBoarding.EntityContext.Migrations
{
    using OnBoarding.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web.Script.Serialization;

    public sealed class Configuration : DbMigrationsConfiguration<OnBoarding.EntityContext.OnBoardingContext>
    {

        private readonly Dictionary<string, Tuple<string, string, bool>> SeedItems = new Dictionary<string, Tuple<string, string, bool>>
        {
             // {Json/Entity name, PrimaryKeyId, UniqueKeyId, IsCombinedKey}
             { "Mode", new Tuple<string, string, bool>("Id", "Code", false)},
             { "Role", new Tuple<string, string, bool>("Id", "Code", false) },
             { "UserRole", new Tuple<string, string, bool>("Id", "Name", false)},
             { "Team", new Tuple<string, string, bool>("Id", "Code", false)},
             { "AccountRole", new Tuple<string, string, bool>("Id", "Code", false) },
             { "Designation", new Tuple<string, string, bool>("Id", "Code", false) },
             { "Project", new Tuple<string, string, bool>("Id", "Code", false) }//,
            // { "KnowledgeTransfer", new Tuple<string, string, bool>("Id", "Name", false) },
            // { "ProjectTeam", new Tuple<string, string, bool>("ProjectId", "TeamId", false) },
            // { "Associate", new Tuple<string, string, bool>("Id", "Code", false) },
            // { "AssociateDetails", new Tuple<string, string, bool>("AssociateId", "AssociateId", false) },
            // { "AssociateUserRole", new Tuple<string, string, bool>("AssociateId", "UserRoleId", true) }
        };

        public bool IsInitialLoad { get; set; }

        public Configuration()
        {
        }

        public Configuration(bool isInitialLoad)
        {
            IsInitialLoad = isInitialLoad;
        }

        protected override void Seed(OnBoarding.EntityContext.OnBoardingContext context)
        {
            var folderPath = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName}\\OnBoarding.API\\Seed\\";

            SeedItems.ToList().ForEach((file) =>
            {
                var filePath = $"{folderPath}{file.Key}.json";

                if (File.Exists(filePath))
                {
                    var tableEntity = Type.GetType($"{typeof(Role).Namespace}.{file.Key}, {typeof(Role).Assembly}");
                    GetType()
                        .GetMethod("SaveSeed")
                        .MakeGenericMethod(tableEntity)
                        .Invoke(this, new object[] { filePath, file.Value.Item1, file.Value.Item2, file.Value.Item3 });
                }
            });
        }

        public void SaveSeed<T>(string filePath, string primaryKey, string uniqueKey, bool isCombinedKey) where T : class
        {
            var fileData = File.ReadAllText(filePath);
            var entityData = new JavaScriptSerializer().Deserialize<List<T>>(fileData);
            using (var databaseContext = new OnBoardingContext("OnBoarding"))
            {
                entityData.ForEach((json) =>
                {
                    object primaryKeyValue = null;
                    if (!string.IsNullOrEmpty(primaryKey))
                    {
                        primaryKeyValue = GetPropertyValue(json, primaryKey);
                    }
                    if (!IsExist(databaseContext, uniqueKey, primaryKey, isCombinedKey, json)
                    || primaryKeyValue == null
                    || string.IsNullOrEmpty(uniqueKey))
                    {
                        if (!string.IsNullOrEmpty(primaryKey) && !IsInitialLoad)
                        {
                            SetPropertyValue(json, "Id", Guid.NewGuid());
                        }
                        var data = databaseContext.Set<T>();
                        data.Add(json);
                    }
                });
                databaseContext.SaveChanges();
            }
        }

        private bool IsExist<T>(OnBoardingContext onBoardingContext, string keyOne, string keyTwo, bool isCombinedKey, T data) where T: class
        {
            if (isCombinedKey)
            {
                return onBoardingContext.Set<T>().ToList().Any(u => GetProperty(u, keyOne).GetValue(u, null).ToString() == GetPropertyValue(data, keyOne).ToString() && GetProperty(u, keyTwo).GetValue(u, null).ToString() == GetPropertyValue(data, keyTwo).ToString());
            }

            return onBoardingContext.Set<T>().ToList().Any(u => GetProperty(u, keyOne).GetValue(u, null).ToString() == GetPropertyValue(data, keyOne).ToString());
        }

        private PropertyInfo GetProperty(object data, string propertyName)
        {
            var property = data.GetType().GetProperties().Where(p => p.Name == propertyName).First();
            return property;
        }

        private object GetPropertyValue(object data, string propertyName)
        {
            var property = data.GetType().GetProperties().Where(p => p.Name == propertyName).First();
            var value = property.GetValue(data, null);
            return value;
        }

        private void SetPropertyValue(object data, string propertyName, object value)
        {
            var property = data.GetType().GetProperties().Where(p => p.Name == propertyName).FirstOrDefault();
            if (property != null)
            {
                property.SetValue(data, value);
            }
        }
    }
}
