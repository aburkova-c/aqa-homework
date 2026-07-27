class Program
{
    static void Main(string[] args)
    {
        // Generics methods 
        int number = 10;
        string text = "Привет";
        bool isActive = true;
        List<int> numbers = new List<int> { 3, 4, 5 };
        List<string> words = new List<string> { "Самолет", "Кот", "Книга" };
        List<int> emptyNumbers = new List<int>();
        List<int> repeatedNumbers = Repeat(7, 3);
        List<string> repeatedWords = Repeat("Привет", 2);
        List<int> copyNumbers = Copy(numbers);
        List<string> copyWords = Copy(words);

        List<int> firstNumbers = new List<int> { 1, 2 };
        List<int> secondNumbers = new List<int> { 3, 4 };
        List<int> mergedNumbers = Merge<int>(firstNumbers, secondNumbers);
        PrintList(mergedNumbers);

        List<string> firstWords = new List<string> { "вообще", "уже" };
        List<string> secondWords = new List<string> { "да", "нет" };
        List<string> mergedWords = Merge<string>(firstWords, secondWords);
        PrintList(mergedWords);

        List<int> reversedNumbers = Reverse(numbers);
        Console.WriteLine("Обратный порядок цифер:");
        PrintList(reversedNumbers);

        List<string> reversedWords = Reverse(words);
        Console.WriteLine("Обратный порядок:");
        PrintList(reversedWords);

        List<int> takenNumbers = Take<int>(numbers, 3);
        PrintList(takenNumbers);

        List<string> takenWords = Take(words, 2);
        PrintList(takenWords);

        List<int> zeroItems = Take<int>(numbers, 0);
        Console.WriteLine(zeroItems.Count);

        List<int> allNumbers = Take<int>(numbers, 10);
        PrintList(allNumbers);

        PrintValue(number);
        PrintValue(text);
        PrintValue(isActive);

        copyNumbers.Add(100);
        Console.WriteLine("Исходный список:");
        PrintList(numbers);
        PrintList(words);

        PrintList(repeatedNumbers);
        PrintList(repeatedWords);

        Console.WriteLine("Копия:");
        PrintList(copyNumbers);
        PrintList(copyWords);

        int firstNumber = GetFirst(numbers);
        Console.WriteLine(firstNumber);

        string firstWord = GetFirst(words);
        Console.WriteLine(firstWord);

        int lastNumber = GetLast(numbers);
        Console.WriteLine(lastNumber);

        string lastWord = GetLast(words);
        Console.WriteLine(lastWord);

        int selectedNumber = GetByIndex(numbers, 1);
        Console.WriteLine(selectedNumber);

        string selectedWord = GetByIndex(words, 2);
        Console.WriteLine(selectedWord);

        try
        {
            int value = GetFirst(emptyNumbers);
            Console.WriteLine(value);
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine(exception.Message);
        }

        try
        {
            int value2 = GetLast(emptyNumbers);
            Console.WriteLine(value2);
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine(exception.Message);
        }

        try
        {
            int selectedValue = GetByIndex(numbers, 10);
            Console.WriteLine(selectedValue);
        }
        catch (ArgumentOutOfRangeException exception)
        {
            Console.WriteLine(exception.Message);
        }


// Where restrictions
        // BOOKS
        List<Book> books = new List<Book>
        {
            new Book { Name = "Война и мир", Price = 1200 },
            new Book { Name = "Преступление и наказание", Price = 1500 }
        };

        Book mostExpensiveBook = GetMostExpensive(books);
        Console.WriteLine("Самая дорогая книга:");
        Console.WriteLine($"{mostExpensiveBook.Name}:{mostExpensiveBook.Price}");

        Console.WriteLine("Книги:");
        PrintProducts(books);

        List<Book> emptyBooks = new List<Book>();
        try
        {
            Book book = GetMostExpensive(emptyBooks);
            Console.WriteLine(book.Name);
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine(exception.Message);
        }
        
        Console.WriteLine("Книги дешевле 1300:");
        List<Book> cheapBooks = GetProductsCheaperThan(books, 1300);
        PrintProducts(cheapBooks);
        
        Console.WriteLine("Все книги после фильтрации:");
        PrintProducts(books);
        
        Book createdBook = CreateProduct<Book>("Мастер и Маргарита", 1000);
        Console.WriteLine("Созданная книга:");
        Console.WriteLine($"{createdBook.Name} - {createdBook.Price}");
        
        Console.WriteLine("Книги после скидки 10%:");
        ApplyDiscountToAll(books, 10);

        // PHONES

        List<Phone> phones = new List<Phone>
        {
            new Phone { Name = "iPhone", Price = 25000 },
            new Phone { Name = "Samsung", Price = 26000 }
        };
        Phone mostExpensivePhone = GetMostExpensive(phones);
        Console.WriteLine("Самый дорогой телефон:");
        Console.WriteLine($"{mostExpensivePhone.Name}:{mostExpensivePhone.Price}");

        Console.WriteLine("Телефоны:");
        PrintProducts(phones);

        List<Phone> emptyPhones = new List<Phone>();
        
        Console.WriteLine("Телефоны дешевле 25500:");
        List<Phone> cheapPhones = GetProductsCheaperThan(phones, 25500);
        PrintProducts(cheapPhones);
        
        Console.WriteLine("Все телефоны после фильтрации:");
        PrintProducts(phones);
        
        Phone createdPhone = CreateProduct<Phone>("Xiaomi", 30000);
        Console.WriteLine("Созданный телефон:");
        Console.WriteLine($"{createdPhone.Name} - {createdPhone.Price}");
        
        Console.WriteLine("Телефоны после скидки 15%:");
        ApplyDiscountToAll(phones, 15);
        
        try
        {
            Phone phone = GetMostExpensive(emptyPhones);
            Console.WriteLine(phone.Name);
        }
        catch (InvalidOperationException exception)
        {
            Console.WriteLine(exception.Message);
        }
        
        
        // Фильтрация без делегатов
        
        List<int> filterNumbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        
        Console.WriteLine("Чётные числа:");
        List<int> evenNumbers = GetEvenNumbers(filterNumbers);
        PrintList(evenNumbers);
        
        Console.WriteLine("Исходные числа после фильтрации:");
        PrintList(filterNumbers);
        
        Console.WriteLine("Числа больше 3:");
        List<int> greaterNumbers = GetNumbersGreaterThan(filterNumbers, 3);
        PrintList(greaterNumbers);
        
        Console.WriteLine("Слова длиной от 5 символов:");
        List<string> longWords = GetLongWords(words, 5);
        PrintList(longWords);
        
        Console.WriteLine("Фильтр через Predicate: чётные числа:");
        List<int> evenByPredicate = Filter(numbers, IsEven);
        PrintList(evenByPredicate);
        
        Console.WriteLine("Фильтр через Predicate: длинные слова:");
        List<string> longWordsByPredicate = Filter(words, IsLongWord);
        PrintList(longWordsByPredicate);
        
        List<int> predicateNumbers = new List<int> { 5, 10, 11, 15, 3 };
        
        Console.WriteLine("Фильтр через Predicate: числа больше 10:");
        List<int> greaterThanTen = Filter(predicateNumbers, IsGreaterThanTen);
        PrintList(greaterThanTen);
        
        // ACTION
        
        ExecuteTwice(PrintHello);
        ExecuteTwice(PrintSeparator);
        
        List<int> actionNumbers = new List<int> { 2, 5, 10 };
        ProcessItems(actionNumbers, PrintNumber);
        
        List<string> actionWords = new List<string>
        {
            "book",
            "phone",
            "hello"
        };

        ProcessItems(actionWords, PrintUpperCase);
        
        // FUNC
        int sum = Calculate(10, 5, Add);
        int difference = Calculate(10, 5, Subtract);
        int product = Calculate(10, 5, Multiply);
        
        Console.WriteLine($"Сложение: {sum}");
        Console.WriteLine($"Вычитание: {difference}");
        Console.WriteLine($"Умножение: {product}");

    }
    
    static void ApplyDiscountToAll<T>(List<T> products, decimal percent)
        where T : Product, IDiscountable
    {
        foreach (T product in products)
        {
            product.ApplyDiscount(percent);
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
    }
    
    //

    static void PrintValue<T>(T value)
    {
        Console.WriteLine(value);
    }

    static void PrintList<T>(List<T> items)
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }

    static T GetFirst<T>(List<T> items)
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Список пуст");
        }

        return items[0];
    }

    static T GetLast<T>(List<T> items)
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Список пустой");
        }

        return items[items.Count - 1];
    }

    static T GetByIndex<T>(List<T> items, int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Недопустимый индекс");
        }

        return items[index];
    }

    static List<T> Repeat<T>(T value, int count)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Кол-во повторений не может быть отрицательным");
        }

        List<T> result = new List<T>();

        for (int i = 0; i < count; i++)
        {
            result.Add(value);
        }

        return result;
    }

    static List<T> Copy<T>(List<T> items)
    {
        List<T> result = new List<T>();
        foreach (T item in items)
        {
            result.Add(item);
        }

        return result;
    }

    static List<T> Merge<T>(List<T> first, List<T> second)
    {
        List<T> result = new List<T>();
        foreach (T item in first)
        {
            result.Add(item);
        }

        foreach (T item in second)
        {
            result.Add(item);
        }

        return result;
    }

    static List<T> Reverse<T>(List<T> items)
    {
        List<T> result = new List<T>();
        for (int i = items.Count - 1; i >= 0; i--)
        {
            result.Add(items[i]);
        }

        return result;
    }

    static List<T> Take<T>(List<T> items, int count)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Кол-во не может быть отрицательным.");
        }

        List<T> result = new List<T>();

        int limit = count;
        if (limit > items.Count)
        {
            limit = items.Count;
        }

        for (int i = 0; i < limit; i++)
        {
            result.Add(items[i]);
        }

        return result;
    }


