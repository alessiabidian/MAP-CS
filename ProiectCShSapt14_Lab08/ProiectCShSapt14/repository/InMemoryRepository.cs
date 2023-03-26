using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IDictionary<ID, E> entities= new Dictionary<ID,E>();
        protected IValidator<E> vali;
   
        public InMemoryRepository(IValidator<E> vali)
        {
            this.vali= vali;
        }

        public E Delete(ID id)
        {
            if (id == null) throw new ArgumentNullException("Entity cannot be null!");
            if (entities.ContainsKey(id))
            {
                Entity<ID> entity = entities[id];
                entities.Remove(id);
                return (E)entity;
            }
          
            return null;
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values.ToList();
        }

        public E FindOne(ID id)
        {
            Entity<ID> found = (Entity<ID>)entities.Where(p => p.Key.Equals(id)).Select(p => p.Value).FirstOrDefault();
            return (E)found;
        }

        public E Save(E entity)
        {
            if (entity == null) throw new ArgumentNullException("Entity cannot be null!");
            vali.validate(entity);
            if (entities.ContainsKey(entity.ID))
            {
                return entity;
            }
            else entities[entity.ID] = entity;
            return entity;
        }

        public E Update(E entity)
        {
            if (entity == null) throw new ArgumentNullException("Entity cannot be null!");
            if (entities.ContainsKey(entity.ID))
            {
                entities[entity.ID] = entity;   
            }
            return entity;
        }
    }
}