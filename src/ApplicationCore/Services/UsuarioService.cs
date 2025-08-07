using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Shared.Dtos.Usuario;
using Shared.Interfaces;
namespace ApplicationCore.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UsuarioService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager logger)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ReadUsuarioDto> CreateAsync(CreateUsuarioDto parameters)
    {
        Usuario usuario = _mapper.Map<Usuario>(parameters);

        await _repositoryManager.Usuario.CreateAsync(usuario);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<ReadUsuarioDto>(usuario);
    }
}