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

                return new Response<Category>(category, 201, "Created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return new Response<Category?>(null, 500, ex.Message);
            }
        }

        public async Task<Response<Category?>> DaleteAsync(DeleteCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Category>>> GetAllAsync(GetAllCategoriesRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            throw new NotImplementedException();
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