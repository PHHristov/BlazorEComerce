namespace BlazorEComerce.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Title = "Introduction to Algorithms, fourth edition",
                     Description = "Some books on algorithms are rigorous but incomplete; others cover masses of material but lack rigor. Introduction to Algorithms uniquely combines rigor and comprehensiveness. It covers a broad range of algorithms in depth, yet makes their design and analysis accessible to all levels of readers, with self-contained chapters and algorithms in pseudocode. Since the publication of the first edition, Introduction to Algorithms has become the leading algorithms text in universities worldwide as well as the standard reference for professionals. This fourth edition has been updated throughout.",
                     ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/41VZ-6Vy7HL._SX437_BO1,204,203,200_.jpg",
                     Price = 9.99m
                 },
                new Product
                {
                    Id = 2,
                    Title = "Clean Code",
                    Description = "Even bad code can function. But if code isn't clean, it can bring a development organization to its knees. Every year countless hours and significant resources are lost because of poorly written code. But it doesn't have to be that way. Noted software expert Robert C. Martin presents a revolutionary paradigm with Clean Code: A Handbook of Agile Software Craftsmanship. Martin has teamed up with his colleagues from Object Mentor to distill their best agile practice of cleaning code “on the fly” into a book that will instill within you the values ​​of a software craftsman and make you a better programmer—but only if you work at it. What kind of work will you be doing? You'll be reading code—lots of code. And you will be challenged to think about what's right about that code, and what's wrong with it. more importantly, you will be challenged to reassess your professional values ​​and your commitment to your craft. Clean code is divided into three parts. The first describes the principles, patterns, and practices of writing clean code.",
                    ImageUrl = "https://images-eu.ssl-images-amazon.com/images/I/41xShlnTZTL._SX198_BO1,204,203,200_QL40_ML2_.jpg",
                    Price = 9.99m
                },
                new Product
                {
                    Id = 3,
                    Title = "The Pragmatic Programmer",
                    Description = "The Pragmatic Programmer is one of those rare tech books you'll read, re-read, and read again over the years. Whether you're new to the field or an experienced practitioner, you'll come away with fresh insights each and every time. Dave Thomas and Andy Hunt wrote the first edition of this influential book in 1999 to help their clients create better software and rediscover the joy of coding. These lessons have helped a generation of programmers examine the very essence of software development, independent of any particular language, framework, or methodology, and the Pragmatic philosophy has spawned hundreds of books, screencasts, and audio books, as well as thousands of careers and success stories.",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51W1sBPO7tL._SX380_BO1,204,203,200_.jpg",
                    Price = 9.99m
                }
                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
