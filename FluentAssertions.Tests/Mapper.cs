namespace FluentAssertions.Tests
{
    public class Mapper
    {
        public User Map(UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address
            };
        }
    }
}
