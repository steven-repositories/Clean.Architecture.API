using Clean.Architecture.API.Application.Utilities;
using Clean.Architecture.API.Domain.Abstractions;
using static Clean.Architecture.API.Application.Utilities.Exceptions;
using File = Clean.Architecture.API.Domain.Entities.File;

namespace Clean.Architecture.API.Domain.Builders {
    public class FileBuilder : Builder<File> {
        private readonly ILogger<FileBuilder> _logger;

        private string? _name;
        private string? _content;

        public FileBuilder(ILogger<FileBuilder> logger) {
            _logger = logger;
        }

        public FileBuilder WithName(string name) {
            _name = name;
            return this;
        }

        public FileBuilder WithContent(string content) {
            _content = content;
            return this;
        }

        public override File Build() {
            base.Build();

            return new File() {
                Name = _name!,
                Content = _content!
            };
        }

        protected override void SetupValidations() {
            if (_name!.IsNullOrEmpty()) {
                throw new BuilderException("File name is required and cannot be null or empty.");
            } else if (_content!.IsNullOrEmpty()) {
                throw new BuilderException("File content is required and cannot be null or empty.");
            }
        }
    }
}
