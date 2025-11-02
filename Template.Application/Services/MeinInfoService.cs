namespace Template.Application.Services;

public class MeinInfoService : IInfoService
{
    public DateTime GibMirInfo()
    {
        return DateTime.UtcNow;
    }

}

public interface IInfoService
{
    DateTime GibMirInfo();
}