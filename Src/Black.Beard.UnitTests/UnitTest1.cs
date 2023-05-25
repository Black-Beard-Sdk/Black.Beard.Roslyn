using Bb.Process;
using System.Diagnostics;

namespace Black.Beard.UnitTests
{
    public class UnitTest1
    {


        [Fact]
        public void Test1()
        {

            using (var cmd = new ProcessCommand()
                     .CommandBatch()
                     .Output(c =>
                     {
                         Trace.WriteLine(c.Datas);
                     })
                     .Run())

            {
                cmd
                    .Wait("(c) Microsoft Corporation. Tous droits réservés.")
                   
                    .WriteInput("cls")
                    .WaitPrompt()
                   
                    .WriteInput("dir")
                    .WaitPrompt()
                   
                    .WriteInput("Exit")
                    .WaitPrompt()
                   
                   ;

            }

        }

    }
}