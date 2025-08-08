using ApplicationCore.Entities;
using AutoMapper;
using Shared.Dtos.Comanda;
using Shared.Dtos.ComandaItem;
using Shared.Dtos.Usuario;

namespace WebAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AllowNullCollections = true;

        //jeito mais fácil?
        CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<uint?, uint>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<long?, long>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<ulong?, ulong>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<short?, short>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<ushort?, ushort>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<float?, float>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<char?, char>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<byte?, byte>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);
        CreateMap<TimeOnly?, TimeOnly>().ConvertUsing((src, dest) => src ?? dest);

        CreateMap<Usuario, ReadUsuarioDto>();
        CreateMap<CreateUsuarioDto, Usuario>();
        CreateMap<ReadUsuarioDto, Usuario>();

        CreateMap<Comanda, ReadComandaDto>()
            .ForMember(
                dest => dest.NomeUsuario,
                opt => opt.MapFrom(src => src.Usuario.Nome)
            )
            .ForMember(
                dest => dest.TelefoneUsuario,
                opt => opt.MapFrom(src => src.Usuario.Telefone)
            );
        CreateMap<CreateComandaDto, Comanda>();
        CreateMap<ReadComandaDto, Comanda>();
        
        CreateMap<CreateComandaItemDto, ComandaItem>();
        CreateMap<ReadComandaItemDto, ComandaItem>();
    }
}
