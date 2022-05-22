
using EFTask;
using Microsoft.EntityFrameworkCore;

// C - create
// R - read
// U - update
// D - delete

using (ApplicationContext db = new ApplicationContext())
{
    while (true)
    {
        Console.WriteLine("");
        Console.WriteLine("Вы можете:");
        Console.WriteLine("1 – Просмотреть текущую библиотеку");
        Console.WriteLine("2 – Добавить книгу в библиотеку");
        Console.WriteLine("3 – Изменить данные для книги");
        Console.WriteLine("4 - Удалить книгу из библиотеки");
        Console.WriteLine("0 - Выход из программы");
        switch (char.ToLower(Console.ReadKey(true).KeyChar))
        {
            case '1': ViewLib(); break;
            case '2': AddBook(); break;
            case '3': UpdateBook(); break;
            case '4': DeleteBook(); break;
            case '0': return;
            default: break;
        }
       
    }


   void  ViewLib(){
        while (true)
            {var Books = db.Books.ToList();
            Console.WriteLine("");
            Console.WriteLine("Список книг в библиотеке:");
            foreach (Book u in Books)
            {
                Console.WriteLine($"{u.Id}.{u.Title} ({u.Author}) - {u.NumOfPages} pages");
            }
        
                Console.WriteLine("");
                Console.WriteLine("0 – Выход в главное меню");
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '0': return;
                    default: break;
                }
 
        }

    }

    void AddBook()
    {
        
            string? title;
            int pages;
            string? author;

            Console.WriteLine("");
            Console.WriteLine("Введите название книги:");
            title = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Введите число страниц:");
            pages = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Введите фамилию автора:");
            author = Console.ReadLine();

            Book temp = new Book { Title = title, NumOfPages = pages, Author = author };
            db.Books.Add(temp);
            db.SaveChanges();
            Console.WriteLine("Книга успешно добавлена");

            Console.WriteLine("");
            Console.WriteLine("0 – Выход в главное меню");
        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '0': return;
                default: break;
            }

        }

    }

    void DeleteBook()
    {
        

            Console.WriteLine("");
            Console.WriteLine("Выберите ID книги, которую хотите удалить:");
            int row = Convert.ToInt32(Console.ReadLine());
            Book? book = db.Books.Where(p => p.Id == row).FirstOrDefault();
        if (book != null)
        {
            db.Books.Remove(book);
            db.SaveChanges();
            Console.WriteLine("Книга успешно удалена");
        }
        else
        {
            Console.WriteLine("Такого ID нет в списке");
        }

            Console.WriteLine("");
            Console.WriteLine("0 – Выход в главное меню");
        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '0': return;
                default: break;
            }

        }
    }
    void UpdateBook()
    {


        Console.WriteLine("");
        Console.WriteLine("Выберите ID книги, которую хотите изменить:");
        int row = Convert.ToInt32(Console.ReadLine());
        Book? book = db.Books.Where(p => p.Id == row).FirstOrDefault();
        if (book == null)
        {
            Console.WriteLine("Такого ID нет в списке");
        }
        else
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("1 – Изменить название книги");
                Console.WriteLine("2 – Изменить количество страниц");
                Console.WriteLine("3 – Изменить фамилию автора");
                Console.WriteLine("0 – Выход в главное меню");

                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1': Console.WriteLine("Ввод: "); book.Title = Console.ReadLine(); db.Books.Update(book); db.SaveChanges(); break;
                    case '2': Console.WriteLine("Ввод: "); book.NumOfPages = Convert.ToInt32(Console.ReadLine()); db.Books.Update(book); db.SaveChanges(); break;
                    case '3': Console.WriteLine("Ввод: "); book.Author = Console.ReadLine(); db.Books.Update(book); db.SaveChanges(); break;
                    case '0': return;
                    default: break;
                }

            }
        }
    }
}