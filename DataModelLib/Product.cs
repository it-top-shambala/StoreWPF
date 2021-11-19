namespace DataModelLib
{
    public record Product
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public int Amount { get; init; }
        public string Annotation { get; init; }
        public string Image { get; init; }
    }
}