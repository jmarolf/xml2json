using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace xml2json
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var list = new List<Post>();
            var path2XmlFile = args[0];
            var document = XDocument.Load(path2XmlFile);
            var rows = document.Root.Elements("row").ToArray();
            foreach (var row in rows)
            {
                var p = new Post();
                foreach (var attribute in row.Attributes())
                {
                    var name = attribute.Name.ToString();
                    var value = attribute.Value;
                    Add(name, value, p);
                }
                list.Add(p);
            }

            var posts = new PostsCollection { Posts = list.ToArray() };

            using (var file = File.CreateText(Path.GetFullPath(path2XmlFile).Replace(".xml", ".json")))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, posts);
            }

            void Add(string name, string value, Post post)
            {
                switch (name)
                {
                    case "Id":
                        post.Id = int.Parse(value);
                        return;
                    case "PostTypeId":
                        post.PostTypeId = int.Parse(value);
                        return;
                    case "CreationDate":
                        post.CreationDate = DateTime.Parse(value);
                        return;
                    case "Score":
                        post.Score = int.Parse(value);
                        return;
                    case "ViewCount":
                        post.ViewCount = int.Parse(value);
                        return;
                    case "Body":
                        post.Body = value;
                        return;
                    case "OwnerUserId":
                        post.OwnerUserId = int.Parse(value);
                        return;
                    case "LastActivityDate":
                        post.LastActivityDate = DateTime.Parse(value);
                        return;
                    case "Title":
                        post.Title = value;
                        return;
                    case "Tags":
                        post.Tags = value;
                        return;
                    case "AnswerCount":
                        post.AnswerCount = int.Parse(value);
                        return;
                    case "CommentCount":
                        post.CommentCount = int.Parse(value);
                        return;
                    case "FavoriteCount":
                        post.FavoriteCount = int.Parse(value);
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
