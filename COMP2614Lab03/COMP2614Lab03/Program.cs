using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "COMP2614 Lab03";

            StreamReader streamReadObjectInstance = new StreamReader("...\\...\\data.txt");

            string relativeFilePath = @"..\..\data.txt";
            string stringContainer;

            if (!File.Exists(relativeFilePath))
            {
                Console.WriteLine("The file was not found, please update the streamreader pointer");
            }
            else
            {
                Console.WriteLine("{0,-15} {1,-15} {2, 5}", "First Name", "Last Name", "Age");
                Console.WriteLine(new string('-', 37));

                try
                {
                    using (streamReadObjectInstance = new StreamReader(relativeFilePath))
                    {
                        int sum = 0;
                        int count = 0;
                        double average = 0.0;
                        while ((stringContainer = streamReadObjectInstance.ReadLine()) != null)
                        {
                            string[] memberData = stringContainer.Split(',');
                            Console.WriteLine("{0,-15} {1,-15} {2,5}",
                            memberData[0], memberData[1], memberData[2]);                        

                            var summation = Convert.ToInt32(memberData[2]);          
                            sum += summation;

                            count++;

                            average = (double)sum / count;
                        }
                        Console.WriteLine(new string('-', 37));
                        Console.WriteLine("{0,-15} {1, -15} {2,5}", "", "Total: ", sum);
                        Console.WriteLine("{0,-15} {1, -15} {2,5}", "", "Count: ", count);
                        Console.WriteLine("{0,-15} {1, -15} {2,5}", "", "Average: ", average);
                    }
                }

                catch (Exception exceptionContainer)
                {
                    Console.WriteLine($"\n{exceptionContainer.Message}");
                }

                finally
                {
                    if (streamReadObjectInstance != null)
                    {
                        streamReadObjectInstance.Close();
                    }
                }                
            }
        }
    }
}