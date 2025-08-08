namespace ApplicationCore.Exceptions;

public sealed class ComandaNotFoundException(int id) : NotFoundException($"A comanda com o id '{id}', não existe no banco de dados.")
{
}