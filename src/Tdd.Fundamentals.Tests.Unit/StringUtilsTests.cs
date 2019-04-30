using System;
using FluentAssertions;
using Moq;
using Xunit;

namespace Tdd.Fundamentals.Tests.Unit
{
    public class StringUtilsTests
    {
        private Mock<ILogger> LoggerMock { get; set; }

        private StringUtils Sut { get; set; }

        public StringUtilsTests()
        {
            this.LoggerMock = new Mock<ILogger>();

            this.Sut = new StringUtils(this.LoggerMock.Object);
        }

        public class TheMethod_FindNumberOfOccurrences : StringUtilsTests
        {
            [Fact]
            public void Should_return_a_count_of_2_for_character_e_in_simple_sentence()
            {
                // arrange
                string sentence = "TDD is awesome!";

                string character = "e";

                // act
                int expected = this.Sut.FindNumberOfOccurrences(sentence, character);

                // assert
                expected.Should().Be(2);
            }

            [Fact]
            public void Should_return_a_count_of_5_for_character_n_in_complex_sentence()
            {
                // arrange
                string sentence = "Once is unique, twice is a coincidence, three times is a pattern.";

                string character = "n";

                // act
                int expected = this.Sut.FindNumberOfOccurrences(sentence, character);

                // assert
                expected.Should().Be(5);
            }

            [Fact]
            public void Should_throw_an_ArgumentException_with_paramName_character_when_character_has_two_letters()
            {
                // arrange
                string sentence = "This test case should throw an exception.";

                string character = "xx";

                // act & assert
                Assert.Throws<ArgumentException>(nameof(character), () => this.Sut.FindNumberOfOccurrences(sentence, character));
            }

            [Fact]
            public void Should_log_the_member_call_specifying_received_parameters()
            {
                // arrange
                string sentence = "Sentence to log.";

                string character = "e";

                string memberName = nameof(StringUtils.FindNumberOfOccurrences);

                // act
                this.Sut.FindNumberOfOccurrences(sentence, character);

                // assert
                this.LoggerMock.Verify(logger => logger.LogMemberCalled(memberName, sentence, character), Times.Once());
            }
        }
    }
}
