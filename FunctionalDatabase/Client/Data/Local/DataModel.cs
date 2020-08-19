using System.Collections.Generic;
using DnetIndexedDb.Models;

namespace FunctionalDatabase.Client.Data.Local
{
    public static class DataModel
    {
        public static IndexedDbDatabaseModel GetDataModel()
            => new IndexedDbDatabaseModel
            {
                Name = "NorthWind",
                Version = 1,
                Stores = new List<IndexedDbStore>
                {
                    new IndexedDbStore
                    {
                        Name="Product",
                        Key = new IndexedDbStoreParameter
                        {
                            KeyPath = "ProductId",
                            AutoIncrement = false
                        },
                        Indexes = new List<IndexedDbIndex>
                        {
                            new IndexedDbIndex
                            {
                                Name = "productId", Definition = new IndexedDbIndexParameter { Unique = true }
                            }
                        }
                    }
                },
                DbModelId = 0
            };
    }
}