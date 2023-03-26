using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    class EchipaFileRepo : AbstractFileRepo<string, Echipa>
    {
        public EchipaFileRepo(IValidator<Echipa> vali,string filename) : base(vali, filename, FileToEntity.CreateEchipa)
        {
        }
    }
}