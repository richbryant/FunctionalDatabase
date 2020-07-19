using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Server.Data.Models
{
    
    [Table(Schema="dbo", Name="Territories")]
    public partial class Territory
    {
        [PrimaryKey, NotNull] public string TerritoryID          { get; set; } // nvarchar(20)
        [Column,     NotNull] public string TerritoryDescription { get; set; } // nchar(50)
        [Column,     NotNull] public int    RegionID             { get; set; } // int

        #region Associations

        /// <summary>
        /// FK_Territories_Region
        /// </summary>
        [Association(ThisKey="RegionID", OtherKey="RegionID", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Territories_Region", BackReferenceName="Territories")]
        public Region Region { get; set; }

        #endregion
    }
}