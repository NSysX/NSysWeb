namespace Application.DTOs
{
    public class DocumentoDTO
    {
        public int IdDocumento { get; set; }
        public string Estatus { get; set; }
        public string CodigoUnico { get; set; }
        public int IdDocumentoTipo { get; set; }

        public DocumentoTipoDTO DocumentoTipo { get; set; }
    }
}
