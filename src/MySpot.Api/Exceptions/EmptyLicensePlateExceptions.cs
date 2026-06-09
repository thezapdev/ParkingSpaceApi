namespace MySpot.Api.Exceptions;

public sealed class EmptyLicensePlateExceptions : CustomException
{
    public EmptyLicensePlateExceptions() : base("License plate is empty")
    {

    }
}