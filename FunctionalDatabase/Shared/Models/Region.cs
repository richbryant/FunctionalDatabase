using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Shared.Models
{
    [Table(Schema="dbo", Name="Region")]
    public partial class Region
    {
        [PrimaryKey, NotNull] public int    RegionId          { get; set; } // int
        [Column,     NotNull] public string RegionDescription { get; set; } // nchar(50)

        #region Associations

        /// <summary>
        /// FK_Territories_Region_BackReference
        /// </summary>
        [Association(ThisKey="RegionID", OtherKey="RegionID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
        public IEnumerable<Territory> Territories { get; set; }

        #endregion
    }
}