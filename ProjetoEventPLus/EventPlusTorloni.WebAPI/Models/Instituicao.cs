using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Instituicao")]
[Index("Cnpj", Name = "UQ__Institui__AA57D6B42F02C31F", IsUnique = true)]
public partial class Instituicao
{
    [Key]
    public Guid IdInstituicao { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NomeFantasia { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(14)]
    [Unicode(false)]
    public string Cnpj { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Endereco { get; set; } = null!;

    [InverseProperty("InstituicaoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
