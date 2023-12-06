using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Specifications
{
    public class RequestByEtudiantsId : BaseSpecification<Etudiants>
    {
        public RequestByEtudiantsId(int edtudiantId) : base(x => x.Id == edtudiantId)
        {
        }
    }
}
