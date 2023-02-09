namespace Common.Activity;

public class Task
{
    public string? Name { get; set; }
    
    public Progress? Progress { get; set; }
    
    public List<Task>? SubTasks { get; set; }

    public Dictionary<int, string>? Contents { get; set; }
    
    public Dictionary<int, string>? Warnings { get; set; }
    
    public Dictionary<int, string>? Errors { get; set; }
    
    public Result? Result { get; set; }
}