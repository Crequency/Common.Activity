namespace Common.Activity;

public class ActivityTaskController
{
    private ActivityTask? _task = null;

    public ActivityTaskController SetTask(ActivityTask task)
    {
        _task = task;

        return this;
    }

    public ActivityTaskController LogContents(int index, string content)
    {
        _task?.Contents.Add(index, content);

        return this;
    }

    public ActivityTaskController LogWarnings(int index, string content)
    {
        _task?.Warnings.Add(index, content);

        return this;
    }

    public ActivityTaskController LogErrors(int index, string content)
    {
        _task?.Errors.Add(index, content);

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