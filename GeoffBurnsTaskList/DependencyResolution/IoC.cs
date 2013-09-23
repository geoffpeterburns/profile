using GeoffBurnsTaskList.Models;
using GeoffBurnsTaskList.Properties;
using StructureMap;
namespace GeoffBurnsTaskList {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IPersistentStore<Profile>>()
                                .Singleton()
                                .Use(
                                    () =>
                                    new JsonFilePersistentStore<Profile>(System.Web.HttpContext.Current.Server.MapPath(Settings.Default.FileNameForPersistentStore)));
                            x.For<IProfileListModel>()
                                .Singleton()
                                .Use<ProfileListModel>();
                            x.For<IRepository<Profile>>()
                             .Singleton()
                             .Use<Repository<Profile>>();
                        });
            return ObjectFactory.Container;
        }
    }
}