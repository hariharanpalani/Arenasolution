using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomDynamic.Tests
{
    public class HtmlElementTests
    {
        [Fact]
        public void ShouldStoreTagName()
        {
            var image = new HtmlElement("img");

            Assert.Equal("img", image.TagName);
        }

        [Fact]
        public void ShouldAddNameAndValueAttributeDynamically()
        {
            dynamic image = new HtmlElement("img");
            image.Source = "facebook.png";

            Assert.Equal("facebook.png", image.Source);
        }

        [Fact]
        public void ShouldGiveErrorIfNotSet()
        {
            dynamic image = new HtmlElement("img");

            Assert.Throws<RuntimeBinderException>(() => image.Source);
        }

        [Fact]
        public void ShouldReturnDynamicNames()
        {
            dynamic image = new HtmlElement("img");

            image.src = "image.png";
            image.alt = "Images";

            var actual = image.GetDynamicMemberNames();

            Assert.Equal(2, actual.Length);
        }

        [Fact]
        public void ShouldEmitRightImgHtml()
        {
            dynamic image = new HtmlElement("img");

            image.src = "mine.png";
            image.alt = "my photo";

            var actual = image.ToString();

            Assert.Equal("<img src='mine.png' alt='my photo' />", actual);
        }

        [Fact]
        public void ShouldAbleToCastToDictionary()
        {
            dynamic image = new HtmlElement("img");

            var attributes = image as IDictionary<string, object>;

            attributes["src"] = "car.png";

            Assert.Equal("car.png", image.src);
        }

        [Fact]
        public void ShouldBeEnumerable()
        {
            dynamic image = new HtmlElement("img");

            image.src = "car.png";

            var count = 0;
            foreach (var item in (IDictionary<string, object>)image)
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        [Fact]
        public void ShouldRenderHtml()
        {
            dynamic image = new HtmlElement("img");

            image.src = "mine.png";
            image.alt = "my photo";

            var actual = image.Render();

            Assert.Equal("<img src='mine.png' alt='my photo' />", actual);
        }

        [Fact]
        public void ShowRenderByInvoke()
        {
            dynamic image = new HtmlElement("img");

            image.src = "mine.png";
            image.alt = "my photo";

            var actual = image();
            Assert.Equal("<img src='mine.png' alt='my photo' />", actual);
        }
    }
}
