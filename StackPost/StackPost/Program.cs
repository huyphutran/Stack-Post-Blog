using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StackPost
{
    internal class Program
    {
        static List<StackPostBlog> StackPostBlogs = new List<StackPostBlog>();
        static bool inPostMode = true;
        private static object cw;

        static void AddObj()
        {
            // Add 4 new StackPostBlog objects with realistic data
            StackPostBlog blog1 = new StackPostBlog(1, "Tech News", "The latest technology news and updates.");
            StackPostBlog blog2 = new StackPostBlog(2, "Cooking Adventures", "Exploring new recipes and cooking techniques.");
            StackPostBlog blog3 = new StackPostBlog(3, "Travel Stories", "Exciting travel adventures from around the world.");
            StackPostBlog blog4 = new StackPostBlog(4, "Fitness Tips", "Get in shape with our fitness and health advice.");
            StackPostBlog blog5 = new StackPostBlog(4, "Fitness Tips", "Get in shape with our fitness and health advice.");

            // Add these blogs to the list
            StackPostBlogs.Add(blog1);
            StackPostBlogs.Add(blog2);
            StackPostBlogs.Add(blog3);
            StackPostBlogs.Add(blog4);
            StackPostBlogs.Add(blog5);

        }
        static void Main(string[] args)
        {
            AddObj();
            ShowMenu();
        }

        static void AddNewPost()
        {
            DateTime createdAt = DateTime.Now;
            Console.WriteLine($"Enter Title: ");
            string InputTitle = Console.ReadLine();
            Console.WriteLine($"Enter Description: ");
            string InputDes = Console.ReadLine();
            int countID = StackPostBlogs.Count() + 1;
            var AddPost = new StackPostBlog(countID, InputDes, InputTitle);
            Console.WriteLine("\nNew post created:");
            Console.WriteLine($"Title: {AddPost.Title}");
            Console.WriteLine($"Description: {AddPost.Description}");
            Console.WriteLine($"Created At: {createdAt}");
            StackPostBlogs.Add(AddPost);
            BacktoMenu();
        }

        static void ShowMenu()
        {
            Console.WriteLine("Welcome to StackPost");
            Console.WriteLine("Press A to Create a new post");
            Console.WriteLine("Press D to View All Post");

            while (inPostMode)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                char key = char.ToUpper(consoleKeyInfo.KeyChar);
                switch (key)
                {
                    case 'A':
                        ClearandSleep();
                        inPostMode = true;
                        Console.WriteLine(". Add a new Post");
                        AddNewPost();
                        break;
                    case 'D':
                        ClearandSleep();
                        inPostMode = true;
                        Console.WriteLine(". This is Detail Page");
                        ViewPost();
                        break;
                    default:
                        Console.WriteLine(". Invalid command");
                        break;
                }
            }
        }
        static void ClearandSleep()
        {
            Console.Clear();
            Thread.Sleep(500);
        }

        static void BacktoMenu()
        {
            Console.WriteLine("Press B to back");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            char key = char.ToUpper(consoleKeyInfo.KeyChar);

            if (key == 'B')
            {
                Console.Clear();
                ShowMenu();
            }
            else
            {
                Console.WriteLine("Invalid command. Please Press B to Back to Menu");
            }
        }

        static void ViewPost()
        {
            int id = 0;
            foreach (var StackPostBlog in StackPostBlogs)
            {
                id++;
                Console.WriteLine($"{id}. Title: {StackPostBlog.Title}");
            }
            ViewPostDetail();
        }

        static void PostDetail(int key)
        {
            var post = StackPostBlogs.Find((item) => item.Id == key);
            Console.WriteLine("     ");
            Console.WriteLine("                   Title ");
            Console.WriteLine($"  {post.Title} {post.Description}");
            Console.WriteLine("     ");
            Console.WriteLine("     ");
            Console.WriteLine("                   Description ");
            Console.WriteLine($" {post.Description}");
            Console.WriteLine("     ");
            Console.WriteLine("User Press 0 to delete to Post ");
            Console.WriteLine("User Press 1 to back to View Posts ");
            Console.WriteLine("User Press 2 to like Post ");
            Console.WriteLine("User Press 3 to dislike Post ");
            Console.WriteLine("     ");
            Console.WriteLine("     ");
            Console.WriteLine("     ");
        }

        static void DeletePost(int key)
        {
            var selectpost = StackPostBlogs.Find((item) => item.Id == key);
            Console.WriteLine($"delete!!{key}");
            StackPostBlogs.Remove(selectpost);
            ClearandSleep();
            ViewPost();
        }
        static void ViewPostDetail()
        {

            Console.WriteLine("Press a number to view a Post");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            ClearandSleep();

            int key = int.Parse(consoleKeyInfo.KeyChar.ToString());
            var post = StackPostBlogs.Find((item) => item.Id == key);
            if (post != null)
            {
                PostDetail(key);
                if (key != 0)
                {
                    ConsoleKeyInfo consolekey = Console.ReadKey();
                    ClearandSleep();
                    int seletedkey = int.Parse(consolekey.KeyChar.ToString());
                    switch (seletedkey)
                    {
                        case 0:
                            DeletePost(key);
                            break;
                        case 1:
                            ClearandSleep();
                            ViewPost();
                            break;
                        case 2:
                            post.UpVote();
                            post.GetVote();
                            Console.WriteLine("Thank for yours vote!!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            PostDetail(key);
                            break;
                        case 3:
                            post.DownVote();
                            post.GetVote();
                            Console.WriteLine("....!!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            ViewPostDetail();
                            break;
                        default:
                            Console.WriteLine(". Invalid command");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error Log");
                }
            }
            else
            {
                Console.WriteLine("Post not found with the specified ID.");
            }
        }
    }
}
