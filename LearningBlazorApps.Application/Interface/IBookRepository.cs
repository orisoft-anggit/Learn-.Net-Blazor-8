using System;
using LearningBlazorApps.Domain.Entities;

namespace LearningBlazorApps.Application.Interface
{
	public interface IBookRepository
	{
		Task AddSync(Book book);
	}
}

