using BookNest.API.Models.Domain;
using BookNest.API.Models.DTO;
using Riok.Mapperly.Abstractions;

namespace BookNest.API.Mapper
{
    [Mapper]
    public partial class BookMapper
    {
        public partial Book BookDtoToBook(BookDto bookDto);
        public partial BookDto BookToBookDto(Book book);
    }
}
