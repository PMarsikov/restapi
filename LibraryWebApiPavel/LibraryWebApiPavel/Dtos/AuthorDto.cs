﻿namespace LibraryWebApiPavel.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleName { get; set; }
        public string AuthorLastName { get; set; }
        public DateTime AuthorBirthDay { get; set; }
    }
}
