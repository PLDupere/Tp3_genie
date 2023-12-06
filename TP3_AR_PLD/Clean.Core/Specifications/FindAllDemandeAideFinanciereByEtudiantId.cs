using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Specifications
{
    public class FindAllDemandeAideFinanciereByEtudiantId : BaseSpecification<DemandeAideFinancieres>
    {
        public FindAllDemandeAideFinanciereByEtudiantId(int edtudiantId) : base(x => x.EtudiantsId == edtudiantId)
        {
        }
    }
}
