﻿using System;
namespace FileWorxServer
{
    public class clsNews : clsFile
    {
        public string Category { get; set; }
        string separator = Constants.Separator;
        public override short Read()
        {
            base.Read();
            string SQLCommand = $"SELECT Category FROM T_News WHERE ID='{ID}'";
            string[,] queryResArray = null;
            int maxRows = 0;
            short maxColumns = 0;
            try
            {
                short status=dBConn.GetSQLData(SQLCommand, ref queryResArray, ref maxRows, ref maxColumns);
                Category = queryResArray[1, 1];
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during read: " + ex.Message);
                return -1;
            }
        }//Read
        public override short Insert()
        {
            base.Insert();
            string SQLCommand = $"INSERT INTO T_News (ID, Category) VALUES ('{ID}', '{Category}')";
            try
            {
               short status = dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during insert: " + ex.Message);
                return -1;
            }
        }//Insert
        public override short Update()
        {
            base.Update();
            string SQLCommand = $"UPDATE T_News SET Category='{Category}' WHERE ID = '{ID}'";
            try
            {
                short status=dBConn.RunSQLCommand(SQLCommand);
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred during update: " + ex.Message);
                return -1;
            }

        }//Update
        public void AddNewsToFile(string content, string fileName)
        {
            string[] newsParts = content.Split(new[] { separator }, StringSplitOptions.None);
            Name = newsParts[0];
            CreationDate = DateTime.Parse(newsParts[1]);
            Description = newsParts[2];
            Category = newsParts[3];
            Body = newsParts[4];
            LastModifier = newsParts[5];
            clsClass classDB = new clsClass();
            ClassID = (int)ClassIds.News;
            ID = Guid.NewGuid().ToString();
            FileName = fileName;
            Insert();
            
        }

    }
}
