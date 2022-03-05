using Domain.Interfaces.Generics;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Repositorio.Genericos
{
    public class RepositorioGenerico<T> : InterfaceGeneric<T>, IDisposable where T : class
    {

        private readonly DbContextOptions<Contexto> _OptionsBuilder;

        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<Contexto>();
        }

        public void Add(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Add(Objeto);
                banco.SaveChanges();
            }
        }

        public void Delete(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Remove(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public T GetEntityById(int Id)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return banco.Set<T>().Find(Id);
            }
        }

        public List<T> List()
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                return banco.Set<T>().AsNoTracking().ToList();

            }
        }

        public void Update(T Objeto)
        {
            using (var banco = new Contexto(_OptionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
