//using System;
//using System.Numerics;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    class Task1
//    {
//        public static void Main_soc()
//        {


//            Console.WriteLine("rvge");
           
//            Console.ReadLine();
//        }
  
            


 

//        public interface ISocialNetwork
//        {
//            IMember AddMember(string firstName, string lastName, string city, string country);
//            IMember FindMemberById(int id);
//            IEnumerable<IMember> FindMember(string search);
//            int MemberCount { get; }

//        }
//        public class SocialNetwork : ISocialNetwork
//        {
//            List<IMemberProfile> _members = new List<IMemberProfile>();
//            // Adds a new member and returns the added member
//            public IMember AddMember(string firstName, string lastName, string city, string country)
//            {
//               MemberProfile a = new MemberProfile(_members.Count, firstName, lastName, city, country);
//                _members.Add(a);
//                return a;
//            }

//            // Returns the member with the id
//            public IMember FindMemberById(int id)
//            {
//                return null;
//            }

//            // Returns a list of members by searching all fields in the profile
//            public IEnumerable<IMember> FindMember(string search)
//            {
//                return null;
//            }

//            // Total number of members currently in the social network
//            public int MemberCount { get { return 0; } }
//        }

//        public interface IMember
//        {
//            int Id { get; }
//            IMemberProfile Profile { get; }
//            IEnumerable<IMember> Friends { get;  }
//            IEnumerable<IMember> Pending { get; }
//            IEnumerable<IPost> Posts { get; }
//            void AddFriendRequest(IMember from);
//            void RemoveFriendRequest(IMember member);
//            void RemoveFriend(IMember member);
//            IEnumerable<IMember> GetFriends(int level, IList<int> filter);
//            IPost AddPost(string message);
//            void RemovePost(int id);
//            IEnumerable<IPost> GetFeed();
//        }
//        public class Member : IMember
//        {
//            private List<IMember> _friends;
//            private List<IMember> _requests;


//            private void init()
//            {
//                _friends = new List<IMember>();
//                _requests = new List<IMember>();

//            }


//            // Id of member. Must be unique and sequential. 
//            public int Id { get; }
//            // Member profile
//            public IMemberProfile Profile { get; }
//            // List of friends
//            public IEnumerable<IMember> Friends { get { return null; } }
//            // List of pending friend requests
//            public IEnumerable<IMember> Pending { get { return null; } }
//            // Members posts
//            public IEnumerable<IPost> Posts { get { return null; } }

//            // Adds a friend request for this member. from - the member making the friend request 
//            public void AddFriendRequest(IMember from)
//            {
//                _requests.Add(from);
//            }

//            // Confirms a pending friend request
//            public void ConfirmFriend(IMember member)
//            {
//                _friends.Add(member);

//            }

//            // Removes a pending friend request
//            public void RemoveFriendRequest(IMember member)
//            {
//                _requests.Remove(member);
//            }

//            // Removes a friend
//            public void RemoveFriend(IMember member)
//            {
//                _friends.Remove(member);
//            }

//            // Returns a list of all friends. level - depth (1 - friends, 2 - friends of friends ...)
//            public IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null)
//            {
//                if (level<=0)
//                {
//                    return null;
//                }
//                List<IMember> result = new List<IMember>();
//                for(int i =0;i<level;i++)
//                {
//                    result.AddRange(_friends);
//                    foreach(var a in result)
//                    {
//                        GetFriends(level - 1);
//                    }
//                }
//                return result;
//            }

//            // Adds a new post to members feed
//            public IPost AddPost(string message)
//            {
//                return null;
//            }

//            // Removes the post with the id
//            public void RemovePost(int id)
//            {

//            }

//            // Returns members feed as a list of posts. Should also return posts of friends.
//            public IEnumerable<IPost> GetFeed()
//            {
//                return null;
//            }
//        }

//        public interface IMemberProfile
//        {
//            int MemberId { get; set; }
//            string Firstname { get; set; }
//            string Lastname { get; set; }
//            string City { get; set; }
//            string Country { get; set; }
//        }

//        public class MemberProfile : IMemberProfile
//        {
//            // Id of the Member this profile belongs to

//            public MemberProfile(int _id,string _firstName, string _lastname,string _city, string _country)
//            {
//                MemberId = _id;
//                Firstname = _firstName;
//                Lastname = _lastname;
//                City = _city;
//                Country = _country;
//            }
//            public int MemberId { get; set; }

//            public string Firstname { get; set; }
//            public string Lastname { get; set; }
//            public string City { get; set; }
//            public string Country { get; set; }
//        }
//        public interface IPost
//        {
//            int Id { get; set; }
//            IMember Member { get; set; }
//            string Message { get; set; }
//            DateTime Date { get; set; }
//            int Likes { get; set; }
//        }
//        public class Post : IPost
//        {
//            // Id of post. Must be unique and sequential.
//            public int Id { get; set; }
//            // Member that made this post
//            public IMember Member { get; set; }
//            // The post message
//            public string Message { get; set; }
//            // Date and time post was made
//            public DateTime Date { get; set; }
//            // Likes for post
//            public int Likes { get; set; }
//        }
//    }
    
//}
