using System;
using Xunit;

namespace TeamSchedulerTest
{
    public class TeamShedulerTests
    {
        [Fact]
        public void CanInstantiate()
        {
            TeamScheduler generator = new TeamScheduler();
            Assert.NotNull(generator);
        }
    }
}
