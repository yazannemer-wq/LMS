using ArkkanLMS.Core.DataTransferObjects;
using ArkkanLMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArkkanLMS.Core.Interfaces
{
    public interface IAuthorService
    {
        Task<List<Author>> GetAuthorsAsync();

        Task<Author> GetAuthorAsync(int id);

        Task<Author> AddAuthorAsync(CreateAuthorDto authorDto);

        Task<Author> UpdateAuthorAsync(UpdateAuthorDto authorDto);

        Task<Author> DeleteAuthorAsync(int id);
    }
}


