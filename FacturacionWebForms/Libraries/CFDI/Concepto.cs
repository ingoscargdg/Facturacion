namespace Libraries.CFDI
{
    class Concepto
    {
        public decimal Cantidad { get; set; }
        
        public string Unidad { get; set; }

        public string NoIdentificacion { get; set; }

        public string Descripcion { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal Importe()
        {
            return this.ValorUnitario * this.Cantidad;
        }
    }
}
