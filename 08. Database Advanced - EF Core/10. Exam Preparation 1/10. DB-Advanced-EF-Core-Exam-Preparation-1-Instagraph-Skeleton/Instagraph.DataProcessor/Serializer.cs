using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AutoMapper.QueryableExtensions;
using Instagraph.Data;
using Instagraph.DataProcessor.DTOs;
using Newtonsoft.Json;

namespace Instagraph.DataProcessor
{
    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .OrderBy(p => p.Id)
                .ProjectTo<PostExportDto>();

            var serializedPosts = JsonConvert.SerializeObject(posts, Formatting.Indented);
            return serializedPosts;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(f => f.FollowerId == c.UserId))))
                .OrderBy(u => u.Id)
                .ProjectTo<UserExportDto>()
                .ToList();

            var serializedUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
            return serializedUsers;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var userDtosToExport = new List<UserMostCommentsDto>();

            var users = context.Users
                .Select(u => new
                {
                    Username = u.Username,
                    PostsCommentCount = u.Posts.Select(p => p.Comments.Count).ToArray()
                })
                .ToList();

            var doc = new XDocument();
            doc.Add(new XElement("users"));

            foreach (var user in userDtosToExport)
            {
                var userElement = new XElement("user");
                userElement.Add(new XElement("Username", user.Username));
                userElement.Add(new XElement("MostComments", user.MostComments));
                doc.Root.Add(userElement);
            }

            var result = doc.ToString();
            return result;
        }
    }
}
