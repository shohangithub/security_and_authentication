public static class AdminEndpoints
{
    public static void MapAdminEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/admin/dashboard", () => "You are in Admin Dashboard.").RequireAuthorization("admin");
        app.MapGet("/api/doctor/dashboard", () => "You are in Doctor Dashboard.").RequireAuthorization("doctor");
        app.MapGet("/api/patient/dashboard", () => "You are in Patient Dashboard.").RequireAuthorization("patient");
        app.MapGet("/api/user/dashboard", () => "You are in User Dashboard.").RequireAuthorization("user");
    }
}