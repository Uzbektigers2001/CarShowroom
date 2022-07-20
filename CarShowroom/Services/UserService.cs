using CarShowroom.ApplicationDbContext;
using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly BotDbContext _dbContex;
    
    private readonly ILogger<UserService> _logger;

    public UserService(BotDbContext context,ILogger<UserService> logger)
    {
        _dbContex=context;
        _logger=logger;
    }
   
    public async Task<UserModel?> GetUserAsync(int? Id)
    {
        ArgumentNullException.ThrowIfNull(Id);
        var user=await _dbContex.User.FindAsync(Id);
        return user;
    }
   
    public async Task<bool> Exits(int userId)
        => await _dbContex.User.AnyAsync(user=>user.Id==userId);
    
    public async Task<bool> UpdateUser(UserModel user)
    {
        try
        {
             _dbContex.User.Update(user);
             await _dbContex.SaveChangesAsync();
             return true;
        }
        catch (System.Exception e)
        {
            
            return false;
           
        }
    }
    
    public async Task<string?> GetUserLanguageCode(int userId)
    {
        var user =await GetUserAsync(userId);
        try
        {
            if(user is UserModel){
            return user.LanguageCode;
        }else{
            return null;
        }
        }
        catch (System.Exception)
        {  
            throw new ArgumentNullException();
        } 
    }
    
    public async Task<bool> UpdateUserLanguageCode(int? userId, string languageCode)
    {
        ArgumentNullException.ThrowIfNull(userId);
        try
        {
            var user=await GetUserAsync(userId);
        if(user is UserModel)
        {
            user.LanguageCode=languageCode;
            _dbContex.Update(user);
            await _dbContex.SaveChangesAsync();
            return true;
        }
        }
        catch (System.Exception)
        {
          throw new DbUpdateException(); 
        }
        return false;
    }
}