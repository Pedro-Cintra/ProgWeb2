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

public class ComandaItemService : IComandaItemService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly IServiceManager _service;

    public ComandaItemService(IRepositoryManager repository, IMapper mapper, ILoggerManager logger, IServiceManager service)
    {
        _repository = repository;
        _mapper = mapper;
        _service = service;
    }

    public async Task<ReadComandaItemDto> CreateAsync(CreateComandaItemDto parameters)
    {
        
        CreateComandaDto createComandaDto = new()
        {
            IdUsuario = parameters.IdUsuario
        };
        ReadComandaDto comanda = await _service.Comanda.CreateAsync(createComandaDto);

        List<ComandaItem> comandaItem = [.. parameters.Produtos.Select(p => new ComandaItem
        {
            IdComanda = comanda.Id,
            Sequencia = p.Id,
            Produto = p.Nome,
            Preco = (double)p.Preco
        })];

        await _repository.ComandaItem.CreateRangeAsync(comandaItem);
        await _repository.SaveAsync();

        ReadComandaItemDto retorno = new()
        { 
            Id = comandaItem.First().Id,
            IdUsuario = parameters.IdUsuario,
            NomeUsuario = parameters.NomeUsuario,
            TelefoneUsuario = parameters.TelefoneUsuario,
            Produtos = [.. parameters.Produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            })]
        };

        return retorno;
    }
}
