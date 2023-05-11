namespace Common.Activity;

public class Progress
{
    private ProgressValue? _value = null;

    private readonly ProgressType? _type = null;

    public Progress(ProgressType type)
    {
        _type = type;

        _value = new();
        
        OnValueChanged += (_, _) => { };
    }

    public Progress SetValue<T>(T value)
    {
        if (_value is null) throw new NullReferenceException("_value is null");
        
        switch (value)
        {
            case Tuple<int, int> tasksValue:
                _value.TasksValue = tasksValue;
                break;
            case double percentValue:
                _value.PercentValue = percentValue;
                break;
            case bool waiting:
                _value.IsWaiting = waiting;
                break;
            default:
                throw new ArgumentOutOfRangeException("value can only be (int, int), double and bool");
        }
        
        OnValueChanged?.Invoke(this, value);

        return this;
    }

    public dynamic? GetValue()
    {
        return _type switch
        {
            ProgressType.Unknown => null,
            ProgressType.Tasks => _value?.TasksValue,
            ProgressType.Percent => _value?.PercentValue,
            ProgressType.Waiting => _value?.IsWaiting,
            null => null,
            _ => throw new ArgumentOutOfRangeException("_value is null")
        };
    }

    public delegate void OnValueChangedHandler(object sender, dynamic value);

    public event OnValueChangedHandler? OnValueChanged;
}

public enum ProgressType
{
    Unknown = 0,
    Tasks = 1,
    Percent = 2,
    Waiting = 3
}