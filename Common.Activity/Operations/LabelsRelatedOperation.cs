namespace Common.Activity.Operations;

public class LabelsRelatedOperation
{
    public string? Subject { get; set; }

    public DateTime? ExecuteTime { get; set; }

    public LabelsRelatedOperationTypes? Operation { get; set; }

    public List<string>? Targets { get; set; }
}

public enum LabelsRelatedOperationTypes
{
    Label = 0,
    Remove = 1
}