using Selenium.NetCore;
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
            var url = GoogleSeleniumActor.GOOGLE_URL;
            var success = sut.NavigateTo(url);
            Assert.True(success);
        }
        [Fact]
        public void CloseAfterHittingGoogle()
        {
            var url = GoogleSeleniumActor.GOOGLE_URL;
            sut.NavigateTo(url);
            var success = sut.Close();
            Assert.True(success);
        }
    }
}
