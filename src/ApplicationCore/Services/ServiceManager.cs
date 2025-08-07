using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;
using Shared.Interfaces;
using Shared.Models;

namespace ApplicationCore.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IComandaService> _comandaService;
    private readonly Lazy<IComandaItemService> _comandaItemService;
    private readonly Lazy<IUsuarioService> _usuarioService;

    public ServiceManager(IRepositoryManager repositoryManager
                        , ILoggerManager logger
                        , IMapper mapper
                        , IOptions<JwtConfiguration> jwtConfiguration
    )
    {
        _comandaService = new(() => new ComandaService(repositoryManager, mapper, logger));
        _comandaItemService = new(() => new ComandaItemService(repositoryManager, mapper, logger));
        _usuarioService = new(() => new UsuarioService(repositoryManager, mapper, logger));
    }

    public IComandaService Comanda => _comandaService.Value;
    public IComandaItemService ComandaItem => _comandaItemService.Value;
    public IUsuarioService Usuario => _usuarioService.Value;
}

