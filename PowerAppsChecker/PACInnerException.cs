using System;

namespace Rappen.XTB.PAC
{
    internal class PACInnerException : Exception
    {
        public PACInnerException(string error) : base(error) { }
    }
}