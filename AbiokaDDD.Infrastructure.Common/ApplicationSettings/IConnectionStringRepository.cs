namespace AbiokaDDD.Infrastructure.Common.ApplicationSettings
{
    public interface IConnectionStringRepository
	{
		string ReadConnectionString(string connectionStringName);
        string ReadAppSetting(string appSettingName);
    }
}
