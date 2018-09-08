using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Globalization;
using System.Threading;
using System.IO;


namespace ConsoleApp1
{
    public class pet
    {

      public  int helth;
      public int food;
      public int happy;
      public bool game;



    }
    public class cat : pet
    {
        
        
        
       public void start()
        {

            helth = 50;
            food = 50;
            happy = 50;
            game = true;
        }
        public void play(){ happy += 5;     }
        public void eat() { food += 5;      }
        public void medicine() { helth += 5;}
        public void Draw()
        {
            Console.WriteLine("Здоровье " + helth + " Голод " + food + " Настроение " + happy);
        }


    }
    class main 
    {
       static cat p = new cat
        {
           

        };
        
        static void Main(string[] args)
        {
            p.start();
            Thread myThread = new Thread(func);
            myThread.Start(); //запускаем поток
            Thread myThread_2 = new Thread(func_2);
            myThread_2.Start(); //запускаем поток
          
            
           
           
            for (;;)
            {
                timer();
            }
        }
        public static void timer()
        {
            Thread.Sleep(1 * 30 * 1000);
            Random rnd1 = new Random();
            byte[] bytes1 = new byte[3];
            rnd1.NextBytes(bytes1);

            
            
            
          if(bytes1[0] > 100)
            {
                p.happy -= 5;
            }
            if (bytes1[1] > 50)
            {
                p.helth -= 5;
            }
            if (bytes1[2] > 50)
            {
                p.food -= 5;
            }

        }
        public static void func()
        {

            DateTime Date = new DateTime(2018, 7, 9);




            var culture = new CultureInfo("ru-RU");
            for (; ; )
            {
                if (p.game == true)
                {
                    // DateTime localDate = DateTime.Now;

                    // long ticks = localDate.Ticks;
                    // TimeSpan span = new TimeSpan(ticks);

                    // Console.WriteLine(span.TotalMinutes.ToString());
                    //write_time(span.TotalMinutes.ToString());
                    //read_time();
                    if (p.food < 0 || p.happy < 0 || p.helth < 0)
                        game_over();
                    Console.WriteLine("1- Дать таблетку 2 - Покормить 3 - Погулять " + "   4-|Сделать 6 пар экономики на неделе|");
                    p.Draw();
                    //Thread.Sleep(0);
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ваш питомец умер(((");
                    System.Threading.Thread.Sleep(30000);
                }
            }
        }
        public static void func_2()
        {
          
            for (; ; )
            {
                if(p.game == true)
                TryToParse(Console.ReadLine());
                
            } 

        }
        static void TryToParse(string value)
        {
            int number;
            bool result = Int32.TryParse(value, out number);
            if (result && p.game == true)
            {

                if (number == 1)
                {
                    Console.WriteLine("Вы полечили вашего питомца");
                    p.medicine();
                }
                if (number == 2)
                {
                    Console.WriteLine("Вы покормили вашего питомца");
                    p.eat();
                }
                if (number == 3)
                {
                    Console.WriteLine("Вы погуляли с вашем питомцем");
                    p.play();
                }
                if (number == 4)
                {
                    Console.WriteLine("Бедный питомец");
                    game_over();
                }
            }
            else
            {
                if (value == null) value = "";
              
               
            }
        }
        public static void game_over()
        {
            p.game = false;
            

        }
        //public static void write_time(string time)
        //{
        //    StreamWriter sw = new StreamWriter("Test.txt");

        //    string[] st = new string[] { time  };

        //    foreach (var node in st)
        //    {

        //        sw.WriteLine(node + Environment.NewLine);
        //        //sw.Close();
        //    }

        //    sw.Close();
           

        //}
        //public static void read_time()
        //{
        //    StreamReader sr = new StreamReader("Test.txt");

        //    string line = sr.ReadLine();

        //    //Continue to read until you reach end of file
        //    while (line != null)
        //    {
        //        //write the lie to console window
        //        Console.WriteLine("lox = " + line);
        //        //Read the next line
        //        line = sr.ReadLine();
        //    }

        //    //close the file
        //    sr.Close();

        //}
    }
}
