using Common.Activity.Operations;

namespace Common.Activity;

public class OperationsRecorder
{
    public List<OpenAndCloseOperation> OpenAndCloseOperations { get; } = new();

    public List<AssignersRelatedOperation> AssignersRelatedOperations { get; } = new();

    public List<LabelsRelatedOperation> LabelsRelatedOperations { get; } = new();
}