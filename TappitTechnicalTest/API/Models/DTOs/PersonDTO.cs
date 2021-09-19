using System.Collections.Generic;

namespace API.Models.DTOs
{
    public class PersonDTO
    {
        public string FirstName {  get; set; }
        public int Id {  get; set; }
        public bool IsAuthorised { get; set;  }
        public bool IsEnabled {  get; set; }
        public bool IsValid {  get; set; }
        public string LastName {  get; set; }
    }
}
