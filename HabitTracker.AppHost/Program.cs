var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.HabitTracker_ApiService>("apiservice");

builder.AddProject<Projects.HabitTracker_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
