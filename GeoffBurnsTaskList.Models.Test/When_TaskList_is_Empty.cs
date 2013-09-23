using System.Linq;
using NUnit.Framework;
using StructureMap;

namespace GeoffBurnsTaskList.Models.Test
{
    [TestFixture]
    class When_TaskList_is_Empty
    {
        private IContainer _container;

        [SetUp]
        public void SetUp()
        {
           _container = (IContainer)IoC.Initialize();
        }
      
        [Test]
        public void Then_TodaysTask_Should_be_Empty()
        {
            //Arrange
            var taskList = _container.GetInstance<IProfileListModel>();

            //Act

            //Assert
            Assert.False(taskList.AllProfiles.Any());
        }
        [Test]
        public void And_New_Task_is_Added_Then_TodaysTask_Should_not_be_Empty()
        {
            //Arrange

            var repo = _container.GetInstance<IRepository<Profile>>();
            var taskList = _container.GetInstance<IProfileListModel>();

            //Act
            repo.Create(new Profile());

            //Assert
            Assert.That(taskList.AllProfiles.Any());
        }
    }
}
