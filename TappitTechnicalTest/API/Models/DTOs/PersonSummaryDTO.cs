using System;
using System.Collections.Generic;

namespace API.Models.DTOs
{
    public class PersonSummaryDTO : PersonDTO
    {
        public IEnumerable<string> FavouriteSports { get; set; }

        public PersonSummaryDTO()
        {

        }

        public PersonSummaryDTO(PersonSummaryDTO copyObject)
        {
            this.IsEnabled = copyObject.IsEnabled;
            this.FavouriteSports = copyObject.FavouriteSports;
            this.FirstName = copyObject.FirstName;
            this.LastName = copyObject.LastName;
            this.IsValid = copyObject.IsValid;
            this.IsAuthorised = copyObject.IsAuthorised;
            this.LastName = copyObject.LastName;
            this.Id = copyObject.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is PersonSummaryDTO))
                return false;

            var other = obj as PersonSummaryDTO;

            return other.IsValid == this.IsValid
                && other.IsAuthorised == this.IsAuthorised
                && other.IsEnabled == this.IsEnabled
                && other.LastName == this.LastName
                && other.FirstName == this.FirstName
                && other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, Id, IsAuthorised, IsEnabled, IsValid, LastName, FavouriteSports);
        }
    }
}
