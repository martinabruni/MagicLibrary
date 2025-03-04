﻿using System;
using System.Collections.Generic;

namespace MagicLibrary.Core.Infrastructure.Models;

public partial class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
