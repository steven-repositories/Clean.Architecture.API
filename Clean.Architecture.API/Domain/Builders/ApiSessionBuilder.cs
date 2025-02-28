using TAN_10042024.Application.Utilities;
using TAN_10042024.Domain.Abstractions;
using TAN_10042024.Domain.Entities;
using static TAN_10042024.Application.Utilities.Exceptions;

namespace TAN_10042024.Domain.Builders {
    public class ApiSessionBuilder : Builder<ApiSessionBuilder, ApiSession> {
        private string? _method;
        private string? _url;

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
