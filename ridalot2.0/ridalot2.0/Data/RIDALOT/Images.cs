using System.ComponentModel.DataAnnotations.Schema;

namespace ridalot2._0.Data.RIDALOT
{
    public partial class Images
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public virtual Posts? Posts { get; set; }
    }
}
