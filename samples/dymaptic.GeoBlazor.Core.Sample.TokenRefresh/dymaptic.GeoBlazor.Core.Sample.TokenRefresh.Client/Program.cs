using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddInMemoryCollection();
builder.Services.AddGeoBlazor(builder.Configuration);

HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
//string token = await httpClient.GetStringAsync("api/auth/token");
//string token = "AAPTBortrZkGbW0HtPXqP_T5jDQY3os1TbearzAwNA2BlQPvZHH62Z-nnJZ_kNwVdYjNWCc7OpmkkUA-QmVMBM0xr3NZ3tywQouHs0iFwlT8JjovXfpSJWCmxxlXpqJtfUQ76RnLuzPlv8hiKF96MRc8aieGovWN8RoayiDEkhNKzYssp0Pr81XKzJB-0-t0Q6OKlSfLwTAv8S3FCu_4W5y8XGO_qbD2HqpdtPatj_kRBpQ.";

await builder.Build().RunAsync();