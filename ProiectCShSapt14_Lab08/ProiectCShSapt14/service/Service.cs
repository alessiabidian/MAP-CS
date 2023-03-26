using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using ProiectCShSapt14.repository;

namespace ProiectCShSapt14.service
{

    public class Service
    {
        private IRepository<string, Echipa> echipaRepo;
        private IRepository<string, JucatorActiv> jucatorActivRepo;
        private IRepository<string, Jucator> jucatorRepo;
        private IRepository<string, Meci> meciRepo;

        public Service(IRepository<string, Echipa> echipaRepo, IRepository<string, JucatorActiv> jucatorActivRepo, IRepository<string, Jucator> jucatorRepo, IRepository<string, Meci> meciRepo)
        {
            this.echipaRepo = echipaRepo;
            this.jucatorActivRepo = jucatorActivRepo;
            this.jucatorRepo = jucatorRepo;
            this.meciRepo = meciRepo;
        }
        
        public List<Echipa> findAllEchipe()
        {
            return echipaRepo.FindAll().ToList();
        }
        
        public List<JucatorActiv> findAllJucatoriActivi()
        {
            return jucatorActivRepo.FindAll().ToList();
        }
        
        public List<Jucator> findAllJucatori()
        {
            return jucatorRepo.FindAll().ToList();
        }
        
        public List<Meci> findAllMeci()
        {
            return meciRepo.FindAll().ToList();
        }

        public List<Jucator> filterJucatoriLaEchipa(string numeEchipa)
        {
            List<Jucator> laEchipa = findAllJucatori().Where(j => j.GetEchipa().Nume.Equals(numeEchipa)).ToList();
            if (laEchipa.Count() == 0)
            {
                throw new ValidationException("Nu exista echipa cu numele dat!");
            }

            return laEchipa;
        }

        public Meci findMeci(string idMeci)
        {
            Meci gasit = findAllMeci().Find(p => p.ID.Equals(idMeci));
            return gasit;
        }
        
        public List<JucatorActiv> filterJucatoriActiviLaMeci(string idMeci)
        {
            List<JucatorActiv> laMeci = findAllJucatoriActivi().Where(j => j.IdMeci.Equals(idMeci)).ToList();

            return laMeci;
        }

        public List<JucatorActiv> filterJucatoriActivi_MeciEchipa(string idMeci, string numeEchipa)
        {
            //jucatorii activi de la meciul dat
            List<JucatorActiv> laMeci = filterJucatoriActiviLaMeci(idMeci);
            
            //jucatorii activi de la meciul dat care joaca pentru echipa data
            List<JucatorActiv> final = laMeci.Where(j =>
            {
                return findAllJucatori().Exists(l => l.ID.Equals(j.IdJucator) && l.GetEchipa().Nume.Equals(numeEchipa));
            }).ToList();

            return final;
        }

        public List<Meci> filterMeciPerioada(DateTime dataInceput, DateTime dataSfarsit)
        {
            if (dataSfarsit < dataInceput) 
                throw new ValidationException("Data de inceput nu poate fi mai mare decat cea de sfarsit!");
            List<Meci> rez = findAllMeci().Where(m => m.Data >= dataInceput && m.Data <= dataSfarsit).ToList();

            return rez;
        }
    }
}