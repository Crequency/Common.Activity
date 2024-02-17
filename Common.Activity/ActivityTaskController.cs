namespace Common.Activity;

public class ActivityTaskController
{
    private ActivityTask? _task = null;

    private int index = 1;

    public ActivityTaskController SetTask(ActivityTask task)
    {
        _task = task;

        return this;
    }

    public ActivityTaskController Log(string content)
    {
        _task?.ActivityTaskResultLines.Add(new()
        {
            Index = index++,
            Content = content,
            Type = ActivityTaskResultLineType.Content,
        });

        return this;
    }

    public ActivityTaskController Warn(string content)
    {
        _task?.ActivityTaskResultLines.Add(new()
        {
            Index = index++,
            Content = content,
            Type = ActivityTaskResultLineType.Warning,
        });

        return this;
    }

    public ActivityTaskController Error(string content)
    {
        _task?.ActivityTaskResultLines.Add(new()
        {
            Index = index++,
            Content = content,
            Type = ActivityTaskResultLineType.Error,
        });

        return this;
    }

    public Progress? Progress
    {
        get => _task?.Progress;
        set => _task!.Progress = value;
    }

    public dynamic? Result
    {
        get => _task?.Result;
        set => _task!.Result = value;
    }
}
