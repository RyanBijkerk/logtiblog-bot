using System;
using System.Collections.Generic;

namespace logitblog_bot.Models
{
    public class Rootobject
    {
        public string status { get; set; }
        public int count { get; set; }
        public int count_total { get; set; }
        public int pages { get; set; }
        public Post[] posts { get; set; }
        public Query query { get; set; }
    }

    public class Query
    {
        public bool ignore_sticky_posts { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string type { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string title_plain { get; set; }
        public string content { get; set; }
        public string excerpt { get; set; }
        public string date { get; set; }
        public string modified { get; set; }
        public Category[] categories { get; set; }
        public Tag[] tags { get; set; }
        public Author author { get; set; }
        public object[] comments { get; set; }
        public Attachment[] attachments { get; set; }
        public int comment_count { get; set; }
        public string comment_status { get; set; }
        public string thumbnail { get; set; }
        public Custom_Fields custom_fields { get; set; }
        public string thumbnail_size { get; set; }
        public Thumbnail_Images thumbnail_images { get; set; }
    }

    public class Author
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nickname { get; set; }
        public string url { get; set; }
        public string description { get; set; }
    }

    public class Custom_Fields
    {
        public string[] dsq_thread_id { get; set; }
    }

    public class Thumbnail_Images
    {
        public Full full { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Medium medium { get; set; }
        public Medium_Large medium_large { get; set; }
        public Large large { get; set; }
        public ScreenrBlogGridSmall screenrbloggridsmall { get; set; }
        public ScreenrBlogGrid screenrbloggrid { get; set; }
        public ScreenrBlogList screenrbloglist { get; set; }
        public ScreenrServiceSmall screenrservicesmall { get; set; }
    }

    public class Full
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium_Large
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Large
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrBlogGridSmall
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrBlogGrid
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrBlogList
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrServiceSmall
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int parent { get; set; }
        public int post_count { get; set; }
    }

    public class Tag
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int post_count { get; set; }
    }

    public class Attachment
    {
        public int id { get; set; }
        public string url { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string caption { get; set; }
        public int parent { get; set; }
        public string mime_type { get; set; }
        public Images images { get; set; }
    }

    public class Images
    {
        public Full1 full { get; set; }
        public Thumbnail1 thumbnail { get; set; }
        public Medium1 medium { get; set; }
        public Medium_Large1 medium_large { get; set; }
        public Large1 large { get; set; }
        public ScreenrBlogGridSmall1 screenrbloggridsmall { get; set; }
        public ScreenrBlogGrid1 screenrbloggrid { get; set; }
        public ScreenrBlogList1 screenrbloglist { get; set; }
        public ScreenrServiceSmall1 screenrservicesmall { get; set; }
    }

    public class Full1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium_Large1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Large1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrBlogGridSmall1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrBlogGrid1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrBlogList1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class ScreenrServiceSmall1
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

}