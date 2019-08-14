using API.Controllers;
using System;
using Xunit;

namespace API.Tests
{
    public class HelloFixture
    {
        [Fact]
        public void No_Parameter_Should_Return_BYE_Test()
        {
            HelloController hello = new HelloController();
            Assert.Equal("Bye", hello.Get().Value);
        }
        [Fact]
        public void Hi_Parameter_Should_Return_Hello_Test()
        {
            HelloController hello = new HelloController();
            Assert.Equal("Hello", hello.Get("Hi").Value);
        }
        [Fact]
        public void Hello_Parameter_Should_Return_Hi_Test()
        {
            HelloController hello = new HelloController();
            Assert.Equal("Hi", hello.Get("Hello").Value);
        }
        [Fact]
        public void Default_Value_Test()
        {
            HelloController hello = new HelloController();
            Assert.Equal("Say Hello or Hi First", hello.Get("abcd").Value);
        }
    }
}
