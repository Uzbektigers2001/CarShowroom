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
   
    public async Task<UserModel?> GetUserAsync(long? Id)
    {
        ArgumentNullException.ThrowIfNull(Id);
        var user=await _dbContex.User.FirstOrDefaultAsync(x => x.Id == Id);
        return user;
    }
   
    public async Task<bool> Exits(long? userId){
        ArgumentNullException.ThrowIfNull(userId);
        try
        {
          return  await _dbContex.User.AnyAsync(user=>user.Id==userId);
        }
        catch (System.Exception)
        {
            return false;
        }
         
    }
        
    
    public async Task<bool> UpdateUser(UserModel user)
    {
        try
        {
             _dbContex.User.Update(user);
             await _dbContex.SaveChangesAsync();
             return true;
        }
        catch (System.Exception)
        {
            
            return false;
           
        }
    }
    public async Task<bool> AddNewUser(UserModel user)
    {
        _dbContex.User.Add(user);
        try
        {
            await _dbContex.SaveChangesAsync();
            return true;
        }
        catch (System.Exception)
        {
            
            return false;
        }
        
    }   
    public async Task<string?> GetUserLanguageCode(long? userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
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
    
    public async Task<bool> UpdateUserLanguageCode(long? userId, string languageCode)
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