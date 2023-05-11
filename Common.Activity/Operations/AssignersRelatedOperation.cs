namespace Common.Activity.Operations;

public class AssignersRelatedOperation
{
    public string? Subject { get; set; }
    
    public DateTime? ExecuteTime { get; set; }
    
    public AssignersRelatedOperationTypes? Operation { get; set; }
    
    public List<string>? Targets { get; set; }
}

public enum AssignersRelatedOperationTypes
{
    Add = 0,
    Remove = 1
}