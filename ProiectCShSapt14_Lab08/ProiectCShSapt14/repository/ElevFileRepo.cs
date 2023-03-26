using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    class ElevFileRepo : AbstractFileRepo<string, Elev>
    {
        public ElevFileRepo(IValidator<Elev> vali, string filename) : base(vali, filename, FileToEntity.CreateElev)
        {
        }
    }
}