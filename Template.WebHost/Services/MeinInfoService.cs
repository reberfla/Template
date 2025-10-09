namespace Template.WebHost.Services;

public class MeinInfoService: IInfoService
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