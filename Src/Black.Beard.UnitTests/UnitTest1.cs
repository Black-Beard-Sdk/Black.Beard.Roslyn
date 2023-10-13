using Bb.Process;
using System.Diagnostics;

namespace Black.Beard.UnitTests
{
    public class UnitTest1
    {


        // build "c:\tmp\parrot\projects\parcel\mock\service\mock.csproj" -c release /p:Version=1.0.0.0

        [Fact]
        public void TestFailedToStart()
        {
            List<TaskEventEnum> results = new List<TaskEventEnum>();
            using (var cmd = new ProcessCommand()
                     .Command("cmd1.exe")
                     .Intercept((c, d) =>
                     {
                         results.Add(d.Status);
                     })
                     .Run())

            {

                cmd
                    .Wait(30000);
            }

            Assert.Equal(results[0], TaskEventEnum.FailedToStart);
            Assert.Equal(results[1], TaskEventEnum.Releasing);
            Assert.Equal(results[2], TaskEventEnum.Disposing);

        }

        [Fact]
        public void TestRun1()
        {

            List<TaskEventEnum> results = new List<TaskEventEnum>();

            using (var cmd = new ProcessCommand()
                     .Command("cmd.exe")
                     .Intercept((c, d) =>
                     {

                         results.Add(d.Status);

                     })
                     .Run())

            {

                cmd
                    .Wait(5000);

            }

            Assert.Equal(results[0], TaskEventEnum.Started);
            Assert.Equal(results[1], TaskEventEnum.DataReceived);
            Assert.Equal(results[2], TaskEventEnum.DataReceived);
            Assert.Equal(results[3], TaskEventEnum.DataReceived);
            Assert.Equal(results[4], TaskEventEnum.Completed);
            Assert.Equal(results[5], TaskEventEnum.Releasing);
            Assert.Equal(results[6], TaskEventEnum.Disposing);

        }

        [Fact]
        public void TestRun2()
        {

            using (ProcessCommandService service = new ProcessCommandService())
            {

                Guid id = Guid.NewGuid();
                service.Run(c =>
                {
                    c.CommandWindowsBatch();
                    id = c.Id;
                });

                service.Wait(id, 1000);

                var task = service.GetTask(id);
                Assert.NotNull(task);

                service.Cancel(id);

                Assert.True(task.Canceled);

            }

        }

        [Fact]
        public void TestLog()
        {

            Guid id = Guid.NewGuid();
            Guid id1 = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();

            using (ProcessCommandService service = new ProcessCommandService())
            {


                service.Intercept((c, d) =>
                {
                    id1 = d.Process.Id;
                });

                service.Intercept((c, d) =>
                {
                    id2 = d.Process.Id;
                });

                service.Run(c =>
                {
                    c.CommandWindowsBatch();
                    id = c.Id;
                });

                var task = service.GetTask(id);
                task.Wait(2000);

            }

            Assert.Equal(id1, id2);

        }

    }
}