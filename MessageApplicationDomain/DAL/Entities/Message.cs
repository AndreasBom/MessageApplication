using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MessageApplicationDomain.DAL.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string TextMessage { get; set; }
    }
}
