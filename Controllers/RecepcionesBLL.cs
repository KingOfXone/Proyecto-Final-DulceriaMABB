using DulceriaMABB.DAL;
using DulceriaMABB.Shared;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DulceriaMABB.Controllers
{
    public class RecepcionesBLL(Contexto Contexto)
    {
        private readonly Contexto _Contexto = Contexto;

        public bool Existe(int RecepcionId)
        {
            return _Contexto.Recepciones.Any(o => o.RecepcionId == RecepcionId);
        }
        private bool Insertar(Recepciones recepcion)
        {

            var producto = _Contexto.Productos.AsNoTracking().FirstOrDefault(o => o.ProductoId == recepcion.ProductoId);
            if (producto != null)
            {
                producto.Cantidad += recepcion.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
                _Contexto.SaveChanges();
                _Contexto.Entry(producto).State = EntityState.Detached;
            }
            _Contexto.Recepciones.Add(recepcion);
            bool save = _Contexto.SaveChanges() > 0;
            _Contexto.Entry(recepcion).State = EntityState.Detached;
            return save;
        }

        private bool Modificar(Recepciones recepcion)
        {
            var encontrado = _Contexto.Recepciones.AsNoTracking().FirstOrDefault(o => o.RecepcionId == recepcion.RecepcionId);
            if (encontrado != null)
            {
                var producto = _Contexto.Productos.Find(recepcion.ProductoId);
                if (producto != null)
                {
                    producto.Cantidad -= encontrado.Cantidad;
                    producto.Cantidad += recepcion.Cantidad;
                    _Contexto.Entry(producto).State = EntityState.Modified;
                    _Contexto.SaveChanges();
                    _Contexto.Entry(producto).State = EntityState.Detached;
                }
            }

            _Contexto.Entry(recepcion).State = EntityState.Modified;
            bool save = _Contexto.SaveChanges() > 0;
            _Contexto.Entry(recepcion).State = EntityState.Detached;
            return save;
        }


        public bool Guardar(Recepciones recepcion)
        {
            if (!Existe(recepcion.RecepcionId))
            {
                return this.Insertar(recepcion);
            }
            else
            {
                return this.Modificar(recepcion);
            }
        }

        public bool Eliminar(Recepciones recepcion)
        {
            var producto = _Contexto.Productos.AsNoTracking().FirstOrDefault(o => o.ProductoId == recepcion.ProductoId);
            if (producto != null)
            {
                producto.Cantidad -= recepcion.Cantidad;
                _Contexto.Entry(producto).State = EntityState.Modified;
                _Contexto.SaveChanges();
                _Contexto.Entry(producto).State = EntityState.Detached;
            }

            _Contexto.Entry(recepcion).State = EntityState.Deleted;
            bool save = _Contexto.SaveChanges() > 0;
            _Contexto.Entry(recepcion).State = EntityState.Detached;
            return save;
        }

        public Recepciones? Buscar(int RecepcionId)
        {
            return _Contexto.Recepciones.AsNoTracking().FirstOrDefault(o => o.RecepcionId == RecepcionId);
        }

        public List<Recepciones> GetList(Expression<Func<Recepciones, bool>> criterio)
        {
            return _Contexto.Recepciones.AsNoTracking().Where(criterio).ToList();
        }


    }
}