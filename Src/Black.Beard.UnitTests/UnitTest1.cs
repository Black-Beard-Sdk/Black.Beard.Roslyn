using Bb.Process;
using System.Data;
using System.Diagnostics;

namespace Black.Beard.UnitTests
{
    public class UnitTest1
    {
        private TaskEventEnum Current;
        private List<string?> _datas;


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

                var task = service.Wait(id);

            }

            Assert.Equal(id1, id2);

        }



        [Fact]
        public void TestInterceptor()
        {

            Guid id = Guid.NewGuid();
            this._datas = new List<string?>();

            using (LocalProcessCommandService service = new LocalProcessCommandService())
            {

                service.Run(c =>
                {
                    c.CommandWindowsBatch();
                    id = c.Id;
                    c.Intercept(log);
                });

                service.Wait();

                Assert.Equal(service.Current, Current);
                Assert.Equal(this._datas.Count, service.Datas.Count);
                for (int i = 0; i < _datas.Count; i++)
                    Assert.Equal(this._datas[i], service.Datas[i]);

                service.Cancel(id);

                Assert.Equal(service.Current, Current);
                Assert.Equal(this._datas.Count, service.Datas.Count);
                for (int i = 0; i < _datas.Count; i++)
                    Assert.Equal(this._datas[i], service.Datas[i]);

            }

        }

        private void log(object sender, TaskEventArgs args)
        {
            this.Current = args.Status;
            if (args.Status == TaskEventEnum.DataReceived)
                _datas.Add(args.DateReceived?.Data);
        }


    }


    public class LocalProcessCommandService : ProcessCommandService
    {

        public LocalProcessCommandService()
        {
            Intercept(log);
            this.Datas = new List<string?>();
        }

        public TaskEventEnum Current { get; private set; }
        public List<string?> Datas { get; }

        private void log(object sender, TaskEventArgs args)
        {            
            this.Current = args.Status;
            if (args.Status == TaskEventEnum.DataReceived)
                Datas.Add(args.DateReceived?.Data);
        }


    }


}