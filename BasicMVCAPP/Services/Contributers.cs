using BasicMVCAPP.Models;

namespace BasicMVCAPP.Services
{
    public class Contributers
    {
        private static List<Contributer> contributer_list =  new List<Contributer>();

        static Contributers()
        {
            contributer_list =new List<Contributer>{
                new Contributer{name="Arpit", designation="Software Developer" },
                new Contributer{name="Jay", designation="Software Developer" },
                new Contributer{name="Aryan", designation="Software Engineer" }

            };
        }

        public Contributers()
        {

        }
        public IEnumerable<Contributer> GetAll()
        {
            return contributer_list.AsEnumerable();
        }
    }
     
}
