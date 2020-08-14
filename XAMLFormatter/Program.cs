using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using System.Xaml;
using System.IO;
using System.Xml;

namespace XAMLFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            //string xamlInputFilePath = @"C:\Users\Ashish Chawda\Downloads\Example\Before.xaml";
            //string outputFilePath = @"C:\Users\Ashish Chawda\Downloads\Example\After_Test.xaml";

            string xamlInputFilePath = string.Empty;
            string xamlOutputFilePath = string.Empty;

            Console.WriteLine("----------------XAML Formatter Utility--------------");
            FileInfo fileInfo = null;
            do
            {
                TakeInput(ref xamlInputFilePath, ref xamlOutputFilePath);
                fileInfo = new FileInfo(xamlInputFilePath);

                if (fileInfo.Length > 0)
                {
                    if (!string.IsNullOrEmpty(xamlInputFilePath) && !string.IsNullOrEmpty(xamlOutputFilePath))
                    {
                        bool isProcessingSuccess = FormatXamlFile(xamlInputFilePath, xamlOutputFilePath);

                        if (!isProcessingSuccess)
                        {
                            Console.WriteLine("There is some problem with the xaml processing... please check logs!");
                        }
                        else
                        {
                            Console.WriteLine("Formatting is completed, please see specified output path for the formatted file.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Input file is empty, please try again!");
                } 
            } while (fileInfo.Length == 0);




        }

        private static void TakeInput(ref string xamlInputFilePath, ref string xamlOutputFilePath)
        {

            bool isInputValid = false;
            bool isOutputPathValid = false;
            do
            {

                Console.WriteLine("Enter the path of input XAML file: ");
                xamlInputFilePath = Console.ReadLine();

                if (!File.Exists(xamlInputFilePath))
                {
                    Console.WriteLine("Input file doesn't exists... please specify valid path!");
                }
                else
                {
                    isInputValid = true;
                }

            } while (isInputValid == false);


            do
            {
                Console.WriteLine("Enter the path of output XAML file: ");
                xamlOutputFilePath = Console.ReadLine();

                try
                {
                    if (!File.Exists(xamlOutputFilePath))
                    {
                        using (File.Create(xamlOutputFilePath)) { }
                    }
                    else
                    {
                        File.Delete(xamlOutputFilePath);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Problem while creating/deleting the output file...");
                    Console.WriteLine(ex.Message);
                }

                isOutputPathValid = true;

            } while (isOutputPathValid == false);
        }


        private static bool FormatXamlFile(string inputFilePath, string outputFilePath)
        {
            bool isFormatSuccess = XamlFormatter.FormatXaml(inputFilePath, outputFilePath);
            return isFormatSuccess;
        }
    }
}
