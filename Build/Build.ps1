<# 
	Copyright (c) 2016 by Shogun, All Right Reserved
	Author: Ivan Ivchenko
	Email: iivchenko@live.com
#>

Param
    (       
	    [switch]$Build,
		[switch]$Pack,
		[switch]$Clean
	)

Import-Module ((Get-Item $PSScriptRoot).FullName + "\Build.psm1")
	
$root = (Get-Item $PSScriptRoot).Parent.FullName
$solution =  Join-Path -Path $root -ChildPath "Src\ShogunLib.CommandLine.sln"
$project = Join-Path -Path $root -ChildPath "Src\ShogunLib.CommandLine\ShogunLib.CommandLine.csproj"
$bin = Join-Path -Path $root -ChildPath bin

Set-Variable -Name msb -Value "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" -Scope GLOBAL
Set-Variable -Name nuget -Value (Join-Path -Path $bin -ChildPath "nuget.exe") -Scope GLOBAL

$nuget = (Get-Variable -Name nuget -ValueOnly)

if (-not(Test-Path -Path $bin))
{
    New-Item $bin -ItemType Directory
}

if (-not(Test-Path -Path $nuget) -or $Clean)
{
	Download-Nuget
}

Restore-Packages -Solution $solution

if ($Build)
{
	Build-Solution -Path $solution -Configuration Release -Platform "x86"
}

if ($Pack)
{
	Build-Package -Project $project -Out $bin
}