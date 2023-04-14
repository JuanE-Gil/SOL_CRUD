using System.Collections.Generic;
using System.Linq;

using CRUD.Modelo;

namespace CRUD.Controlador
{
    public class CtrMedidas
    {
        private CrudEntities entitiesDB = new CrudEntities();

        public List<TB_MEDIDAS> FindAll() {
            var query = from medidas in entitiesDB.TB_MEDIDAS
                        select medidas;
            return query.ToList();
        }
    }
}
