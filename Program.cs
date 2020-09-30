using Neo.IronLua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace matchkey
{
    class Program
    {
        /// <summary>
        /// fileter=test1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("F:\\project\\matchkey\\property.lua");
            var ProgramSource = reader.ReadToEnd();
            reader.Close();

            using (var lua = new Lua())
            {
                LuaGlobal env = lua.CreateEnvironment();
                //env.DoChunk(ProgramSource, "property.lua");

                //var cc = env.DoChunk("F:\\project\\matchkey\\property.lua");
                var ll = new KeyValuePair<string, Type>();
                lua.CompileChunk("F:\\project\\matchkey\\property.lua", new LuaCompileOptions(), ll);
                //    string cc = env.env.input.conn;
                Console.ReadKey();
            }

        }
    }
}
