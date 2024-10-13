using TAN_10042024.Application.Utilities;
using static TAN_10042024.Application.Utilities.Exceptions;
using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Application.Builders {
    public class FileBuilder : Builder<FileBuilder, File> {
        private string? _name;
        private string? _content;

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
