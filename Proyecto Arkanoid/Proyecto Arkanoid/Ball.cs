namespace Proyecto_Arkanoid
{
    public class Ball
    {
        protected int speedUp;
        protected int speedDown;

        public Ball(int speedUp, int speedDown)
        {
            this.speedUp = speedUp;
            this.speedDown = speedDown;
        }

        public int SpeedUp
        {
            get => speedUp;
            set => speedUp = value;
        }

        public int SpeedDown
        {
            get => speedDown;
            set => speedDown = value;
        }

        public void Move()
        {
            
        }
    }
}