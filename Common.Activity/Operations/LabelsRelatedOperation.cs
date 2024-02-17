namespace Common.Activity.Operations;

public class LabelsRelatedOperation : BaseOperation
{
    public LabelsRelatedOperationTypes? Operation { get; set; }

    public List<string>? Targets { get; set; }
}

public enum LabelsRelatedOperationTypes
{
    Label = 0,
    Remove = 1
}
