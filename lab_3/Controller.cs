using System;
using System.IO;

namespace lab_3
{
    public class Controller
    {
        Tv tv1 = new Tv();
        Tv tv2 = new Tv();
        Tv tv3 = new Tv();
        
        Tv[] tvArray = new Tv[3];

        string str1 = "";
        string str2 = "";
        
        Services services = new Services();

        public void readExample()
        {
            using (FileStream fstream = File.OpenRead($"/Users/aliakseihudyma/RiderProjects/лабы 2 курс/lab_3/input.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                string[] words = textFromFile.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                int j = 0;
                tv1.Model = words[j];
                tv1.Age = int.Parse(words[j += 1]);
                tv1.NumOfChannels = int.Parse(words[j += 1]);
                tv1.Diagonal = int.Parse(words[j += 1]);

                tv2.Model = words[j += 1];
                tv2.Age = int.Parse(words[j += 1]);
                tv2.NumOfChannels = int.Parse(words[j += 1]);
                tv2.Diagonal = int.Parse(words[j += 1]);

                tv3.Model = words[j += 1];
                tv3.Age = int.Parse(words[j += 1]);
                tv3.NumOfChannels = int.Parse(words[j += 1]);
                tv3.Diagonal = int.Parse(words[j += 1]);

                if (fstream != null)
                {
                    fstream.Close();
                }
            }
        }

        public void exampleIntoArray()
        {
            tvArray[0] = tv1;
            tvArray[1] = tv2;
            tvArray[2] = tv3;
        }

        public void printUnsortedArray()
        {
            foreach (Tv tv in tvArray)
            {
                Console.WriteLine(tv);
            }
        }
        public void chooseAccordingToParameters()
        {
            Console.WriteLine("\nВвод диапазона диагонали");
            services.enterRange();
            
            Console.WriteLine("\n***** Телевизоры с заданным диапазоном диагонали *****");
            foreach (Tv tv in tvArray)
            {
                if (tv.Diagonal > services.StartRange & tv.Diagonal < services.EndRange)
                {
                    Console.WriteLine(tv);
                    
                    str1 = tv.ToString();
                }
            }
            
            Console.WriteLine("\nВвод диапазона количества каналов");
            services.enterRange();
            
            Console.WriteLine("\n***** Телевизоры с заданным диапазоном количества каналов *****");
            foreach (Tv tv in tvArray)
            {
                if (tv.NumOfChannels > services.StartRange & tv.NumOfChannels < services.EndRange)
                {
                    Console.WriteLine(tv);
                    
                    str2 = tv.ToString();
                }
            }

            string str = str1 + str2;
            
            using (FileStream fstream = new FileStream($"/Users/aliakseihudyma/RiderProjects/лабы 2 курс/lab_3/output.txt", FileMode.OpenOrCreate))//starting a stream of writing into a file
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(str);//transforming string into bytes
                fstream.Write(array, 0, array.Length);//writing bytes into the file
            }
        }

        public void bubbleSort()
        {
            Tv temp;
            for (int i = 0; i < tvArray.Length - 1; i++)
            {
                bool f = false;
                for (int j = 0; j < tvArray.Length - i - 1; j++)
                {
                    if (tvArray[j+1].Diagonal < tvArray[j].Diagonal)
                    {
                        f = true;
                        temp = tvArray[j+1];
                        tvArray[j+1] = tvArray[j];
                        tvArray[j] = temp;
                    }                   
                }
                if(!f) break;
            }
            Console.WriteLine("\n***** Минимальный элемент по диагонали *****");
            Console.WriteLine(tvArray[0]);
        }

        public string countAverageNumOfChannels()
        {
            foreach (Tv tv in tvArray)
            {
                services.Average += tv.NumOfChannels;
            }

            return "\nСреднее значение количества каналов равно " + services.Average / 3;
        }

        public Controller()
        {
           
        }
    }
}