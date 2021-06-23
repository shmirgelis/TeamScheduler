using System;
using Xunit;
using TeamScheduler;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

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

        [Fact]
        public void ProvidedTeamsListIsNull_ThrowsException()
        {
            //Arrange
            var sut = new ScheduleGenerator();
            //Act
            Action testCode = () => sut.GenerateMatches(null);

            //Assert
            Assert.Throws<ArgumentNullException>(testCode);
            
        }

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

        [Fact]
        public void ProvidedTeamsListHasOneTeam_ReturnsListWithSingleTeam()
        {
            //Arrange
            var generator = new ScheduleGenerator();
            var teams = new List<string> {"Rytas"};
            var expectedResult = new List<Match>();

            //Act
            List<Match> result = generator.GenerateMatches(teams);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NumberOfProvidedTeamsIsOdd_ReturnsListOfTeamsWithAddedGhostTeamBye()
        {
            //Arrange
            var generator = new ScheduleGenerator();
            var teams = new List<string> { "Rytas", "Zalgiris", "Nafta" };
            var expectedResult = new List<Match> { new Match("Rytas", "Bye", 1), new Match("Zalgiris", "Nafta", 1), new Match("Nafta", "Rytas", 2), new Match("Zalgiris", "Bye", 2), new Match("Rytas", "Zalgiris", 3), new Match("Nafta", "Bye", 3) };
            var serializedExpectedResult = JsonSerializer.Serialize(expectedResult);

            //Act
            List<Match> result = generator.GenerateMatches(teams);
            var serializedResult = JsonSerializer.Serialize(result);
            //Assert
            Assert.Equal(serializedResult, serializedExpectedResult);
        }

        [Fact]
        public void ProvidedTeamsListHasTwoTeams_ReturnsListWithOneMatch()
        {
            //Arrange
            var generator = new ScheduleGenerator();
            var teams = new List<string> { "Rytas", "Nafta" };
            var expectedResult = new List<Match> { new Match("Rytas", "Nafta", 1) };
            var serializedExpectedResult = JsonSerializer.Serialize(expectedResult);
            

            //Act
            List<Match> result = generator.GenerateMatches(teams);
            var serializedResult = JsonSerializer.Serialize(result);

            //Assert
            Assert.Equal(serializedResult, serializedExpectedResult);
        }

        [Fact]
        public void SixProvidedTeams_ReturnsListOfMatchedTeams()
        {
            //Arrange
            var generator = new ScheduleGenerator();
            var teams = new List<string> { "Rytas", "Zalgiris", "Nafta", "Neptunas", "Telia", "Sakalai" };
            var expectedResult = new List<Match> { new Match("Rytas", "Sakalai", 1), new Match("Zalgiris", "Telia", 1), new Match("Nafta", "Neptunas", 1), new Match("Telia", "Rytas", 2), new Match("Neptunas", "Sakalai", 2), new Match("Nafta", "Zalgiris", 2), new Match("Rytas", "Neptunas", 3), new Match("Telia", "Nafta", 3), new Match("Sakalai", "Zalgiris", 3), new Match("Nafta", "Rytas", 4), new Match("Zalgiris", "Neptunas", 4), new Match("Sakalai", "Telia", 4), new Match("Rytas", "Zalgiris", 5), new Match("Nafta", "Sakalai", 5), new Match("Neptunas", "Telia", 5) };
            var serializedExpectedResult = JsonSerializer.Serialize(expectedResult);

            //Act
            List<Match> result = generator.GenerateMatches(teams);
            var serializedResult = JsonSerializer.Serialize(result);
            //Assert
            Assert.Equal(serializedResult, serializedExpectedResult);
        }

    }

}
