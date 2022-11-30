namespace Common.Activity;

public class Progress
{
    public enum ProgressType
    {
        Tasks = 1, Percent = 2, Waiting = 3 
    }
    
    public ProgressType? Type { get; set; }
    
    public (int, int)? TasksValue { get; set; }
    
    public double? PercentValue { get; set; }
}