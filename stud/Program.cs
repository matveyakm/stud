using System;
using System.Collections.Generic;
using System.Globalization;


namespace stud
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime localDate = DateTime.Now;
            String[] cultureNames = { "ru-RU" };

            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("Начало работы алгоритма: {1}", cultureName,
                                  localDate.ToString(culture));
            }



                List<Groups> listGroups = new List<Groups>();
            int Five = 0;
            for (int r = 9; r >= 2; r--) // 10 в степени r
            {
                //Console.WriteLine("R " + r);
                int notEven = 0; // 0 = false // т.к. 12321 и 123321 - разные числа, используется notEven, относящийся к фактическому кол-ву разрядов
                if ((r & 0) == 0 ) notEven = 1;  // если нечетная степень, то верно
                double i = Math.Ceiling((Convert.ToDouble(r)/2)); // Делим кол-во разрядов, чтобы получить кол-во разрядов первой половины полиндрома
                for (float u = Convert.ToInt32(Math.Pow(10,i)); u > Math.Pow(10, i -1); u--) // Создаем полиндромы от большего к меньшему
                {
                    char[] arrCharPol = u.ToString().ToCharArray();
                    string strU = u.ToString();
                        for (int x = arrCharPol.Length - 1 - notEven; x >= 0; x--)
                        {
                        strU += arrCharPol[x].ToString();
                        }
                    double UinDouble = Convert.ToInt64(strU);
                    
                    int countOfD = 0;
                    int d = 2;
                    while (d <= Math.Ceiling(UinDouble / 2d) && countOfD == 0) // Считаем кол-во делителей // (Несмотря на, наверное, максимальную оптимизацию
                    {
                        if (UinDouble % d == 0) countOfD++;                                                // этот цикл сжирает очень много ресурсов и времени)
                        d++;
                    }
                    if (countOfD == 0) // Если простое
                    {
                        //Console.WriteLine("YES");
                        strU = strU.Replace("0", ""); // Убираем ноли из числа
                        int mult = 1;
                        while (strU.Length > 0) // Считаем произведение цифр, которое станет названием группы
                        {
                            mult *= Convert.ToInt16(strU[0].ToString());
                            strU = strU.Remove(0,1);
                            //Console.WriteLine(mult);
                        }
                        if (listGroups.Exists(g => g.GetGroupName() == mult)) // Если группа существует, то добавляем значение в нее
                        {
                            Groups currentItem = listGroups.Find(g => g.GetGroupName() == mult); 
                            List<double> currentValues = currentItem.GetGroupValues();
                            currentValues.Add(UinDouble);
                            currentItem.SetGroupValues(currentValues);
                            //Console.WriteLine("Добавили " + UinDouble + " в "+ mult);
                        }
                        else //Если группа с таким произведением цифр не существует, то создаем
                        {
                            Groups currentItem = new Groups();
                            List<double> currentValues = new List<double>();
                            currentItem.SetGroupName(mult);
                            currentValues.Add(UinDouble);
                            currentItem.SetGroupValues(currentValues);
                            listGroups.Add(currentItem);
                            //Console.WriteLine("Создали " + mult + " для " + UinDouble);
                        }
                    }
                }
            }

            Groups maxGroups = null; 
            if (listGroups.Count > 0)
            {
                foreach (Groups groups in listGroups) // Узнаем группу с максимальным количеством элементов
                {
                    if (maxGroups == null || groups.GetGroupValues().Count > maxGroups.GetGroupValues().Count) maxGroups = groups;
                }

                maxGroups.GetGroupValues().Sort(); // Сортируем по возрастанию всю наибольшую группу
                foreach (int currentValue in maxGroups.GetGroupValues())
                {
                    //Console.WriteLine("!" + currentValue);
                    if (maxGroups.GetGroupValues().Count - Five <= 5) 
                        Console.WriteLine(currentValue); 
                    Five++;
                }


                localDate = DateTime.Now;


                foreach (var cultureName in cultureNames)
                {
                    var culture = new CultureInfo(cultureName);
                    Console.WriteLine("Конец работы: {1}", cultureName,
                                      localDate.ToString(culture));
                }
            }


        }

    }
}