using System.Collections.ObjectModel;
using System.Text;
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

    public ObservableCollection<ActivityTask> SubTasks { get; } = new();

    [JsonIgnore] public ActivityTask? ParentTask { get; internal set; }

    public ObservableCollection<ActivityTaskResultLine> ActivityTaskResultLines { get; } = new();

    public string ActivityTaskResult
    {
        get
        {
            var sb = new StringBuilder();

            ActivityTaskResultLines.Select(x => x.Content)
                .ToList()
                .ForEach(x => sb.AppendLine(x));

            return sb.ToString();
        }
    }

    public ActivityTaskStatus? Status { get; private set; } = ActivityTaskStatus.Pending;

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
            Status = ActivityTaskStatus.Running;

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
