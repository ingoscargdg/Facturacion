
namespace Libraries.SAT.CFDI
{
    public class Impuestos
    {
        private Trasladados trasladados;

        private Retenidos retenidos;

        public void AddTrasladados(Trasladados trasladados)
        {
            this.trasladados = trasladados;
        }

        public void AddRetenidos(Retenidos retenidos)
        {
            this.retenidos= retenidos;
        }


    }
}
