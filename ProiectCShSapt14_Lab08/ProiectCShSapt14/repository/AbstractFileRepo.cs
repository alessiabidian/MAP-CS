using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    //folosim delegate pentru a converti entitatea din fisier in entitate
    public delegate E CreateEntity<E>(string line);

    public abstract class AbstractFileRepo<ID,E>:InMemoryRepository<ID,E> where E: Entity<ID>
    {
        protected string filename;
        protected CreateEntity<E> createEntity;

        public AbstractFileRepo(IValidator<E> vali,string filename, CreateEntity<E> createEntity):base(vali) { 
            this.filename = filename;
            this.createEntity = createEntity;
            if (this.createEntity != null)
            {
                loadfromfile();
            }
        }

        public virtual void loadfromfile()
        {
            List<E> list = DataReader.ReadData(filename, createEntity);
            list.ForEach(e => base.Save(e));
        }

    }
}