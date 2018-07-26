namespace FluentAssertions.Tests
{
    public static class FluentAssertionsExtensions
    {
        public static UserAssertions ShouldBe(this User instance)
        {
            return new UserAssertions(instance);
        }
    }
}
