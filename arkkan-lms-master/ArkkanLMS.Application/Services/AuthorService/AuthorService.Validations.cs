using ArkkanLMS.Application.Validators;
using ArkkanLMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkkanLMS.Application.Services
{
    public partial class AuthorService
    {
        private void ValidateAuthorOnCreate(Author author)
        {
            ModelValidator.ValidateModel(author);
        }

        private void ValidateAuthorOnUpdate(Author author)
        {         
            ModelValidator.ValidateModel(author);         
        }
    }
}


