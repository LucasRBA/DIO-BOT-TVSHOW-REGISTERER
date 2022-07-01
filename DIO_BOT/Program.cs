using System;
using System.Runtime;
using System.Collections.Generic;
using DIO_BOT.Enumerators;
using DIO_BOT.Classes;

namespace DIO_BOT;


class Program
{
     static SeriesRepository repository = new SeriesRepository();
     static void Main(string[] args)
     {
          string userOption = getUserOption();

          while (userOption.ToUpper() != "X")
          {
               switch (userOption)
               {
                    case "1":
                         ListSeries();
                         break;
                    case "2":
                         InsertSeries();
                         break;
                    case "3":
                         UpdateSeries();
                         break;
                    case "4":
                         DeleteSeries();
                         break;
                    case "5":
                         ViewSeriesInsertion();
                         break;
                    case "C":
                         Console.Clear();
                         break;

                    default:
                         throw new ArgumentOutOfRangeException();
               }

               
               userOption = getUserOption();
               
          }

          Console.WriteLine("Thank you for using DIO-BOT v0.1.");
          Console.ReadLine();
     }

     private static void DeleteSeries()
     {
          Console.Write("Type Series Id: ");
          int seriesIndex = int.Parse(Console.ReadLine());

          repository.Delete(seriesIndex);
     }

     private static void ViewSeriesInsertion()
     {
          Console.Write("Type Series Id: ");
          int seriesIndex = int.Parse(Console.ReadLine());

          var series = repository.ReturnId(seriesIndex);

          Console.WriteLine(series);
     }

     private static void UpdateSeries()
     {
          Console.Write("Type Series Id : ");
          int seriesIndex = int.Parse(Console.ReadLine());

          // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
          // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
          foreach (int i in Enum.GetValues(typeof(GendersEnum)))
          {
               Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GendersEnum), i));
               System.Console.WriteLine("-----------------");
          }
          
          int gendersEnumEntry = int.Parse(Console.ReadLine());

          try {
          Console.Write("Pick a gender amongst these up here ^^ : ");
          gendersEnumEntry = int.Parse(Console.ReadLine());
          } catch (System.FormatException) {
               System.Console.WriteLine($"The gender must be a number from 1 to {Enum.GetValues(typeof(GendersEnum)).Cast<GendersEnum>().Last()}");
          }

          while (gendersEnumEntry<1 && gendersEnumEntry>16 ) {
               System.Console.WriteLine("Invalid Value... Please try again.");
               System.Console.WriteLine("---------------------");
               Console.Write("Pick a gender amongst these up here ^^ : ");
               gendersEnumEntry = int.Parse(Console.ReadLine());
               
          }
     
          

          Console.Write("Type the Series Title: ");
          string titleEntry = Console.ReadLine();

          Console.Write("Type the premiere year of the series: ");
          int yearEntry = int.Parse(Console.ReadLine());

          Console.Write("Enter a description for the TV Show: ");
          string descriptionEntry = Console.ReadLine();

          Series atualizaSeries = new Series(id: seriesIndex,
                                             gender: (GendersEnum)gendersEnumEntry,
                                             title: titleEntry,
                                             year: yearEntry,
                                             description: descriptionEntry);

          repository.Update(seriesIndex, atualizaSeries);
     }
     private static void ListSeries()
     {
          Console.WriteLine("List Series");

          var list = repository.List();

          if (list.Count == 0)
          {
               Console.WriteLine("No entry has been found...");
               return;
          }

          foreach (var series in list)
          {
               var deleted = series.returnDeleted();

               Console.WriteLine("#ID {0}: - {1} {2}", series.returnId(), series.returnTitle(), (deleted ? "*Deleted*" : ""));
          }
     }

     private static void InsertSeries()
     {
          Console.WriteLine("Insert new Series");

          // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
          // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
          foreach (int i in Enum.GetValues(typeof(GendersEnum)))
          {
               Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(GendersEnum), i));
          }
          Console.Write("Pick a gender amongst these up here ^^ : ");
          int gendersEnumEntry = int.Parse(Console.ReadLine());

          Console.Write("Type the Series Title:  ");
          string titleEntry = Console.ReadLine();

          Console.Write("Type the premiere year of the series: ");
          int yearEntry = int.Parse(Console.ReadLine());

          Console.Write("Enter a description for the TV Show:  ");
          string descriptionEntry = Console.ReadLine();

          Series newSeries = new Series(id: repository.NextId(),
                                             gender: (GendersEnum)gendersEnumEntry,
                                             title: titleEntry,
                                             year: yearEntry,
                                             description: descriptionEntry);

          repository.Insert(newSeries);
     }

     private static string getUserOption()
     {
          Console.WriteLine();
          Console.WriteLine("DIO BOT at your service!!!");
          Console.WriteLine("Pick an option:");
          System.Console.WriteLine("--------------");

          Console.WriteLine("1- List Series");
          Console.WriteLine("2- Insert new TV Show");
          Console.WriteLine("3- Update TV Show");
          Console.WriteLine("4- Delete TV Show");
          Console.WriteLine("5- View registered Series");
          Console.WriteLine("C- Clear console");
          Console.WriteLine("X- Quit App");
          Console.WriteLine();

          string userOption = Console.ReadLine().ToUpper();
          Console.WriteLine();
          return userOption;
     }
}

