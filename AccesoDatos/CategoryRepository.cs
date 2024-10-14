using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CategoryRepository
    {
        public NorthwindEntities contexto = new NorthwindEntities();

        public List<Categories> Obtener()
        {
            var categoria = from cat in contexto.Categories select cat;
            return categoria.ToList();
        }

        public Categories ObtenerPorID(int id)
        {
            var categoria = from cat in contexto.Categories where cat.CategoryID == id select cat;
            return categoria.FirstOrDefault();
        }

        public int InsertarCategoria(Categories categories)
        {
            contexto.Categories.Add(categories);
            return contexto.SaveChanges();
        }
    }
}
