using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Domain.Abstractions;
using Clean.Architecture.API.Domain.Entities;
using static Clean.Architecture.API.Application.Utilities.Exceptions;

namespace Clean.Architecture.API.Domain.Builders {
    public class ApiSessionBuilder : Builder<ApiSession> {
        private readonly ILogger<ApiSessionBuilder> _logger;

        private string? _method;
        private string? _url;

        public ApiSessionBuilder(ILogger<ApiSessionBuilder> logger) {
            _logger = logger;
        }

        public ApiSessionBuilder WithMethod(string method) {
            _method = method;
            return this;
        }

        public ApiSessionBuilder WithURL(string url) {
            _url = url;
            return this;
        }

        public override ApiSession Build() {
            base.Build();

            return new ApiSession() {
                Method = _method!,
                URL = _url!
            };
        }

        protected override void SetupValidations() {
            if (_method!.IsNullOrEmpty()) {
                throw new BuilderException("ApiSession Method is required and cannot be null or empty.");
            } else if (_url!.IsNullOrEmpty()) {
                throw new BuilderException("ApiSession URL is required and cannot be null or empty.");
            }
        }
    }
}
