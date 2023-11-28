using DulceriaMABB.DAL;
using DulceriaMABB.Shared;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DulceriaMABB.Controllers
{
    public class ProductosBLL(Contexto Contexto)
    {
        private readonly Contexto _Contexto = Contexto;

        public bool Existe(int ProductoId)
        {
            return _Contexto.Productos.Any(o => o.ProductoId == ProductoId);
        }

        private bool Insertar(Productos producto)
        {
            _Contexto.Productos.Add(producto);
            bool save = _Contexto.SaveChanges() > 0;
            _Contexto.Entry(producto).State = EntityState.Detached;
            return save;
        }

        private bool Modificar(Productos producto)
        {
            _Contexto.Entry(producto).State = EntityState.Modified;
            bool save = _Contexto.SaveChanges() > 0;
            _Contexto.Entry(producto).State = EntityState.Detached;
            return save;
        }

        public bool Guardar(Productos producto)
        {
            if (!Existe(producto.ProductoId))
            {
                return this.Insertar(producto);
            }
            else
            {
                return this.Modificar(producto);
            }
        }

        public bool Eliminar(Productos producto)
        {
            _Contexto.Entry(producto).State = EntityState.Deleted;
            bool save = _Contexto.SaveChanges() > 0;
            _Contexto.Entry(producto).State = EntityState.Detached;
            return save;
        }

        public Productos? Buscar(int ProductoId)
        {
            return _Contexto.Productos.AsNoTracking().FirstOrDefault(o => o.ProductoId == ProductoId);
        }

        public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            return _Contexto.Productos.AsNoTracking().Where(criterio).ToList();
        }
    }
}