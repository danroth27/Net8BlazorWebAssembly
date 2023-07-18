# Blazor WebAssembly in .NET 8

This project demonstrates how to build an ASP.NET Core hosted Blazor WebAssembly app with .NET 8 and how to upgrade existing apps to take advantage of the latest features.

To upgrade an existing ASP.NET Core hosted Blazor WebAssembly app to .NET 8:

1. Update the project file to target `net8.0` and package references to the latest .NET 8 versions ([commit](https://github.com/danroth27/Net8BlazorWebAssembly/commit/b81eba554e998a057f63d32803128a35092d73bb)).
1. Move content from *Client/wwwroot/index.html* to *Host.razor* ([commit](https://github.com/danroth27/Net8BlazorWebAssembly/commit/44cf65ef602e89a5ec88b42d2f30f70d8f9fbda9)):
    1. Update script to *blazor.web.js*.
    1. Replace `title` tag with `HeadOutlet` component.
1. Update *Client/Program.cs* ([commit](https://github.com/danroth27/Net8BlazorWebAssembly/commit/cd50cfde1a3dc48b2773be12f2236dd325ae9019)):
    1. Remove `builder.RootComponents.Add<HeadOutlet>("head::after")`.
1. Update *Server/Program.cs* ([commit](https://github.com/danroth27/Net8BlazorWebAssembly/commit/3144198a3d3be9ef78051da5fa8c5aaa4dfe98de)):
    1. Add `builder.Services.AddRazorComponents().AddWebAssemblyComponents()`.
    1. Remove `app.UseBlazorFrameworkFiles()`.
    1. Replace `MapFallbackToFile("index.html")` with `app.MapRazorComponents<Host>().AddWebAssemblyRenderMode()`.

To enable prerendering:

1. Update all components to support prerendering from the server ([commit](https://github.com/danroth27/Net8BlazorWebAssembly/commit/0c0d0f69b1df25232aa825cc886122a75dfbd4a2)).
1. In *Host.razor* replace the `id=app` tag with `<App @rendermode="@RenderMode.WebAssembly" />` ([commit](https://github.com/danroth27/Net8BlazorWebAssembly/commit/27bc4c423a4653bb38818dc2d3c7a57b71921442)).

Open issues:

- https://github.com/dotnet/aspnetcore/issues/49448
- https://github.com/dotnet/aspnetcore/issues/49056
- https://github.com/dotnet/aspnetcore/issues/49313
