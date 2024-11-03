using Microsoft.EntityFrameworkCore;
using RandomUser.Api.Data;
using RandomUser.Api.Data.Models;
using RandomUser.Api.Requests.Users;
using RandomUser.Api.Responses;
using static RandomUser.Api.Common.Api.DateExtension;

namespace RandomUser.Api.Handlers;

public class UserHandler(AppDbContext context)
{
    public async Task<PagedResponse<List<User>?>> CreateUsersAsync(List<CreateUserRequest> requests)
    {
        try
        {
            List<User> users = [];
            users.AddRange(requests.Select(request => new User
            {
                Name = request.Name,
                Address = request.Address,
                BirthDate = request.BirthDate.ConvertDateFromUtc(),
                Email = request.Email,
                Gender = request.Gender,
                Mobile = request.Mobile,
                Nationality = request.Nationality,
                Phone = request.Phone,
                CreateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified),
                UpdateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified) 
            }));

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
            
            return new PagedResponse<List<User>?>(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new PagedResponse<List<User>?> (null, 500, "Não foi possível salvar os usuários!");

        }
    }
    
    public async Task<Response<User?>> UpdateAsync(UpdateUserRequest request)
    {
        try
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.Id == request.Id);
            
            if(user is null)
                return new Response<User?>(null, 404, "Usuário não encontrado");
            
            user.Name = request.Name;
            user.Email = request.Email;
            user.Gender = request.Gender;
            user.BirthDate = request.BirthDate.ConvertDateFromUtc();
            user.Nationality = request.Nationality;
            user.Address = request.Address;
            user.Mobile = request.Mobile;
            user.Phone = request.Phone;
            user.UpdateAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            
            context.Users.Update(user);
            await context.SaveChangesAsync();
            
            return new Response<User?>(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<User?>(null, 500, "Não foi possível atualizar o usuário!");
        }
    }
    
    public async Task<Response<User?>> GetByIdAsync(GetUserByIdRequest request)
    {
        try
        {
            var user = await context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            return user is null
                ? new Response<User?>(null, 404, "Usuário não encontrado!")
                : new Response<User?>(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<User?>(null, 500, "Não foi possível carregar o usuário!");
        }
    }
    
    public async Task<PagedResponse<List<User>?>> GetAllAsync(GetAllUsersRequest request)
    {
        try
        {
            var query =  context
                .Users
                .AsNoTracking()
                .AsQueryable();

            var users = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .OrderBy(x => x.Id)
                .ToListAsync();
            
            var count = await query.CountAsync();
            
            return new PagedResponse<List<User>?>(users, count, request.PageNumber, request.PageSize);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new PagedResponse<List<User>?> (null, 500, "Não foi possível recuperar os usuários!");
        }
    }
}