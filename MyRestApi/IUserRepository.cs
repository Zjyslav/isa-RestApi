namespace MyRestApi
{
    public interface IUserRepository
    {
        public void Add(User user);
        public List<User> GetAll();
        public User Get(int id);
        public User Delete(int id);
        public void Update(User user);
    }
}
