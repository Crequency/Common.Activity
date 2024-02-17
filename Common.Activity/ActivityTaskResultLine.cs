namespace Common.Activity;

public class ActivityTaskResultLine
{
    public int Index { get; set; }

    public string? Content { get; set; }

    public ActivityTaskResultLineType Type { get; set; }
}

public enum ActivityTaskResultLineType
{
    Content = 1,
    Warning = 2,
    Error = 3,
}
