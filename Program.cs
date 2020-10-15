using Neo.IronLua;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace matchkey
{
    class Program
    {
        //占用时长分两步分，一个是编译时间与运行时间

        /// <summary>
        /// fileter=test1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + "/test.lua");
            var code = reader.ReadToEnd();
            reader.Close();


            while (true)
            {
                Console.Write("number=> ");
                var count = Convert.ToInt32(Console.ReadLine());

                //3
                innerTemploadfile(code, count);
                //4
                comexec(code, count);
                //5
                parallel(code, count);
            }
        }


        private static void innerTemploadfile(string code, int count)
        {
            var watch = new Stopwatch();
            watch.Start();

            using (var lua = new Lua())
            {
                for (int i = 0; i < count; i++)
                {
                    LuaGlobal env = lua.CreateEnvironment();
                    LuaResult cc = env.DoChunk(code, "test.lua");
                    dynamic en = env;
                    string data = en.exec(1);
                }
            }

            watch.Stop();
            Console.WriteLine("time=>{0}", watch.ElapsedMilliseconds);
        }

        public static void comexec(string code, int count)
        {
            var watch = new Stopwatch();
            watch.Start();

            var lua = new Lua();
            LuaGlobal env = lua.CreateEnvironment();
            LuaResult cc = env.DoChunk(code, "test.lua");
            dynamic en = env;

            for (int i = 0; i < count; i++)
            {
                string data = en.exec(10);
            }

            watch.Stop();
            Console.WriteLine("time=>{0}", watch.ElapsedMilliseconds);
        }

        public static void parallel(string code, int count)
        {
            var watch = new Stopwatch();
            watch.Start();

            var lua = new Lua();
            LuaGlobal env = lua.CreateEnvironment();
            LuaResult cc = env.DoChunk(code, "test.lua");
            dynamic en = env;

            Parallel.For(0, count, x =>
            {
                string data = en.exec(10);
            });

            watch.Stop();
            Console.WriteLine("time=>{0}", watch.ElapsedMilliseconds);
        }

    }
}
