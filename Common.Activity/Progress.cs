namespace Common.Activity;

public class Progress
{
    private readonly ProgressValue? _value;

    private readonly ProgressType? _type;

    public Progress(ProgressType type)
    {
        _type = type;

        _value = new();

        OnValueChanged += (_, _) => { };
    }

    public dynamic? Value
    {
        get =>
            _type switch
            {
                ProgressType.Unknown => null,
                ProgressType.Tasks => _value?.TasksValue,
                ProgressType.Percent => _value?.PercentValue,
                ProgressType.Waiting => _value?.IsWaiting,
                null => null,
                _ => throw new ArgumentOutOfRangeException(nameof(_type), "_type is null")
            };
        set
        {
            if (_value is null) throw new NullReferenceException("_value is null");

            switch (value)
            {
                case Tuple<int, int> tasksValue:
                    if (_type != ProgressType.Tasks)
                        throw new ArgumentOutOfRangeException(
                            nameof(value),
                            "value can only be (int, int) for tasks value"
                        );
                    _value.TasksValue = tasksValue;
                    break;
                case double percentValue:
                    if (_type != ProgressType.Percent)
                        throw new ArgumentOutOfRangeException(
                            nameof(value),
                            "value can only be double for percent value"
                        );
                    _value.PercentValue = percentValue;
                    break;
                case bool waiting:
                    if (_type != ProgressType.Waiting)
                        throw new ArgumentOutOfRangeException(
                            nameof(value),
                            "value can only be bool for waiting value"
                        );
                    _value.IsWaiting = waiting;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "value can only be (int, int), double and bool"
                    );
            }

            OnValueChanged?.Invoke(this, value);
        }
    }

    public Progress SetTotalTasks(int count)
    {
        if (_type != ProgressType.Tasks)
            throw new NotSupportedException(
                $"{nameof(_type)} is not {nameof(ProgressType.Tasks)}"
            );

        _value!.TasksValue = _value?.TasksValue is null
            ? new Tuple<int, int>(0, count)
            : new Tuple<int, int>(_value!.TasksValue.Item1, count);

        return this;
    }

    public Progress FinishedTasks(int count = 1)
    {
        if (_type != ProgressType.Tasks)
            throw new NotSupportedException(
                $"{nameof(_type)} is not {nameof(ProgressType.Tasks)}"
            );

        var currentValue = _value!.TasksValue;
        _value!.TasksValue = new Tuple<int, int>(currentValue.Item1 + count, currentValue.Item2);

        return this;
    }

    public Progress UpdatePercent(double value = 0.01)
    {
        if (_type != ProgressType.Percent)
            throw new NotSupportedException(
                $"{nameof(_type)} is not {nameof(ProgressType.Tasks)}"
            );

        _value!.PercentValue = value;

        return this;
    }

    public Progress Wait()
    {
        if (_type != ProgressType.Waiting)
            throw new NotSupportedException(
                $"{nameof(_type)} is not {nameof(ProgressType.Waiting)}"
            );

        _value!.IsWaiting = true;

        return this;
    }

    public Progress Go()
    {
        if (_type != ProgressType.Waiting)
            throw new NotSupportedException(
                $"{nameof(_type)} is not {nameof(ProgressType.Waiting)}"
            );

        _value!.IsWaiting = false;

        return this;
    }

    public delegate void OnValueChangedHandler(object sender, dynamic value);

    public event OnValueChangedHandler? OnValueChanged;
}

public enum ProgressType
{
    Unknown = 0,
    Tasks = 1,
    Percent = 2,
    Waiting = 3,
}
