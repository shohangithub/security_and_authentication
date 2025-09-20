public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/employee/create", () => "Employee created.").RequireAuthorization("manage-employee");
        app.MapPut("/api/employee/update", () => "Employee updated.").RequireAuthorization("manage-employee");
        app.MapDelete("/api/employee/delete", () => "Employee deleted").RequireAuthorization("manage-employee");
        app.MapGet("/api/employee/get", () => "Get employees").RequireAuthorization("admin");
    }
}