using System;
using System.Collections.Generic;
using MVCTemplate.Data.Models;
using MVCTemplate.Data.Common;
using System.Linq;

namespace MVCTemplate.Services.Data
{
    public class FriendListService : IFriendListService
    {
        private IDbRepository<FriendsList> friends;

        public FriendListService(IDbRepository<FriendsList> friends)
        {
            this.friends = friends;
        }

        public ICollection<Friend> GetAllFriends(string friendListName)
        {
            var friendList = this.friends.All()
                .SingleOrDefault(g => g.Name.ToLower() == friendListName.ToLower());
       
            return friendList.Friends;
        }
    }
}
