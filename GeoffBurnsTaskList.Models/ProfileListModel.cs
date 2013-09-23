using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoffBurnsTaskList.Models
{
    public class ProfileListModel : IProfileListModel
    {
        private readonly IEnumerable<Profile> _Profiles;

        public ProfileListModel(IRepository<Profile> Profiles)
        {
            _Profiles = Profiles;
        }


        public IEnumerable<Profile> AllProfiles
        {
            get { return _Profiles; }
        }
    }
}