﻿using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CategoriesFileRepository : ICategoriesRepository
    {
        private FileInfo myFile;
        public CategoriesFileRepository(string path)
        {
            myFile = new FileInfo(path);
           
        }

        public void AddCategory(Category c)
        {
            var sw = myFile.AppendText();
            sw.WriteLine($"{c.Id};{c.Title}");
            sw.Close();
        }

        public IQueryable<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
             using (StreamReader sr = myFile.OpenText())
            {
                string line = "";
                while(sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    Category myCategory = new Category()
                    {
                        Id = Convert.ToInt32(line.Split(';')[0]),
                        Title = line.Split(';')[1]

                    };
                    categories.Add(myCategory);
                }
            }
            return categories.AsQueryable();
        }
 

        public Category  GetCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
