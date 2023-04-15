using System;

namespace CRUD.Modelo
{
    public class ProductosMapper
    {
        public ProductosMapper() {
        }

        public ProductosMapper(int codigo_pr, string descripcion_pr, string marca_pr, string codigo_ca, string codigo_me, decimal stock_actual, DateTime fecha_crea) {
            this.codigo_pr = codigo_pr;
            this.descripcion_pr = descripcion_pr;
            this.marca_pr = marca_pr;
            this.codigo_ca = codigo_ca;
            this.codigo_me = codigo_me;
            this.stock_actual = stock_actual;
            this.fecha_crea = fecha_crea;
        }

        public int codigo_pr { get; set; }
        public string descripcion_pr { get; set; }
        public string marca_pr { get; set; }
        public string codigo_ca { get; set; }
        public string codigo_me { get; set; }
        public decimal stock_actual { get; set; }
        public System.DateTime fecha_crea { get; set; }
    }
}
