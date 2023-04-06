﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.WPF.Learning.ViewModel.Helpers
{
    public class DataBaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDB.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new(dbFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Insert(item);
                if (rows > 0)
                    result = true;
            }


            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new(dbFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Update(item);
                if (rows > 0)
                    result = true;
            }


            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection conn = new(dbFile))
            {
                conn.CreateTable<T>();
                int rows = conn.Delete(item);
                if (rows > 0)
                    result = true;
            }


            return result;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> items = new List<T>();

            using (SQLiteConnection conn = new(dbFile))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }


            return items;
        }
    }
}
