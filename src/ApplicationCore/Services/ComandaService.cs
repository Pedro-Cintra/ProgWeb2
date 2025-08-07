using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Shared.Dtos.Comanda;
using Shared.Interfaces;

namespace ApplicationCore.Services;
public class ComandaService : IComandaService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ComandaService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<ReadComandaDto> CreateAsync(CreateComandaDto parameters)
    {
        Comanda comanda = _mapper.Map<Comanda>(parameters);

        await _repository.Comanda.CreateAsync(comanda);
        await _repository.SaveAsync();

        return _mapper.Map<ReadComandaDto>(comanda);
    }
}
