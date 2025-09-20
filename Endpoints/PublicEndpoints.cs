public static class PublicEndpoints
{
    public static void MapPublicEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("public/dashboard", () => "Your are in Public Dashboard");
    }
}