using System;

namespace Proyecto_Arkanoid
{
    public class ExistingNicknameException: Exception
    {
        public ExistingNicknameException(string message) : base(message)
        {
        }
    }
}