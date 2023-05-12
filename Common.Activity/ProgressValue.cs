using System.Data;

namespace Common.Activity;

public class ProgressValue
{
    private Tuple<int, int>? _tasksValue;

    public Tuple<int, int> TasksValue
    {
        get => _tasksValue ?? throw new NullReferenceException("_tasksValue is null");
        set
        {
            if (value.Item1 > value.Item2)
                throw new DataException($"Finished tasks count > Total tasks count");

            if (value.Item1 < 0 || value.Item2 < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"{nameof(value.Item1)} >= 0, {nameof(value.Item2)} >= 0."
                );

            _tasksValue = value;
        }
    }

    private double? _percentValue;

    public double PercentValue
    {
        get => _percentValue ?? throw new NullReferenceException("_percentValue is null");
        set
        {
            if (value is < 0 or > 1)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"{nameof(value)} must match `[0, 1]`."
                );

            _percentValue = value;
        }
    }

    private bool? _waiting;

    public bool IsWaiting
    {
        get => _waiting ?? throw new NullReferenceException("_waiting is null");
        set => _waiting = value;
    }
}