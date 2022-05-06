using System;

namespace M7._7Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Order ord = new Order();
            Console.WriteLine("Номер заказа {0}", ord.Number);
            Console.WriteLine("Выберите категорию товаров: 1 - продукты, 2 - другое, 3 - ноутбук");
            int ngoods = Convert.ToInt32(Console.ReadLine());
            switch (ngoods)
            {
                case 1:
                    Food good1 = new Food();
                    good1.allGoods();
                    break;
                case 2:
                    Other good2 = new Other();
                    good2.allGoods();
                    break;
                case 3:
                    NoteBook noteBook = new NoteBook();
                    Console.WriteLine("Характеристики ноутбука: {0}", noteBook.NameProduct());
                    var caseNoteBook = new CaseNoteBook();
                    var caseShop = caseNoteBook.noteBook.model;
                    Console.WriteLine("Наименование сумки для ноутбука: {0}", caseNoteBook.ChangeCase(caseShop));
                    break;


            }

            Console.WriteLine("Выберите доставку: 1 - курьером, 2 - в пункт выдачи, 3 - получить в магазине");
            int nshop = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine();

            switch (nshop)
            {
                case 1:
                    HomeDelivery deliv1 = new HomeDelivery();
                    deliv1.Move();
                    break;
                case 2:
                    PickPointDelivery deliv2 = new PickPointDelivery();
                    deliv2.Move();
                    break;
                case 3:
                    ShopDelivery deliv3 = new ShopDelivery();
                    deliv3.Move();
                    break;

            }
            Console.WriteLine("Выберите способ оплаты: 1 - карта, 2 - наличные, 3 - кредит");
            int npay = Convert.ToInt32(Console.ReadLine());
            switch (npay)
            {
                case 1:
                    CreditCard pay1 = new CreditCard();
                    pay1.Pay();
                    break;
                case 2:
                    Cash pay2 = new Cash();
                    pay2.Pay();
                    break;
                case 3:
                    Credit pay3 = new Credit();
                    pay3.Pay();
                    break;


            }


        }
    }

    abstract class Delivery
    {
        public string Address;
        public abstract void Move();
        protected DateTime date = DateTime.Now;

    }

    class HomeDelivery : Delivery
    {
        public override void Move()
        {

            Console.WriteLine("Введите свой адрес");
            Address = Console.ReadLine();
            date = base.date.AddDays(4);
            Console.WriteLine("Доставка будет осуществлена по адресу: {0} в течение 4 дней: {1}", Address, date.ToShortDateString());

        }
    }

    class PickPointDelivery : Delivery
    {
        public override void Move()
        {
            Console.WriteLine("Выберите ближайший пункт доставки: 1 - ул. Ивана Брагина, д. 4, 2 - ул. Семена Середы, д. 8, 3 - ул. Светланы Ивановой, д. 41");
            int nppoint = Convert.ToInt32(Console.ReadLine());
            switch (nppoint)
            {
                case 1:
                    Address = "ул. Ивана Брагина, д. 4";
                    break;
                case 2:
                    Address = "ул. Семена Середы, д. 8";
                    break;
                case 3:
                    Address = "ул. Светланы Ивановой, д. 41";
                    break;
            }
            date = base.date.AddDays(3);
            Console.WriteLine("Ваш товар будет доставлен в пункт доставки по адресу: {0} в течение 3 дней: {1}", Address, date.ToShortDateString());

        }
    }

    class ShopDelivery : Delivery
    {
        public override void Move()
        {

            Address = "ул. Фестивальная, д. 16";
            Console.WriteLine("Вы можете забрать подготовленный для вас товар в магазине по адресу: {0}", Address);
        }
    }

    class Order
    { 
        public int Number = 0;

        public Order()
        {
            Number = Counter.Count(Number);
        }
    }
    class Counter
    
    {
    public static int Count(int Number)
        {
            Number = Number+1;
            return Number ;
        }
    }

    abstract class Payment
    {
        public abstract void Pay();
    }
    class CreditCard : Payment
    {
        public override void Pay()
        {
            Console.WriteLine("Вы выбрали оплату кредитной картой");

        }
    }
    class Cash : Payment
    {
        public override void Pay()
        {
            Console.WriteLine("Вы выбрали оплату наличными");
        }
    }
    class Credit : Payment
    {
        public override void Pay()
        {
            Console.WriteLine("Вы выбрали оплату через кредит");
        }
    }

    abstract class Goods
    {
        public string goods;
        public int numb;
        public double cost;
        public abstract void allGoods();
    }

    class Food : Goods
    {

        public override void allGoods()
        {


            Console.WriteLine("Выберите необходимый Вам продукт: 1 - Яйца, 2 - Молоко, 3 - Сыр");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько данного вида товара Вам требуется?");
            numb = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    goods = "Яйцо";
                    cost = 25.6 * Convert.ToDouble(numb);
                    break;
                case 2:
                    goods = "Молоко";
                    cost = 34.1 * Convert.ToDouble(numb);
                    break;
                case 3:
                    goods = "Сыр";
                    cost = 42.6 * Convert.ToDouble(numb);
                    break;
            }

        }
    }

    class Other : Goods
    {
        public override void allGoods()
        {


            Console.WriteLine("Выберите необходимый Вам продукт: 1 - Гвозди, 2 - Молоток, 3 - Ведро");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько данного вида товара Вам требуется?");
            numb = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    goods = "Гвоздь";
                    cost = 25.6 * Convert.ToDouble(numb);
                    break;
                case 2:
                    goods = "Молоток";
                    cost = 25.6 * Convert.ToDouble(numb);
                    break;
                case 3:
                    goods = "Ведро";
                    cost = 25.6 * Convert.ToDouble(numb);
                    break;
            }

        }
    }

    abstract class Product
    {
        public string manufacturer;
        public string model;
        public int year;

        public virtual string NameProduct()
        {
            return "производитель:" + manufacturer + "модель:" + model + "год выпуска:" + year;
        }

    }

    class NoteBook : Product
    {
        public int cores;
        protected string diagonal;

        public NoteBook()
        {
            manufacturer = "HP";
            model = "250 G7";
            year = 2022;
            cores = 2;
            diagonal = "15,6";
        }
        public int Cores
        {
            get
            {
                return cores;
            }
            set
            {
                if (value == 2 || value == 4 || value == 6 || value == 8)
                {
                    Console.WriteLine("Количество ядер может быть только 2, 4, 6 или 8");
                }
                else cores = value;
            }
        }

        public override string NameProduct()
        {
            return "производитель: " + manufacturer + " модель: " + model + " год выпуска: " + year + " количество ядер процессора: " + cores + " диагональ дисплея: " + diagonal;
        }
    }

    class CaseNoteBook
    {
        public NoteBook noteBook;
        public CaseNoteBook()
        {
            noteBook = new NoteBook();
        }
        public string ChangeCase(string model)
        {
            switch (noteBook.model)
            {
                case "250 G7":
                    return "case156";
                case "245 G8":
                    return "case14";
                case "elite dragonfly g2":
                    return "case133";
            }
            return "Сумка для данной модели отсутствует в продаже";
        }
    }
}


