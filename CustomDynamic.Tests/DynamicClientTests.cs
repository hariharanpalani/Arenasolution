using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomDynamic.Tests
{
    public class DynamicClientTests
    {
        [Fact]
        public void GetMemberName()
        {
            dynamic client = new DynamicClient();

            var output = client.New.GetAsync();

            Assert.Equal("New.GetAsync", output);
        }
    }
}
