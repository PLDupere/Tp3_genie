using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Specifications
{
    public class FindEtudiantByCodePermanent : BaseSpecification<Etudiants>
    {
        public FindEtudiantByCodePermanent(string codePermanent) : base(x => x.CodePermanent == codePermanent)
        {
        }
    }
}