// Where restrictions

    static void PrintProducts<T>(List<T> products)
        where T : Product
    {
        foreach (T product in products)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
    }

    static T GetMostExpensive<T>(List<T> products)
        where T : Product
    {
        if (products.Count == 0)
        {
            throw new InvalidOperationException("Список товаров пуст.");
        }

        T mostExpensive = products[0];

        for (int i = 1; i < products.Count; i++)
        {
            if (products[i].Price > mostExpensive.Price)
            {
                mostExpensive = products[i];
            }
        }

        return mostExpensive;
    }

    static List<T> GetProductsCheaperThan<T>(List<T> products, decimal maximumPrice)
        where T : Product
    { 
        List<T> result = new List<T>();
        
        foreach (T product in products)
        {
            if (product.Price < maximumPrice)
            {
                result.Add(product);
                
            }
        }
        return result;
    }

    static T CreateProduct<T>(string name, decimal price)
        where T : Product, new()
    {
        T product = new T();
        product.Name = name;
        product.Price = price;
        
        return product;
    }

    // Фильтрация без делегатов
    
    static List<int> GetEvenNumbers(List<int> numbers)
    {
        List<int> result = new List<int>();

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                result.Add(number);
            }
        }

        return result;
    }
    
    static List<int> GetNumbersGreaterThan(List<int> numbers, int minimum)
    {
        List<int> result = new List<int>();

        foreach (int number in numbers)
        {
            if (number > minimum)
            {
                result.Add(number);
            }
        }

        return result;
    }
    
    static List<string> GetLongWords(List<string> words, int minimumLength)
    {
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (word.Length >= minimumLength)
            {
                result.Add(word);
            }
        }
        return result;
    }
    
    static List<T> Filter<T>(List<T> items, Predicate<T> condition)
    {
        List<T> result = new List<T>();

        foreach (T item in items)
        {
            if (condition(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }
        
    static bool IsLongWord(string word)
    {
        return word.Length >= 5;
    }
    
    static bool IsGreaterThanTen(int number)
    {
        return number > 10;
    }
    
    // Action 
    
    static void ExecuteTwice(Action action)
    {
        action();
        action();
    }
    
    static void PrintHello()
    {
        Console.WriteLine("Hello!");
    }
    
    static void PrintSeparator()
    {
        Console.WriteLine("----------------");
    }
    
    static void ProcessItems<T>(List<T> items, Action<T> action)
    {
        foreach (T item in items)
        {
            action(item);
        }
    }
    
    static void PrintNumber(int number)
    {
        Console.WriteLine(number);
    }
    
    static void PrintUpperCase(string text)
    {
        Console.WriteLine(text.ToUpper());
    }
    
    // FUNC
    
    static int Calculate(
        int first,
        int second,
        Func<int, int, int> operation)
    {
        return operation(first, second);
    }
    
    static int Add(int first, int second)
    {
        return first + second;
    }
    
    static int Subtract(int first, int second)
    {
        return first - second;
    }
    
    static int Multiply(int first, int second)
    {
        return first * second;
    }
}




class Product
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}

class Book : Product, IDiscountable
{
    public Book()
    {
    }

    public void ApplyDiscount(decimal percent)
    {
        Price = Price - Price * percent / 100;
    }
}

class Phone : Product, IDiscountable
{
    public Phone()
    {
    }

    public void ApplyDiscount(decimal percent)
    {
        Price = Price - Price * percent / 100;
    }
}

interface IDiscountable
{
    void ApplyDiscount(decimal percent);
}


