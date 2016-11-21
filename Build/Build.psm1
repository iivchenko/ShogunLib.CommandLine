<# 
	Copyright (c) 2016 by Shogun, All Right Reserved
	Author: Ivan Ivchenko
	Email: iivchenko@live.com
#>

function Download-Nuget
{
    $url = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"	
	$nuget = (Get-Variable -Name nuget -ValueOnly)
	  
    Invoke-WebRequest -Uri $url -OutFile $nuget
}

function Restore-Packages
{
    param($solution)
	
	$nuget = (Get-Variable -Name nuget -ValueOnly)
	
    & $nuget restore $solution
}

function Build-Solution
{
    Param
	(
		$path, 
		$configuration,
		$platform
	)
    
	$msb = (Get-Variable -Name msb -ValueOnly)

    & $msb $path /nologo /m /t:Rebuild /p:Configuration=$configuration /property:Platform=$platform
}

function Build-Package
{
    Param
	(
		$project,
		$out
	)
	
	$nuget = (Get-Variable -Name nuget -ValueOnly)
    & $nuget pack $project -properties Configuration=Release -OutputDirectory $out
}