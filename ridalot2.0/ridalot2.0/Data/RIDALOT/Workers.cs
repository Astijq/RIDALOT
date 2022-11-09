using System.ComponentModel.DataAnnotations.Schema;

namespace ridalot2._0.Data
{
    public partial class Workers
    {
        public int Id
        {
            get; set;
        }
        public string? Email
        {
            get; set;
        }

        public string? LastName
        {
            get; set;
        }

        public string? BirthDate
        {
            get; set;
        }

        public string? Description
        {
            get; set;
        }

        public string? Phone
        {
            get; set;
        }

        public string? FirstName
        {
            get; set;
        }
    }
}
