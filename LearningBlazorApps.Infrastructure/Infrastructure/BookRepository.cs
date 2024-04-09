using LearningBlazorApps.Application.Interface;
using LearningBlazorApps.Domain.Entities;
using LearningBlazorApps.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LearningBlazorApps.Infrastructure.Infrastructure
{
	public class BookRepository : IBookRepository
	{
		private readonly DataContext context;

		public BookRepository(IDbContextFactory<DataContext> factory)
		{
			context = factory.CreateDbContext();
		}

        public async Task AddSync(Book book)
        {
			context.Books.Add(book);
			await context.SaveChangesAsync();
        }
    }
}

