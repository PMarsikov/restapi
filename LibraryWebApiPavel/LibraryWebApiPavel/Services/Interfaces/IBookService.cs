﻿using LibraryWebApiPavel.Dto;

namespace LibraryWebApiPavel.Services.Interfaces
{
    public interface IBookService
    {
        public List<BookDetailDto> GetBooksDetails();
    }
}
