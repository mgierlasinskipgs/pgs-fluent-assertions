using NUnit.Framework;

namespace FluentAssertions.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Mapping_user_should_succeed_standard_assertion()
        {
            // Arrange
            var mapper = new Mapper();
            var userDto = CreateTestData();

            // Act
            var user = mapper.Map(userDto);

            // Assert
            Assert.AreEqual(user.FirstName, userDto.FirstName);
            Assert.AreEqual(user.LastName, userDto.LastName);
            Assert.AreEqual(user.Address, userDto.Address);
        }

        [Test]
        public void Mapping_user_should_succeed_fluent_assertion()
        {
            // Arrange
            var mapper = new Mapper();
            var userDto = CreateTestData();

            // Act
            var user = mapper.Map(userDto);

            // Assert
            user.FirstName.Should().Be(userDto.FirstName);
            user.LastName.Should().Be(userDto.LastName);
            user.Address.Should().Be(userDto.Address);
        }

        [Test]
        public void Mapping_user_should_succeed_object_comparision_exclude()
        {
            // Arrange
            var mapper = new Mapper();
            var userDto = CreateTestData();

            // Act
            var user = mapper.Map(userDto);

            // Assert
            user.Should().NotBeNull();
            user.Should().BeEquivalentTo(userDto, options => options
                .Excluding(x => x.CustomProperty1)
                .Excluding(x => x.CustomProperty2)
                .Excluding(x => x.CustomProperty3));
        }

        [Test]
        public void Mapping_user_should_succeed_object_comparision_exclude_all()
        {
            // Arrange
            var mapper = new Mapper();
            var userDto = CreateTestData();

            // Act
            var user = mapper.Map(userDto);

            // Assert
            user.Should().NotBeNull();
            user.Should().BeEquivalentTo(userDto, options => options
                .ExcludingMissingMembers());
        }

        [Test]
        public void Mapping_user_should_succeed_fluent_extension()
        {
            // Arrange
            var mapper = new Mapper();
            var userDto = CreateTestData();

            // Act
            var user = mapper.Map(userDto);

            // Assert
            user.ShouldBe().MappedFrom(userDto);
        }

        private UserDto CreateTestData()
        {
            return new UserDto
            {
                FirstName = "John",
                LastName = "Smith",
                Address = "Rzeszow"
            };
        }
    }
}
