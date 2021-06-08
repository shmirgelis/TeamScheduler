using System;
using Xunit;
using TeamScheduler;
using System.Collections.Generic;

namespace TeamSchedulerTests
{
    public class ScheduleGeneratorTests
    {
        [Fact]
        public void CanInstantiate()
        {
            var generator = new ScheduleGenerator();
            Assert.NotNull(generator);
        }

        //[Fact]
        //public void ProvidedTeamsListIsNull_ThrowsException()
        //{
        //    //Arrange
        //    var generator = new ScheduleGenerator();
        //    //Act
        //    generator.GenerateMatches(null);
        //   //Assert

        //    var generator = new ScheduleGenerator();
        //    Assert.NotNull(generator);
        //}

        [Fact]
        public void ProvidedTeamsListIsEmpty_ReturnsEmptySchedule()
        {
            //Arrange
            var generator = new ScheduleGenerator();
            var teams = new List<string>();
            var expectedResult = new List<Match>();

            //Act
            List<Match> result = generator.GenerateMatches(teams);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }

}
