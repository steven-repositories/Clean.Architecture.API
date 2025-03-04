using Clean.Architecture.API.Application.Abstractions;
using Clean.Architecture.API.Application.Services;
using Moq;

namespace Clean.Architecture.API.Tests.Application.Services {
    public class ApiSesionServiceTests {
        private readonly Mock<IApiSession> _mockApiSessionService;

        public ApiSesionServiceTests()
        {
            _mockApiSessionService = new Mock<IApiSession>();

            _mockApiSessionService
                .Setup(service => service.SaveSession(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);
        }
    }
}
