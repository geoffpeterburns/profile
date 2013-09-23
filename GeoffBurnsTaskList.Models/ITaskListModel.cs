using System.Collections.Generic;

namespace GeoffBurnsTaskList.Models
{
    public interface IProfileListModel
    {
     
        IEnumerable<Profile> AllProfiles { get; }
    }
}