using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Specifications
{
    public class FindCalculVersementByDemandeAideFinanciereID : BaseSpecification<CalculVersements>
    {
        public FindCalculVersementByDemandeAideFinanciereID(int demandeAideFinanciereId) : base(x => x.Id == demandeAideFinanciereId)
        {
        }
    }
}
