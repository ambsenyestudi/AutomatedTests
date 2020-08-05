using Selenium.NetCore;
using System;
using Xunit;

namespace AutomatedTests.Test
{
    public class SeleniumActorShould
    {
        private readonly SeleniumActor sut;

        public SeleniumActorShould()
        {
            sut = new SeleniumActor();
        }
        [Fact]
        public void HitGoogle()
        {
            var success = sut.NavigateToGoogle();
            Assert.True(success);
        }
    }
}
