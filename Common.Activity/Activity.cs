using Material.Icons;

namespace Common.Activity;

public class Activity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public List<string>? Assigners { get; set; }

    public MaterialIconKind? IconKind { get; set; }

    public string? Title { get; set; }

    public string? Category { get; set; }

    public List<string>? Labels { get; set; }

    public List<ActivityTask>? Tasks { get; set; }

    public ActivityStatus? Status { get; set; }

    public OperationsRecorder? Operations { get; set; }
}