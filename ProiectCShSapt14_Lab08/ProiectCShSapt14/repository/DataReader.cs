using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    public class DataReader
    {
        public static List<T> ReadData<T>(string filename, CreateEntity<T> createEntity)
        {
            List<T> entitiesList = new List<T>();
            using (StreamReader sr= new StreamReader(filename))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    T entity = createEntity(s);
                    entitiesList.Add(entity);
                }
            }
            return entitiesList;
        }
    }
}
