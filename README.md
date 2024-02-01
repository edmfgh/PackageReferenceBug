# PackageReferenceBug
Demos a compilation error instead of warning (NU1701) when PackageReferencing a project with <Content>.

Given a consumer project (with TargetFramework netstandard2.0) that PackageReferences a project with content (with TargetFrameworks net48;net6.0) and a project without content (with TargetFrameworks net48;net6.0),
the project with content fails to compile without obvious error as to why. On the other hand, the project without content compiles but with warning NU1701.

SDK: 8.0.101
Build version: MSBuild version 17.8.3+195e7f5a3 for .NET, 17.8.3.51904

To reproduce:
1. "dotnet pack" both ProjectWithContent and ProjectWithoutContent, e.g., "dotnet pack .\ProjectWithContent.csproj" -o <output folder>
2. Add <output folder> as a NuGet source
3. Ensure ProjectConsumer PackageReferences to both NuGet packages
4. Build ProjectConsumer

Expected: ProjectConsumer builds with NU1701 warnings for both projects.

Actual: ProjectConsumer fails to resolve symbols and references to ProjectWithContent: error CS0246: The type or namespace name 'ProjectWithContent' could not be found (are you missing a using directive or an assembly reference?). Meanwhile, ProjectWithoutContent symbols and references appear to resolve fine.

If there is a fundamental issue why a project with content cannot be PackageReferenced this way, I feel like there should be a more descriptive error message.