using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerCore.Commands
{
    public interface Command
    {
        public string CommandText { get; }

        public void ConvertToAsm();
    }
}
