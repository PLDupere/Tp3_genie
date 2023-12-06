using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Interfaces
{
    public interface IBackEndSystemService
    {
        //Question ???
        Task SendRequestToBackEnd(Request request, string directory);
    }
}
