using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWLDotNetCore.ConsoleApp.Dtos;

namespace TWLDotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db;

        public EFCoreExample(AppDbContext db)
        {
            this.db = db;
        }

        /*private readonly AppDbContext db = new AppDbContext();*/
        public void Run()
        {
            /* Read();*/
            /*Edit(1);
            Edit(17);*/
            /*Update(21, "test title", "test author", "test content");*/
            Delete(21);
        }

        private void Read()
        {

            var lst = db.Blogs.ToList();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------------------");
            }
        }

        private void Edit(int id)

        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("--------------------------");

        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Success!" : "Saving Failed!";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Success!" : "Updating Failed!";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No Data Found!");
                return;
            }

            db.Blogs.Remove(item);

            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting Success!" : "Deleting Failed!";
            Console.WriteLine(message);
        }


    }
}
