using System;

namespace xml2json
{
    public class Post
    {
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public int ViewCount { get; set; }
        public int OwnerUserId { get; set; }
        public string Body { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public int AnswerCount { get; set; }
        public int CommentCount { get; set; }
        public int FavoriteCount { get; set; }
    }
}