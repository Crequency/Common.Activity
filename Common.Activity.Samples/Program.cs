using System.Text.Json;
using Common.Activity;

Console.WriteLine("Common.Activity.Samples");

var activity = new Activity()
{
    Id = 1,
    Name = "Activity_Calculate",
    Author = "Samples",
    IconKind = null,
    Title = null,
    Category = null,
}
    .Open("samples")
    .Assign("samples", "samples")
    .Assign("samples", "computer")
    .RemoveAssign("samples", "samples")
    .Label("samples", "running")
    .AppendTask(
        new ActivityTask()
        {
            Action = controller =>
            {
                controller.Log($"1 + 0 = {1 + 0}");
                controller.Result = 1 + 0;
                controller.Progress = new Progress(ProgressType.Tasks)
                {
                    Value = new Tuple<int, int>(1, 1)
                };
            },
        }
            .AppendTask(
                new ActivityTask()
                {
                    Action = controller =>
                    {
                        controller.Log($"1 + 1 = {1 + 1}");
                        controller.Result = 1 + 1;
                        controller.Progress = new Progress(ProgressType.Tasks)
                        {
                            Value = new Tuple<int, int>(1, 1)
                        };
                    }
                }
            )
            .AppendTask(
                new ActivityTask()
                {
                    Action = controller =>
                    {
                        controller.Log($"1 + 2 = {1 + 2}");
                        controller.Result = 1 + 2;
                        controller.Progress = new Progress(ProgressType.Tasks)
                        {
                            Value = new Tuple<int, int>(1, 1)
                        };
                    }
                }
            )
    )
    .ExecuteAllTasks();

var options = new JsonSerializerOptions()
{
    WriteIndented = true,
    IncludeFields = true,
};

Console.WriteLine(JsonSerializer.Serialize(activity, options));
