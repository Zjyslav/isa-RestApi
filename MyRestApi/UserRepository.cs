using Microsoft.EntityFrameworkCore;

namespace MyRestApi
{
    public class UserRepository : IUserRepository
    {
        ApiContext context;
        public UserRepository(ApiContext apiContext)
        {
            context = apiContext;
        }
        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public List<User> GetAll()
        {
            return context.Users.ToList();
        }
        public User Get(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
        public User Delete(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }
        public void Update(User user)
        {
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
