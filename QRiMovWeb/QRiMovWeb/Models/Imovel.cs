namespace QRiMovWeb.Models
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Comarca { get; set; }
        public string ImgMiniaturaUrl { get; set; }
        public string ImgUrl { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsDestaque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
