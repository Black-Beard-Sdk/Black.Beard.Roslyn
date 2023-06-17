//using Bb.Process;
//using System.Diagnostics;

//namespace Black.Beard.UnitTests
//{
//    public class UnitTest1
//    {


//        [Fact]
//        public void TestRun1()
//        {

//            using (var cmd = new ProcessCommand()
//                     .CommandBatch()
//                     .Intercept((c, d) =>
//                     {
//                         Trace.WriteLine(d.DateReceived.Datas);
//                     })
//                     .Run())

//            {
//                cmd
//                    .Wait("(c) Microsoft Corporation. Tous droits réservés.")
                   
//                    .WriteInput("cls")
//                    .WaitPrompt()
                   
//                    .WriteInput("dir")
//                    .WaitPrompt()
                   
//                    .WriteInput("Exit")
//                    .WaitPrompt()
                   
//                   ;

//            }

//        }



//        [Fact]
//        public void TestRun2()
//        {

//            using (ProcessCommandService service = new ProcessCommandService())
//            {

//                Guid id = Guid.NewGuid();
//                service.Run(c =>
//                {
//                    c.CommandBatch();
//                    id = c.Id;
//                });

//                var task = service.GetTask(id);
//                Assert.NotNull(task);

//                service.Cancel(id);

//                task = service.GetTask(id);
//                Assert.Null(task);

//            }

//        }

//        [Fact]
//        public void TestLog()
//        {

//            Guid id = Guid.NewGuid();
//            Guid id1 = Guid.NewGuid();
//            Guid id2 = Guid.NewGuid();

//            using (ProcessCommandService service = new ProcessCommandService())
//            {

//                service.Output(c =>
//                {
//                    id1 = c.Command.Id;
//                });

//                service.Output(c =>
//                {
//                    id2 = c.Command.Id;
//                });

//                service.Run(c =>
//                {
//                    c.CommandBatch();
//                    id = c.Id;
//                });

//                var task = service.GetTask(id);
//                task.Wait(2000);

//            }

//            Assert.Equal(id1, id2);

//        }

//    }
//}