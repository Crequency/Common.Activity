namespace Common.Activity.Operations;

public class OpenAndCloseOperation
{
    public string? Subject { get; set; }
    
    public DateTime? ExecuteTime { get; set; }

    public OpenAndCloseOperationTypes? Operation { get; set; }
}

public enum OpenAndCloseOperationTypes
{
    Open = 0,
    Close = 1
}