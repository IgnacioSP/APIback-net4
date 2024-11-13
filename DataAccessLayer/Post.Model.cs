using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Post()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }

        public Post(string title, string content)
        {
            this.title = title;
            this.content = content;
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }

        public void Create()
        {
            using (var db = new DALDbContext())
            {
                db.Posts.Add(this);
                db.SaveChanges();
            }
        }
        public void Delete()
        {
            using (var db = new DALDbContext())
            {
                var post = db.Posts.Find(this.id);
                if (post != null)
                {
                    db.Posts.Remove(post);
                    db.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("The object cannot be deleted because it was not found in the ObjectStateManager.");
                }
            }
        }

        public void Update()
        {
            using (var db = new DALDbContext())
            {
                db.Entry(this).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static List<Post> All()
        {
            using (var db = new DALDbContext())
            {
                return db.Posts.ToList();
            }
        }
        public static Post Find(int id)
        {
            using (var db = new DALDbContext())
            {
                return db.Posts.Find(id);
            }
        }
    }
}
