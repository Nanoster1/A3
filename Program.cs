using System.Diagnostics;
using A3;
using A3.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddA3();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<IApp>();

var cts = new CancellationTokenSource();
Process.GetCurrentProcess().Exited += (_, _) => cts.Cancel();

await app.Run(cts.Token);
