using System;

namespace hIoc
{
    public class TypeNotRecognisedException : Exception
    {
        public TypeNotRecognisedException(string message)
            : base(message)
        {
        }
    }
}