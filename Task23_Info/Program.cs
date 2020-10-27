using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task23_Info
{

    class Info_from_file
    {
        public void find_info()
        {
            string readText = File.ReadAllText("task15.txt");
            string[] clearedText = Regex.Replace(readText, @"\r\n?|\n|\s+", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> listEmails = new List<string>();
            List<string> listPhones = new List<string>();
            List<string> listDate = new List<string>();
            Console.WriteLine("***********");
            foreach (var item in clearedText)
            {
                if (Regex.IsMatch(item, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}$"))
                {
                    listEmails.Add(item);
                    Console.WriteLine("Email: " + item);
                }
                if (Regex.IsMatch(item, @"^\+79[0-9]{9}$"))
                {
                    listPhones.Add(item);
                    Console.WriteLine("Phone: " + item);
                }
                if (Regex.IsMatch(item, @"^(0?[1-9]|3?[0-1]|[1-9][0-9])\.(0?[1-9]|1[0-2])\.[1-9][0-9]{3}$"))
                {
                    string[] date_array = item.Split(new char[] { '.' });

                    if ((date_array[1] == "04" | date_array[1] == "06" | date_array[1] == "09" | date_array[1] == "11") & (Convert.ToInt32(date_array[0]) <= 30)
                        | (date_array[1] == "02") & (Convert.ToInt32(date_array[2]) % 4 == 0) & (Convert.ToInt32(date_array[0]) <= 29)
                        | (date_array[1] == "02") & (Convert.ToInt32(date_array[2]) % 4 != 0) & (Convert.ToInt32(date_array[0]) <= 28)
                        | (date_array[1] == "01" | date_array[1] == "03" | date_array[1] == "05" | date_array[1] == "7" | date_array[1] == "8" | date_array[1] == "10" | date_array[1] == "12")
                            & (Convert.ToInt32(date_array[0]) <= 31)
                        )
                    {
                        listDate.Add(item);
                        Console.WriteLine("Date: " + item);
                    }

                }

            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Info_from_file info = new Info_from_file();
            info.find_info();
        }
    }
}
