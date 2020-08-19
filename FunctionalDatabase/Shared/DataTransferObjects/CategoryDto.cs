namespace FunctionalDatabase.Shared.DataTransferObjects
{
    public class CategoryDto
    {
        public int    CategoryId   { get; set; }
        public string CategoryName { get; set; }
        public string Description  { get; set; }
        public byte[] Picture      { get; set; }
    }
}