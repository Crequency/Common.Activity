using Common.Activity.Operations;

namespace Common.Activity;

public class OperationsRecorder
{
    public List<OpenAndCloseOperation>? OpenAndCloseOperations { get; set; }

    public List<AssignersRelatedOperation>? AssignersRelatedOperations { get; set; }
}