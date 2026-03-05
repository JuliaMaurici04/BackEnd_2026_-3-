using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Models;

[Table("Evento")]
public partial class Evento
{
    [Key]
    public Guid IdEvento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataEvento { get; set; }

    [Column(TypeName = "text")]
    public string Descricao { get; set; } = null!;

    public Guid? IdTipoEvento { get; set; }

    public Guid? Instituicao { get; set; }

    [InverseProperty("IdEventoNavigation")]
    public virtual ICollection<ComentarioEvento> ComentarioEventos { get; set; } = new List<ComentarioEvento>();

    [ForeignKey("IdTipoEvento")]
    [InverseProperty("Eventos")]
    public virtual TipoEvento? IdTipoEventoNavigation { get; set; }

    [ForeignKey("Instituicao")]
    [InverseProperty("Eventos")]
    public virtual Instituicao? InstituicaoNavigation { get; set; }

    [InverseProperty("IdEventoNavigation")]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}
