using System;

namespace ConsoleApp9
{
    abstract class BaseState {
        public abstract void Work();
    }
    class Eat : BaseState
    {
        public override void Work() { Console.WriteLine("Eat"); }
    }
    class Sleep : BaseState
    {
        public override void Work() { Console.WriteLine("Sleep"); }
    }
    class Code : BaseState
    {
        public override void Work() { Console.WriteLine("Code"); }
    }
    class Human
    {
        BaseState state;
        public virtual void Start()
        {
            this.State.Work();
        }
        public virtual BaseState State
        {
            set
            {
                if (value is Code) throw new NotSupportedException();
                state = value;
            }
            get => state;
        }
    }
    class Coder : Human
    {
        public override BaseState State { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Coder coder = new Coder();
            while (true)
            {
                coder.State = new Eat();
                coder.Start();
                coder.State = new Sleep();
                coder.Start();
                coder.State = new Code();
                coder.Start();
            }
           
        }
    }
}
