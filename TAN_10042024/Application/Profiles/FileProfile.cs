using AutoMapper;
using TAN_10042024.Domain.Entities;
using File = TAN_10042024.Domain.Entities.File;

namespace TAN_10042024.Application.Profiles {
    public class FileProfile : Profile {
        public FileProfile() {
            CreateMap<FileSchema, File>()
                .ForMember(member => member.Id, option => option.Ignore())
                .ForMember(member => member.CreatedDateTime, option => option.MapFrom(authSession => DateTime.Now));

            CreateMap<File, FileSchema>();
        }
    }
}
