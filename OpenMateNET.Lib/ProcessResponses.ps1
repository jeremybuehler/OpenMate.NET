$Root  = (Split-Path -Path $MyInvocation.MyCommand.Path -Parent);

Set-Alias xsd $Root\xsd.exe

pushd Responses

ls *.xml | foreach-object { xsd $_ }
ls *.xsd | foreach-object { xsd $_  /classes /language:CS /namespace:OpenTrack.Responses}

foreach($file in (Get-ChildItem *.cs))
{
	(Get-Content $file.PSPath) | ForEach-Object { $_ -replace "\[\]\[\]", "[]" } | Set-Content $file.PSPath
}

popd