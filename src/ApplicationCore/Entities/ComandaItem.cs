using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class ComandaItem
{
  public int Id { get; set; }

  [ForeignKey(nameof(Comanda))]
  public int IdComanda { get; set; }
  public int Sequencia { get; set; }
  public string Produto { get; set; }
  public double Preco { get; set; }
  public Comanda Comanda { get; set; }
}