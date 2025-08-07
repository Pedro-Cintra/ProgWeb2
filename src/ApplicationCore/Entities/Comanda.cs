
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;
public class Comanda
{
    public int Id { get; set; }
    [ForeignKey(nameof(Usuario))]
    public int IdUsuario { get; set; }
}
