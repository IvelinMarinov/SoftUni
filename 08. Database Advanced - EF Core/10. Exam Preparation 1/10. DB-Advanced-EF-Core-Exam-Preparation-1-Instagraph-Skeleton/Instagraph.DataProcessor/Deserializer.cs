using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using Newtonsoft.Json;
using Instagraph.Data;
using Instagraph.DataProcessor.DTOs;
using Instagraph.Models;

namespace Instagraph.DataProcessor
{
    public class Deserializer
    {
        public const string SuccessMsg = "Successfully imported {0}.";
        public const string FailureMsg = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var pictures = JsonConvert.DeserializeObject<List<Picture>>(jsonString);
            var picturesToAdd = new List<Picture>();
            var sb = new StringBuilder();

            foreach (var picture in pictures)
            {
                bool isValid = !string.IsNullOrWhiteSpace(picture.Path) &&
                               !context.Pictures.Any(p => p.Path == picture.Path) &&
                               picture.Size > 0;

                if (!isValid)
                {
                    sb.AppendLine(FailureMsg);
                    continue;
                }

                picturesToAdd.Add(picture);
                sb.AppendLine(string.Format(SuccessMsg, $"Picture {picture.Path}"));
            }

            context.Pictures.AddRange(picturesToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<List<UserImportDto>>(jsonString);
            var usersToAdd = new List<User>();
            var sb = new StringBuilder();

            foreach (var userDto in userDtos)
            {
                bool isValid = userDto.Username != null &&
                               userDto.Username.Length <= 30 &&
                               !context.Users.Any(u => u.Username == userDto.Username) &&
                               userDto.Password != null &&
                               userDto.Password.Length <= 20 &&
                               context.Pictures.Any(p => p.Path == userDto.ProfilePicture);

                if (!isValid)
                {
                    sb.AppendLine(FailureMsg);
                    continue;
                }

                usersToAdd.Add(new User
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    ProfilePictureId = context.Pictures
                                        .FirstOrDefault(p => p.Path == userDto.ProfilePicture)
                                        .Id
                });
                sb.AppendLine(string.Format(SuccessMsg, $"User {userDto.Username}"));
            }

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var followerDtos = JsonConvert.DeserializeObject<List<FollowerImporrtDto>>(jsonString);
            var followersToAdd = new HashSet<UserFollower>();
            var sb = new StringBuilder();

            foreach (var followerDto in followerDtos)
            {
                User user = context.Users
                    .FirstOrDefault(u => u.Username == followerDto.User);

                User follower = context.Users
                    .FirstOrDefault(u => u.Username == followerDto.Follower);

                UserFollower userFollower = context.UsersFollowers
                    .FirstOrDefault(uf => uf.User.Username == followerDto.User && 
                                    uf.Follower.Username == followerDto.Follower);
                
                bool isValid = user != null && follower != null && userFollower == null;

                if (!isValid)
                {
                    sb.AppendLine(FailureMsg);
                    continue;
                }

                bool alreadyFollowed = followersToAdd.Any(f => f.UserId == user.Id && f.FollowerId == follower.Id);
                if (alreadyFollowed)
                {
                    sb.AppendLine(FailureMsg);
                    continue;
                }

                followersToAdd.Add(new UserFollower
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                });
                sb.AppendLine(string.Format(SuccessMsg, $"Follower {follower.Username} to User {user.Username}"));
            }

            context.UsersFollowers.AddRange(followersToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var doc = XDocument.Parse(xmlString);
            var elements = doc.Root.Elements();
            var sb = new StringBuilder();
            var postsToAdd = new List<Post>();

            foreach (var postElement in elements)
            {
                var caption = postElement.Element("caption")?.Value;
                var username = postElement.Element("user")?.Value;
                var picturePath = postElement.Element("picture")?.Value;

                int? userId = context.Users.FirstOrDefault(u => u.Username == username)?.Id;
                int? pictureId = context.Pictures.FirstOrDefault(p => p.Path == picturePath)?.Id;

                bool isValid = userId != null && pictureId != null;

                if (!isValid)
                {
                    sb.AppendLine(FailureMsg);
                    continue;
                }

                postsToAdd.Add(new Post
                {
                    UserId = userId.Value,
                    PictureId = pictureId.Value,
                    Caption = caption
                });

                sb.AppendLine(string.Format(SuccessMsg, $"Post {caption}"));
            }

            context.Posts.AddRange(postsToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var doc = XDocument.Parse(xmlString);
            var elements = doc.Root.Elements();
            var sb = new StringBuilder();
            var commentsToAdd = new List<Comment>();

            foreach (var postElement in elements)
            {
                var content = postElement.Element("content")?.Value;
                var username = postElement.Element("user")?.Value;
                var postEl = postElement.Element("post");

                var postIdStr = string.Empty;
                if (postEl != null)
                {
                    postIdStr = postEl.Attribute("id")?.Value;
                }

                int postId = 0;
                if (postIdStr != String.Empty)
                {
                    postId = int.Parse(postIdStr);
                }

                int? userId = context.Users.FirstOrDefault(u => u.Username == username)?.Id;
                Post post = context.Posts.FirstOrDefault(p => p.Id == postId);

                bool isValid = userId != null && post != null;

                if (!isValid)
                {
                    sb.AppendLine(FailureMsg);
                    continue;
                }

                commentsToAdd.Add(new Comment
                {
                    PostId = postId,
                    UserId = userId.Value,
                    Content = content
                });

                sb.AppendLine(string.Format(SuccessMsg, $"Comment {content}"));
            }

            context.Comments.AddRange(commentsToAdd);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
    }
}
