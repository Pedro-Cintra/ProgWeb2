using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos.Comanda;
using Shared.Dtos.ComandaItem;
using Shared.Dtos.Produto;
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

    public async Task<IEnumerable<ReadComandaDto>> GetAllAsync()
    {
        var comandas = await _repository.Comanda
            .FindAll(false)
            .Include(c => c.Usuario)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ReadComandaDto>>(comandas);
    }

    private async Task<Comanda> GetAndCheckAsync(int id, bool trackChanges = false)
    {
        var comanda = await _repository.Comanda
            .FindByCondition(c => c.Id == id, trackChanges)
            .SingleOrDefaultAsync() ?? throw new ComandaNotFoundException(id);

        return comanda;
    }
    
    public async Task<ReadComandaItemDto> GetAsync(int id)
    {
        var comanda = await _repository.Comanda
            .FindByCondition(c => c.Id == id, false)
            .Include(c => c.Usuario)
            .Include(c => c.ComandaItems)
            .SingleOrDefaultAsync() ?? throw new ComandaNotFoundException(id);

        ReadComandaItemDto retorno = new()
        { 
            Id = comanda.Id,
            IdUsuario = comanda.IdUsuario,
            NomeUsuario = comanda.Usuario.Nome,
            TelefoneUsuario = comanda.Usuario.Telefone,
            Produtos = [.. comanda.ComandaItems.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Produto,
                Preco = (decimal)p.Preco
            })]
        };

        return retorno;
    }
}
