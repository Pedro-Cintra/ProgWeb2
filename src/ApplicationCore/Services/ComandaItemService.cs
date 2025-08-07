using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Shared.Dtos.ComandaItem;
using Shared.Interfaces;

namespace ApplicationCore.Services;

public class ComandaItemService : IComandaItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public ComandaItemService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<ReadComandaItemDto> CreateAsync(CreateComandaItemDto parameters)
    {
        ComandaItem comandaItem = _mapper.Map<ComandaItem>(parameters);

        await _repository.ComandaItem.CreateAsync(comandaItem);
        await _repository.SaveAsync();

        return _mapper.Map<ReadComandaItemDto>(comandaItem);
    }
}
