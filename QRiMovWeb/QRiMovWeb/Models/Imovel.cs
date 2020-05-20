using System.ComponentModel.DataAnnotations;

namespace QRiMovWeb.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        [StringLength(20)]
        public string CEP { get; set; }
        [StringLength(255)]
        public string Logradouro { get; set; }
        [StringLength(30)]
        public string Numero { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        [StringLength(50)]
        public string Bairro { get; set; }
        [StringLength(2)]
        public string UF { get; set; }
        [StringLength(200)]
        public string Comarca { get; set; }
        [StringLength(255)]
        public string ImgMiniaturaUrl { get; set; }
        [StringLength(255)]
        public string ImgUrl { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsDestaque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
