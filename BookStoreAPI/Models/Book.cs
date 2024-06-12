using System;
using System.Collections.Generic;

namespace BookStoreAPI.Models;

public class Book 
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Isbn { get; set; }
}