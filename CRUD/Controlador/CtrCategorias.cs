using System.Collections.Generic;
using System.Linq;

using CRUD.Modelo;

namespace CRUD.Controlador
{
    public class CtrCategorias
    {
        private CrudEntities entitiesDB = new CrudEntities();

        public List<TB_CATEGORIAS> FindAll() {
            var query = from categoria in entitiesDB.TB_CATEGORIAS
                        select categoria;
            return query.ToList();
        }
    }
}
