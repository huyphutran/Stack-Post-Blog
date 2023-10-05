using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackPost
{
    internal class StackPostBlog
    {   
        private int id;
        private string title;
        private string description;
        private DateTime createdAt;
        private int votes;


        public StackPostBlog(int id,string title, string description) { 

            this.id = id;
            this.title = title;
            this.description = description;
            this.createdAt = DateTime.Now;
            this.votes = 0;

        }

        public int Id {
            get { return id; }
            set { id = value; }
        }
        public string Title { 
            get {  return title; }
            set { title = value; }
        }

        public string Description { 
            get { return description; }
            set {  description = value; }
        }

        public void getBlog()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"description:{description}");
        }

        public void UpVote()
        {
            votes++;
        }

        public void DownVote() {
            votes--;
        }


        public void GetVote()
        {
            Console.WriteLine($"Likes {votes}");
        }

    }
}
