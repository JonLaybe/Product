namespace WpfProducts
{
    public class Product
    {
        public override string ToString()
        {
            return name;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string photo_path { get; set; }
        public string description { get; set; }
    }
}
