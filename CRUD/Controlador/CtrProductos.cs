using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using CRUD.Modelo;

namespace CRUD.Controlador
{
    public class CtrProductos
    {
        private CrudEntities entitiesDB = new CrudEntities();


        public void Insert(TB_PRODUCTOS _PRODUCTOS) {
            entitiesDB.TB_PRODUCTOS.Add(_PRODUCTOS);
            entitiesDB.SaveChanges();
        }

        public void Update(TB_PRODUCTOS _PRODUCTOS) {
            TB_PRODUCTOS ProductosDb = entitiesDB.TB_PRODUCTOS.Find(_PRODUCTOS.codigo_pr);

            entitiesDB.Entry(ProductosDb).CurrentValues.SetValues(_PRODUCTOS);
            entitiesDB.SaveChanges();
        }

        public void Delete(int codigo_pr) {
            TB_PRODUCTOS ProductosDb = entitiesDB.TB_PRODUCTOS.Find(codigo_pr);

            entitiesDB.Entry(ProductosDb).State = EntityState.Deleted;
            entitiesDB.SaveChanges();
        }

        public TB_PRODUCTOS FindByID(int codigo_pr) {
            TB_PRODUCTOS ProductosDb = entitiesDB.TB_PRODUCTOS.Find(codigo_pr);
            return ProductosDb;
        }

        public List<TB_PRODUCTOS> FindAll() {
            var query = from productos in entitiesDB.TB_PRODUCTOS
                        select productos;
            return query.ToList();
        }

    }
}
