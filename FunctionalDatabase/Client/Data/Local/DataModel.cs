using System.Collections.Generic;
using DnetIndexedDb.Models;


namespace FunctionalDatabase.Client.Data.Local
{
    public static class DataModel
    {
        public static IndexedDbDatabaseModel GetDataModel() 
            => new IndexedDbDatabaseModel
            {
                Name = "ProductsModel",
                Version = 1,
                Stores = new List<IndexedDbStore>
                {
                    new IndexedDbStore
                    {
                        Name="productStore",
                        Key = new IndexedDbStoreParameter
                        {
                            KeyPath = "productId",
                            AutoIncrement = true
                        },
                        Indexes = new List<IndexedDbIndex>
                        {
                            new IndexedDbIndex
                            {
                                Name = "productId", Definition = new IndexedDbIndexParameter { Unique = true }
                            },
                            new IndexedDbIndex
                            {
                                Name = "productName", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "supplierId", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "categoryId", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "quantityPerUnit", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "unitPrice", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "unitsInStock", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "unitsOnOrder", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "reorderLevel", Definition = new IndexedDbIndexParameter {Unique = false}
                            },
                            new IndexedDbIndex
                            {
                                Name = "discontinued", Definition = new IndexedDbIndexParameter {Unique = false}
                            }
                        }
                    }
                },
                DbModelId = 0
            };
    }
}