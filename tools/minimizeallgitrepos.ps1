

Set-Location 'C:\TANGJ15\code\00 Modularity\ASP.NET-MVC-Boilerplate'
Get-ChildItem -Recurse -Directory -Hidden  -Filter .git | ForEach-Object { & git clone --mirror --depth=5  ../temp | Remove-Item -rf .git/objects | Move-Item ../temp/*.git -Filter[shallow, objects] | Remove-Item -rf ../temp}