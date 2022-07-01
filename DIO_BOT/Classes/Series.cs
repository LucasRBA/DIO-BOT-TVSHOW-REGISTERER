using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_BOT.Enumerators;

namespace DIO_BOT.Classes
{
     public class Series : BaseEntity
     {
          // Atributes
          private GendersEnum Gender { get; set; }
          private string Title { get; set; }
          private string Description { get; set; }
          private int Year { get; set; }
          private bool Deleted { get; set; }

          // Methods
          public Series(int id, GendersEnum gender, string title, string description, int year)
          {
               this.Id = id;
               this.Gender = gender;
               this.Title = title;
               this.Description = description;
               this.Year = year;
               this.Deleted = false;
          }

          public override string ToString()
          {
               // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
               string returned = "";
               returned += "Gender: " + this.Gender + Environment.NewLine;
               returned += "Title: " + this.Title + Environment.NewLine;
               returned += "Description: " + this.Description + Environment.NewLine;
               returned += "Series Premiere: " + this.Year + Environment.NewLine;
               returned += "Deleted: " + this.Deleted;
               return returned;
          }

          public string returnTitle()
          {
               return this.Title;
          }

          public int returnId()
          {
               return this.Id;
          }
          public bool returnDeleted()
          {
               return this.Deleted;
          }
          public void Delete()
          {
               this.Deleted = true;
          }
     }
}