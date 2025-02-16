using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dima.Api.Data;
using Dima.Core.Hendlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {

                var category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };

                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return new Response<Category?>(category, 201, "Created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return new Response<Category?>(null, 500, ex.Message);
            }
        }

        public async Task<Response<Category?>> DaleteAsync(DeleteCategoryRequest request)
        {
            try
            {


                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (category == null)
                {
                    return new Response<Category?>(null, 404, "Category notfound");
                }

                if (category != null)
                {
                    context.Categories.Remove(category);
                    await context.SaveChangesAsync();
                }

                return new Response<Category?>(category, 200, "Deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Response<Category?>(null, 500, ex.Message);
            }
        }

        public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            try
            {

                var query = context.Categories.AsNoTracking().Where(x => x.UserId == request.UserId);


                var count = await query
                .CountAsync();

                var categories = await query
                .Skip(request.PageSize * request.PageNumber)
                .Take(request.PageSize)
                .ToListAsync();

                return new PagedResponse<List<Category>>(categories, count, request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new PagedResponse<List<Category>>(null, 500, ex.Message);
            }
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {


                var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (category == null)
                {
                    return new Response<Category?>(null, 404, "Category not found");
                }

                return new Response<Category?>(category, 200, "Succes");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Response<Category?>(null, 500, ex.Message);
            }
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {


                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (category == null)
                {
                    return new Response<Category?>(null, 404, "Category notfound");
                }

                if (category != null)
                {
                    category.Title = request.Title;
                    category.Description = request.Description;
                    context.Categories.Update(category);
                    await context.SaveChangesAsync();
                }

                return new Response<Category?>(category, 200, "Updated");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Response<Category?>(null, 500, ex.Message);
            }
        }
    }
}