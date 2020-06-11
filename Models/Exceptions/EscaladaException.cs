using System;

namespace Escalada.Models.Exceptions
{
    public class EscaladaException : Exception
    {
        public EscaladaException(string message) : base(message)
        {
        }
    }
}