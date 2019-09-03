using Topshelf;

namespace WindowsServiceWithTopshelf
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(
                configure =>
                {
                    configure.Service<MyService>(
                        service =>
                        {
                            service.ConstructUsing(s => new MyService());
                            service.WhenStarted(s => s.Start());
                            service.WhenStopped(s => s.Stop());
                        });
                    configure.RunAsLocalSystem();
                    configure.SetServiceName("MyWindowServiceWithTopshelf");
                    configure.SetDisplayName("MyWindowServiceWithTopshelf");
                    configure.SetDescription("My .Net windows service with Topshelf");
                }
                );
        }
    }
}
