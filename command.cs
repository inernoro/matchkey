using System;

namespace matchkey
{
    class command
    {

        public void Enter(string[] cmd)
        {

        }

        internal void run()
        {
            while (true)
            {
                Console.WriteLine("plase input your command:=> ");
                var con = Console.ReadLine();
                Execute(con);
            }
        }


        void Execute(string cmd)
        {
            var sp = cmd.Split('=');

        }
    }
}
