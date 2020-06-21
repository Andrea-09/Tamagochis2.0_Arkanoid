using System;

namespace Proyecto_Arkanoid
{
    public class EmptyNicknameException : Exception
    {
        public EmptyNicknameException(string message) : base(message)
        {
        }
    }
}