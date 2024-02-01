# PackageReferenceBug
Demos a compilation error instead of warning (NU1701) when PackageReferencing a project with Content.

Given a consumer project, ProjectConsumer (with TargetFramework netstandard2.0) that PackageReferences: ProjectWithContent (with TargetFrameworks net48;net6.0) and ProjectWithoutContent (also with TargetFrameworks net48;net6.0), ProjectConsumer fails to compile with "error CS0246: The type or namespace name 'ProjectWithContent' could not be found (are you missing a using directive or an assembly." On the other hand, ProjectWithoutContent compiles with warning NU1701.

SDK: 8.0.101
Build: MSBuild version 17.8.3+195e7f5a3 for .NET, 17.8.3.51904

To reproduce:
1. "dotnet pack" both ProjectWithContent and ProjectWithoutContent, e.g., "dotnet pack .\ProjectWithContent.csproj" -o <output folder>
2. Add <output folder> as a NuGet source
3. Ensure ProjectConsumer references ProjectWithContent and ProjectWithoutContent
4. Build ProjectConsumer

Expected: ProjectConsumer builds with NU1701 warnings.

Actual: ProjectConsumer fails to resolve symbols and references to ProjectWithContent: error CS0246: The type or namespace name 'ProjectWithContent' could not be found (are you missing a using directive or an assembly reference?).

If there is a fundamental issue why a project with content cannot be PackageReferenced this way, it would be nice to have a more descriptive error message.