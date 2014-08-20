using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskIT.Delegates
{
   public delegate void AddDelegate(int JobID, string Description, DateTime DateSubmitted, string POC, int Priority, bool IsCompleted);
}
