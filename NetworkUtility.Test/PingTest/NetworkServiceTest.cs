using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Test.PingTest
{
    /// <summary>
    /// I am using https://fluentassertions.com/ for Assert part
    /// I am Using https://fakeiteasy.github.io/ in order to create Mocks (Fake Data)
    /// </summary>
    public class NetworkServiceTest
    {
        private readonly NetworkService _networkService;
        private readonly IDNS _Idns;
        public NetworkServiceTest()
        {
            //Dependency 
            _Idns = A.Fake<IDNS>(); //fakeiteasy to fake the Interface
            //SUT -sut is a common abreviature 
            _networkService = new NetworkService(_Idns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method
            A.CallTo(()=> _Idns.SendDNS()).Returns(true); //fakeiteasy to asigned the return value

            //Act - execute this function
            string pingValue = _networkService.SendPing();

            //Assert - wherever is returned is that what you want
            pingValue.Should().NotBeNullOrWhiteSpace();
            pingValue.Should().Be("ping sent");
            pingValue.Should().Contain("sent", Exactly.Once());
        }
        [Fact]
        public void NetworkService_PingTimeOut_ReturnInt()
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method
            //NetworkService service = new NetworkService();
            int a = 5;
            int b = 10;
            //Act - execute this function
            int pingTimeOut = _networkService.PingTimeOut(a, b);

            //Assert - wherever is returned is that what you want
            pingTimeOut.Should().BePositive();
            pingTimeOut.Should().BeGreaterThan(a);
            pingTimeOut.Should().BeGreaterThan(b);
            pingTimeOut.Should().Be(a + b);
        }
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(1, 5, 6)]
        public void NetworkService_PingTimeOut_ReturnInt_SecondWay(int a, int b, int expectedResult)
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method
            //NetworkService service = new NetworkService();

            //Act - execute this function
            int pingTimeOut = _networkService.PingTimeOut(a, b);

            //Assert - wherever is returned is that what you want
            pingTimeOut.Should().Be(expectedResult);
            pingTimeOut.Should().BePositive();

        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method

            //Act - execute this function
            DateTime pingLastDate = _networkService.LastPingDate();

            //Assert - wherever is returned is that what you want
            pingLastDate.Should().BeAfter(1.February(2010));
            pingLastDate.Should().BeBefore(2.March(2025));
        }
        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method
            PingOptions expected = new PingOptions() { DontFragment = true, Ttl = 1 };
            //Act - execute this function
            PingOptions pingOptions = _networkService.GetPingOptions();

            //Assert - wherever is returned is that what you want
            pingOptions.Should().NotBeNull();
            pingOptions.Should().BeOfType<PingOptions>();
            pingOptions.Should().BeEquivalentTo(expected);
            pingOptions.Ttl.Should().Be(1);
        }
        [Fact]
        public void NetworkService_LastPings_ReturnIEnumerable()
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method

            //Act - execute this function
            IEnumerable<PingOptions> pingOptions = _networkService.LastPings();

            //Assert - wherever is returned is that what you want
            pingOptions.Should().NotBeEmpty();
            pingOptions.Should().HaveCount(3);
            pingOptions.Should().Contain(x => x.DontFragment == true);
        }

        [Fact]
        public void NetworkService_GetPingOptionsByDns_ReturnObject()
        {
            //Arrange - Go get your Variables, wherever you need, Your class, you method
            A.CallTo(() => _Idns.GetDnsByTLS())
                .Returns(new PingOptions() { DontFragment = true, Ttl = 1 }); //fakeiteasy to asigned the return object

            //Act - execute this function
            PingOptions pingOptions = _networkService.GetPingOptionsByDns();

            //Assert - wherever is returned is that what you want
            pingOptions.Should().NotBeNull();
            pingOptions.Should().BeOfType<PingOptions>();
            pingOptions.Ttl.Should().Be(1);
        }
    }
}