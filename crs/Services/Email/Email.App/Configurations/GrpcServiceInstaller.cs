﻿using Identity.Protobuf;

namespace Email.App.Configurations;

internal sealed class GrpcServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<IdentityService.IdentityServiceClient>(options =>
        {
            options.Address = new Uri(Env.IDENTITY_GRPC_URL);
        });

        services.AddGrpc();
    }
}
