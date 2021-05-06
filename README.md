# github-packages

Testing github packages

[![Publish on Github packages](https://github.com/jcl86/github-packages/actions/workflows/main.yml/badge.svg)](https://github.com/jcl86/github-packages/actions/workflows/main.yml)

### 1. Create github access token

https://docs.github.com/es/github/authenticating-to-github/creating-a-personal-access-token

### 2. Include in csproj repositoryUrl

````
 <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <PackageId>SuperLibrary</PackageId>
    <Version>1.0.0</Version>
    <Authors>authors</Authors>
    <PackageDescription>Super library for testing github packages</PackageDescription>
    <RepositoryUrl>https://github.com/jcl86/github-packages</RepositoryUrl>
  </PropertyGroup>
````

### 3. Dotnet cli

````
dotnet pack --configuration Release
dotnet pack ./src/SuperLibrary/SuperLibrary.csproj -c release -o ./artifacts
dotnet nuget push ./artifacts/SuperLibrary.*.nupkg --api-key yourAccesTokenWithWritepermissionInPGithubPackages --source https://nuget.pkg.github.com/jcl86/index.json --skip-duplicate
````