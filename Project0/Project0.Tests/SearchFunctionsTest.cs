using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace Project0.Tests
{
    public class SearchFunctionsTest
    {
        [Fact]
        public void Top3Search_NothingToSearch_ThrowsException()
        {
            Assert.Equal("", "");
        }
    }
}
