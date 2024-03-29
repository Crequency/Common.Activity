namespace Common.Activity;

public enum ActivityStatus
{
    Unknown = 0,
    Opened = 1,
    Pending = 2,
    Running = 3,
    Closed = 4
}

public enum ActivityTaskStatus
{
    Unknown = 0,
    Pending = 1,
    Running = 2,
    Success = 3,
    Warning = 4,
    Errored = 5,
}
