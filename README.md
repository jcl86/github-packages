# Github packages

This repo contains an example of how we can work with github packages as a nuget package storage, and how can we publish and consumes packages.

We will work in a very similar way to how we would work with nuget.org, with the additional feature that we can publish private packages, simply making the containing repository visibility private.

[![Publish on Github packages](https://github.com/jcl86/github-packages/actions/workflows/main.yml/badge.svg)](https://github.com/jcl86/github-packages/actions/workflows/main.yml)

# Publish a package

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

You could publish the repository with a few coommands:

````
dotnet pack ./src/SuperLibrary/SuperLibrary.csproj -c release -o ./artifacts
dotnet nuget push ./artifacts/SuperLibrary.*.nupkg --api-key yourAccesTokenWithWritepermissionInGithubPackages --source https://nuget.pkg.github.com/OWNER/index.json --skip-duplicate
````
### 4. Github actions

Or you can configure a pipeline like this:

https://github.com/jcl86/github-packages/blob/main/.github/workflows/main.yml

Inside the pipeline, the gitub access token (which was created in the first step) can be accesed via ${{secrets.GITHUB_TOKEN}} variable, provided by the action itself.


# Consume a package

Once the package is uploaded to github packages, we can consume it from other sources:

### 1. Add Nuget.Config

Add a file called Nuget.Config in your consumer repository root

````
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <clear />
        <add key="github" value="https://nuget.pkg.github.com/OWNER/index.json" />
    </packageSources>
    <packageSourceCredentials>
        <github>
            <add key="Username" value="USERNAME" />
            <add key="ClearTextPassword" value="TOKEN" />
        </github>
    </packageSourceCredentials>
</configuration>
````
You must replace:

- USERNAME with the name of your user account on GitHub.
- TOKEN with your personal access token.
- OWNER with the name of the user or organization account that owns the repository containing your project.

### 2. Ignore the file

As it contains user secrets, add Nuget.Config file to your repository .gitignore file

### 3. Add reference to the package in the project where you want to consume it

````
dotnet add src/SuperConsumer/SuperConsumer.csproj package SuperLibrary --version 1.0.6
````

