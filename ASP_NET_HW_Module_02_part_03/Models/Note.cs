using System.ComponentModel.DataAnnotations;

namespace ASP_NET_HW_Module_02_part_03.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Tags { get; set; }
    }
}
