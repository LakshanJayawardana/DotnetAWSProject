using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookStoreAPI.Models;


namespace BookStoreAPI.Data;
public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
}