namespace Common.Activity.Operations;

public class AssignersRelatedOperation : BaseOperation
{
    public AssignersRelatedOperationTypes? Operation { get; set; }

    public List<string>? Targets { get; set; }
}

public enum AssignersRelatedOperationTypes
{
    Add = 0,
    Remove = 1
}
