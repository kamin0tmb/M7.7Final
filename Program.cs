using System;

namespace M7._7Final
{
    class Program
    {
        static void Main(string[] args)
        {


            User user = new User();


            Console.WriteLine("Введите своё ФИО");
            user.fio = Console.ReadLine();

            Console.WriteLine("Введите свой адрес");
            user.adress = Console.ReadLine();

            Console.WriteLine("Введите свой телефон");
            user.tel = Console.ReadLine();

            user.InfoUser();
            Console.WriteLine();


            NoteBook noteBook = new NoteBook();
            Console.WriteLine("Характеристики ноутбука: {0}", noteBook.NameProduct());

            var caseNoteBook = new CaseNoteBook();
            var caseShop = caseNoteBook.noteBook.model;
            Console.WriteLine("Наименование сумки для ноутбука: {0}", caseNoteBook.ChangeCase(caseShop));

            Console.WriteLine();
            Console.WriteLine("Выберите доставку: 1 - курьером, 2 - в пункт выдачи, 3 - получить в магазине");
            int nshop = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine();

            switch (nshop)
            {
                case 1:
                    HomeDelivery deliv1 = new HomeDelivery { Address = user.adress, Number = 123 };
                    deliv1.Move();
                    break;
                case 2:
                    PickPointDelivery deliv2 = new PickPointDelivery { Number = 123 };
                    deliv2.Move();
                    break;
                case 3:
                    ShopDelivery deliv3 = new ShopDelivery { Number = 123 };
                    deliv3.Move();
                    break;
            }



        }
    }

    abstract class Delivery
    {
        public string Address;
        public int Number;
        public abstract void Move();
    }

    class HomeDelivery : Delivery
    {
        private string Courier;
        public HomeDelivery()
        {
            Courier = "'Служба доставки'";

        }
        public override void Move()
        {
            Console.WriteLine("Заказ {0} будет доставлен по адресу {1} службой {2}", Number, Address, Courier);
        }
    }

    class PickPointDelivery : Delivery
    {
        public PickPointDelivery()
        {
            Address = "'Пункт выдачи'";

        }
        public override void Move()
        {
            Console.WriteLine("Заказ {0} будет доставлен в пункт выдачи {1}", Number, Address);
        }
    }
    class ShopDelivery : Delivery
    {
        private string Shop;
        public ShopDelivery()
        {
            Shop = "'Магазин'";

        }
        public override void Move()
        {
            Console.WriteLine("Заказ {0} находится в магазине {1}", Number, Shop);
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



    class Order<TUser, TDelivery, TNoteBook, TCaseNoteBook>
        where TUser : User
        where TDelivery : Delivery
        where TNoteBook : NoteBook
        where TCaseNoteBook : CaseNoteBook
    {
        public TUser User;
        public TDelivery Delivery;
        public TNoteBook NoteBook;
        public TCaseNoteBook CaseNoteBook;




        public void DisplayAddress(TDelivery Delivery)
        {
            Console.WriteLine("Адрес доставки" + Delivery);
        }

        public void DisplayProduct()
        {
            Console.WriteLine("Товар: " + NoteBook.NameProduct());
        }


    }
    public class User
    {
        public String fio;
        public String adress;
        public String tel;
        public void InfoUser()
        {
            Console.WriteLine("{0} вы зарегистрировались, ваш адрес {1}, ваш телефон {2}", fio, adress, tel);
        }
    }

}
