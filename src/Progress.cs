using Common.Activity.Args;

namespace Common.Activity;

public class Progress
{
    public Progress()
    {
        OnTypeChanged += (_, _) => { };
        OnValueChanged += (_, _) => { };
    }

    public enum ProgressType
    {
        Null = 0,
        Tasks = 1,
        Percent = 2,
        Waiting = 3
    }

    private ProgressType? _type = ProgressType.Percent;

    private (int, int)? _tasksValue = (0, 0);

    private double? _percentValue = 0.0;

    public ProgressType? Type
    {
        get => _type ?? ProgressType.Null;
        set
        {
            _type = value ?? ProgressType.Null;
            OnTypeChanged?.Invoke(this, value ?? ProgressType.Null);
        }
    }

    public (int, int)? TasksValue
    {
        get => _tasksValue;
        set
        {
            _tasksValue = value;
            OnValueChanged?.Invoke(this, new()
            {
                Message = ""
            });
        }
    }

    public double? PercentValue
    {
        get => _percentValue;
        set
        {
            _percentValue = value;
            OnValueChanged?.Invoke(this, new()
            {
                Message = ""
            });
        }
    }

    public delegate void OnTypeChangedHandler(object sender, ProgressType newType);

    public delegate void OnValueChangedHandler(object sender, ProgressValueChangedEventArgs args);

    public event OnTypeChangedHandler? OnTypeChanged;

    public event OnValueChangedHandler? OnValueChanged;
}
