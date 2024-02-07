using System.Text.Json.Serialization;

namespace Common.Activity;

public class ActivityTask
{
    public ActivityTask()
    {
        _controller.SetTask(this);
    }

    private readonly ActivityTaskController _controller = new();

    public string? Name { get; set; }

    public Progress? Progress { get; set; }

    public bool IsLoopTask { get; set; } = false;

    [JsonIgnore] public Action<ActivityTaskController>? Action { get; set; }

    public List<ActivityTask> SubTasks { get; } = new();

    [JsonIgnore] public ActivityTask? ParentTask { get; internal set; }

    public Dictionary<int, string> Contents { get; } = new();

    public Dictionary<int, string> Warnings { get; } = new();

    public Dictionary<int, string> Errors { get; } = new();

    public ActivityTaskStatus? Status { get; private set; }

    public dynamic? Result { get; set; }

    [JsonIgnore] public Exception? Exception { get; private set; }

    public ActivityTask AppendTask(ActivityTask task)
    {
        SubTasks.Add(task);
        task.ParentTask = this;

        return this;
    }

    public ActivityTask Execute(bool executeSubTasks = true)
    {
        try
        {
            Action?.Invoke(_controller);

            Status = ActivityTaskStatus.Success;
        }
        catch (Exception e)
        {
            Exception = e;

            Status = ActivityTaskStatus.Errored;
        }

        if (!executeSubTasks) return this;

        foreach (var task in SubTasks)
            task.Execute(executeSubTasks);

        return this;
    }
}
