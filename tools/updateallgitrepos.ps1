
Set-Location "C:\TANGJ15\code\00 Modularity"
Get-ChildItem -Recurse -Directory -Hidden  -Filter .git | 
    ForEach-Object { 
    Write-Output "","---  " , $_.fullname   ""
    git --git-dir="$($_.FullName)" --work-tree="$(Split-Path $_.FullName -Parent)" pull --depth=1
}