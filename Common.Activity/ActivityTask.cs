namespace Common.Activity;

public class ActivityTask
{
    public string? Name { get; set; }

    public Progress? Progress { get; set; }

    public List<ActivityTask>? SubTasks { get; set; }
    
    public ActivityTask? ParentTask { get; set; }

    public Dictionary<int, string>? Contents { get; set; }

    public Dictionary<int, string>? Warnings { get; set; }

    public Dictionary<int, string>? Errors { get; set; }

    public ActivityTaskStatus? Result { get; set; }
}
