namespace Core5.DataBus.CleanupStrategy
{
    using NServiceBus;

    class Define
    {
        Define(BusConfiguration busConfiguration)
        {
            #region DefineFileLocationForDatabusFiles
            var dataBus = busConfiguration.UseDataBus<FileShareDataBus>();
            dataBus.BasePath(@"\\share\databus_attachments\");
            #endregion
        }
    }
}