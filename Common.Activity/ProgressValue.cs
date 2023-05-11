namespace Common.Activity;

public class ProgressValue
{
    private Tuple<int, int>? _tasksValue = null;

    public Tuple<int, int> TasksValue
    {
        get => _tasksValue ?? throw new NullReferenceException("_tasksValue is null");
        set => _tasksValue = value;
    }

    private double? _percentValue = null;

    public double PercentValue
    {
        get => _percentValue ?? throw new NullReferenceException("_percentValue is null");
        set => _percentValue = value;
    }

    private bool? _waiting = null;

    public bool IsWaiting
    {
        get => _waiting ?? throw new NullReferenceException("_waiting is null");
        set => _waiting = value;
    }
}
