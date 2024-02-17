namespace Common.Activity.Operations;

public class OpenAndCloseOperation : BaseOperation
{
    public OpenAndCloseOperationTypes? Operation { get; set; }
}

public enum OpenAndCloseOperationTypes
{
    Open = 0,
    Close = 1
}
