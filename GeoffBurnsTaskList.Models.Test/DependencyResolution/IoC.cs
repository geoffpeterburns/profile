using GeoffBurnsTaskList.Models;
using Moq;
using StructureMap;
namespace GeoffBurnsTaskList {
    public static class IoC
    {
        public static Mock<IPersistentStore<Profile>> MockStore = new Mock<IPersistentStore<Profile>>();
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
                                    MockStore.Object);
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