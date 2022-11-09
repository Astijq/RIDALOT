namespace ridalot2._0.Data
{
    public class Post
    {
        public Status Status { get; set ; }
        public string? User { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Weight { get; set; }
        public double AddressLat { get; set; }
        public double AddressLng { get; set; }
        public int Pay { get; set; }
        public string? Time { get; set; }
        public string? Worker
        {
            get; set;
        }
    }
}