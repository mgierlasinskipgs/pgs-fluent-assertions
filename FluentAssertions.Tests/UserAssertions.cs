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

        public virtual AndConstraint<UserAssertions> EqualTo(User expected)
        {
            Subject.Should().NotBeNull();
            Subject.Id.Should().BePositive();
            Subject.Should().BeEquivalentTo(expected, options => options
                .Excluding(x => x.Id));

            return new AndConstraint<UserAssertions>(this);
        }

        public virtual AndConstraint<UserAssertions> MappedFrom(UserDto userDto)
        {
            Subject.Should().NotBeNull();
            Subject.Should().BeEquivalentTo(userDto, options => options
                .ExcludingMissingMembers());

            return new AndConstraint<UserAssertions>(this);
        }
    }
}
