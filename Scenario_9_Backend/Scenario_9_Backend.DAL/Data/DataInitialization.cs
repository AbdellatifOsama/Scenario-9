using Microsoft.Extensions.Logging;
using Scenario_9_Backend.DAL.Data.SeedData;
using Scenario_9_Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Scenario_9_Backend.DAL.Data
{
    public class DataInitialization
    {
        private static readonly string FolderPath = "../Scenario_9_Backend.DAL/Data/SeedData/JSON Files/";
        public async static Task Data_Initialize_Async(LibraryContext LibraryContext, ILoggerFactory loggerFactory)
        {
            await Books_Data_Initialize_Async(LibraryContext, loggerFactory);
        }
        private async static Task Books_Data_Initialize_Async(LibraryContext LibraryContext, ILoggerFactory loggerFactory)
        {
            try
            {
                var FileName = "Books Data.json";
                var FilePath = Path.Combine(FolderPath, FileName);
                if (!LibraryContext.Set<BookEntity>().Any())
                {
                    var JsonData = await File.ReadAllTextAsync(FilePath);
                    var DataObjects = JsonSerializer.Deserialize<List<BooksJsonDataType>>(JsonData);
                    var MappedObjects = DataTypeEditors.Books_File_DataTypesEditor(DataObjects);
                    foreach (var obj in MappedObjects)
                    {
                        LibraryContext.Set<BookEntity>().Add(obj);
                        await LibraryContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitialization>();
                logger.LogError(ex.Message);
            }
        }
    }
}
