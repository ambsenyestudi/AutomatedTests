using Selenium.NetCore;
using Xunit;

namespace AutomatedTests.Test
{
    public class ImdbSeleniumActorShould
    {
        private readonly ImdbSeleniumActor sut;

        public ImdbSeleniumActorShould()
        {
            //feature toggle isWait
            sut = new ImdbSeleniumActor();
        }

        [Fact]
        public void FindTheMatrix()
        {
            var success = sut.SearchMovie("The matrix");
            Assert.True(success);
        }
        [Fact]
        public void FindRelatedToMatrix()
        {
            var success = sut.FindMore("The matrix");
            Assert.True(success);
        }
    }
}
