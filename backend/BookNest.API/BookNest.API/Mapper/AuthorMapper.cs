using BookNest.API.Models.Domain;
using BookNest.API.Models.DTO;
using Riok.Mapperly.Abstractions;

namespace BookNest.API.Mapper
{
    [Mapper]
    public partial class AuthorMapper
    {

        public partial Author AuthorDtoToAuthor(AuthorDto authorDto);

        public partial AuthorDto AthorToAuthorDto(Author author);

        public partial Author UpdateAuthorDtoToAuthor(UpdateAuthorDto authorDto);
    }
}
