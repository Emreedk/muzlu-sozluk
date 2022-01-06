using ContentProject.DataAccessLayer.Context;
using ContentProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Writer writer = new Writer()
            {
                WriterName = "Emre",
                WriterSurname = "Demirkazık",
                WriterImage = "biyometrik.jpeg",
                WriterMail = "emreedk@gmail.com",
                WriterPassword = "1",
                WriterUsername = "emreedk",
                WriterAbout = FakeData.TextData.GetSentence(),
                isAdmin = true

            };

            context.Writers.Add(writer);

            for (int i = 0; i < 9; i++)
            {
                Writer writer1 = new Writer()
                {
                    WriterName = FakeData.NameData.GetFirstName(),
                    WriterSurname = FakeData.NameData.GetSurname(),
                    WriterImage = "biyometrik.jpeg",
                    WriterMail = FakeData.NetworkData.GetEmail(),
                    WriterAbout = FakeData.TextData.GetSentence(),
                    WriterUsername = $"writer{i}",
                    WriterPassword = "1",
                    isAdmin = false

                };

                context.Writers.Add(writer1);
            }

            context.SaveChanges();

            List<Writer> writers = context.Writers.ToList();


            for (int i = 0; i < 10; i++)
            {
                Category category = new Category()
                {
                    CategoryName = FakeData.NameData.GetCompanyName(),
                    CategoryDescription = FakeData.TextData.GetSentence(),
                    CategoryStatus = true,
                };

                context.Categories.Add(category);
                context.SaveChanges();
                List<Category> catlist = context.Categories.ToList();
                

                for (int j = 0; j < FakeData.NumberData.GetNumber(5, 9); j++)
                {
                    Writer owner = writers[FakeData.NumberData.GetNumber(0, writers.Count - 1)];
                    Category catname = catlist[FakeData.NumberData.GetNumber(0, catlist.Count - 1)];

                    Heading heading = new Heading()
                    {
                        HeadingName = FakeData.NameData.GetCompanyName(),
                        HeadingDate = FakeData.DateTimeData.GetDatetime(),
                        Writer = owner,
                        Category = catname



                    };
                    context.Headings.Add(heading);
                    context.SaveChanges();
                    List<Heading> headings = context.Headings.ToList();

                    Heading title = headings[FakeData.NumberData.GetNumber(0, headings.Count - 1)];

                    Content content = new Content()
                    {
                        ContentValue = FakeData.TextData.GetSentence(),
                        ContentDate = FakeData.DateTimeData.GetDatetime(),
                        Writer = owner,
                        Heading = title
                    };

                    context.Contents.Add(content);

                }
            }

            context.SaveChanges();
        }
    }
}
