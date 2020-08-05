using Selenium.NetCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutomatedTests.Test
{
    public class GoogleSeleniumActorShould
    {
        private readonly GoogleSeleniumActor sut;

        public GoogleSeleniumActorShould()
        {
            sut = new GoogleSeleniumActor();
        }
        [Fact]
        public void FindTortillaPatatas()
        {
            var success = sut.Ask("Receta tortilla patatas");
            Assert.True(success);
        }
    }
}
