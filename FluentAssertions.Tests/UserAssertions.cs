using FluentAssertions.Primitives;

namespace FluentAssertions.Tests
{
    public class UserAssertions : ReferenceTypeAssertions<User, UserAssertions>
    {
        protected override string Identifier => nameof(User);

        public UserAssertions(User instance)
        {
            Subject = instance;
        }

        public AndConstraint<UserAssertions> EqualTo(User expected)
        {
            Subject.Should().NotBeNull();
            Subject.Id.Should().BePositive();
            Subject.Should().BeEquivalentTo(expected, options => options
                .Excluding(x => x.Id));

            return new AndConstraint<UserAssertions>(this);
        }

        public AndConstraint<UserAssertions> MappedFrom(UserDto userDto)
        {
            Subject.Should().NotBeNull();
            Subject.Should().BeEquivalentTo(userDto, options => options
                .ExcludingMissingMembers());
            Subject.Address.Should().Be(userDto.City);

            return new AndConstraint<UserAssertions>(this);
        }
    }
}
