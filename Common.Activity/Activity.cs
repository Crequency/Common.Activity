using Common.Activity.Operations;
using Material.Icons;

namespace Common.Activity;

public class Activity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public MaterialIconKind? IconKind { get; set; }

    public List<string>? Assigners
    {
        get
        {
            if (Status == ActivityStatus.Unknown) return null;

            var assigners = new List<string>();

            foreach (var assignerOperation in this.Operations.AssignersRelatedOperations)
                switch (assignerOperation.Operation)
                {
                    case AssignersRelatedOperationTypes.Add:
                        assigners.AddRange(assignerOperation.Targets ?? new());
                        break;
                    case AssignersRelatedOperationTypes.Remove:
                        foreach (var target in assignerOperation.Targets ?? new())
                            assigners.Remove(target);
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return assigners;
        }
    }

    public List<string>? Labels
    {
        get
        {
            if (Status == ActivityStatus.Unknown) return null;

            var labels = new List<string>();

            foreach (var labelOperation in this.Operations.LabelsRelatedOperations)
                switch (labelOperation.Operation)
                {
                    case LabelsRelatedOperationTypes.Label:
                        labels.AddRange(labelOperation.Targets ?? new());
                        break;
                    case LabelsRelatedOperationTypes.Remove:
                        foreach (var target in labelOperation.Targets ?? new())
                            labels.Remove(target);
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            return labels;
        }
    }

    public List<ActivityTask> Tasks { get; } = new();

    public OperationsRecorder Operations { get; } = new();

    public ActivityStatus Status { get; private set; } = ActivityStatus.Unknown;

    public Activity AppendTask(ActivityTask task)
    {
        Tasks.Add(task);

        return this;
    }

    public Activity ExecuteAllTasks(bool recursive = true)
    {
        foreach (var task in Tasks)
            task.Execute(recursive);

        return this;
    }

    public Activity Open(string subject)
    {
        Operations.OpenAndCloseOperations.Add(new()
        {
            Subject = subject,
            ExecuteTime = DateTime.UtcNow,
            Operation = OpenAndCloseOperationTypes.Open
        });

        Status = ActivityStatus.Opened;

        return this;
    }

    public Activity Close(string subject)
    {
        Operations.OpenAndCloseOperations.Add(new()
        {
            Subject = subject,
            ExecuteTime = DateTime.UtcNow,
            Operation = OpenAndCloseOperationTypes.Close
        });

        Status = ActivityStatus.Closed;

        return this;
    }

    public Activity Assign(string subject, string target) => Assign(subject, new List<string>() { target });

    public Activity Assign(string subject, List<string> targets)
    {
        Operations.AssignersRelatedOperations.Add(new()
        {
            Subject = subject,
            ExecuteTime = DateTime.UtcNow,
            Operation = AssignersRelatedOperationTypes.Add,
            Targets = targets
        });

        return this;
    }

    public Activity RemoveAssign(string subject, string target)
        => RemoveAssign(subject, new List<string>() { target });

    public Activity RemoveAssign(string subject, List<string> targets)
    {
        Operations.AssignersRelatedOperations.Add(new()
        {
            Subject = subject,
            ExecuteTime = DateTime.UtcNow,
            Operation = AssignersRelatedOperationTypes.Remove,
            Targets = targets
        });

        return this;
    }

    public Activity Label(string subject, string label) => Label(subject, new List<string>() { label });

    public Activity Label(string subject, List<string> labels)
    {
        Operations.LabelsRelatedOperations.Add(new()
        {
            Subject = subject,
            ExecuteTime = DateTime.UtcNow,
            Operation = LabelsRelatedOperationTypes.Label,
            Targets = labels
        });

        return this;
    }

    public Activity RemoveLabel(string subject, string label)
        => RemoveLabel(subject, new List<string>() { label });

    public Activity RemoveLabel(string subject, List<string> labels)
    {
        Operations.LabelsRelatedOperations.Add(new()
        {
            Subject = subject,
            ExecuteTime = DateTime.UtcNow,
            Operation = LabelsRelatedOperationTypes.Remove,
            Targets = labels
        });

        return this;
    }
}