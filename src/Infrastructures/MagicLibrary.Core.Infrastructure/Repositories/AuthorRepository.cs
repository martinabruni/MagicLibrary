﻿using MagicLibrary.Core.Infrastructure.Abstractions;
using MagicLibrary.Core.Infrastructure.Models;

namespace MagicLibrary.Core.Infrastructure.Repositories
{
    internal class AuthorRepository : ARepositoryBase<AuthorEntity>
    {
        public AuthorRepository(SqldbMagiclibraryCoreDevContext context) : base(context)
        {
        }
    }
}
