


Set-Location 'C:\TANGJ15\code\00 Modularity\'
Get-ChildItem -Recurse -Directory -Hidden  -Filter .git | ForEach-Object {
    $temppath = Join-Path $_.Parent.Parent.FullName  "temp"
    $originalgitObjects = Join-Path $PSItem "objects" 
    $targetgit = Join-Path $temppath ".git"
    Write-Output $temppath    $_.FullName
   try{
    git clone --mirror --depth=5  $_.Parent.FullName $temppath|
      Remove-Item -Path  $originalgitObjects|
      Move-Item $targetgit -Filter "shallow,objects" 
   } finally{ 
   Remove-Item  $temppath -Recurse -force
   }
   
    
}
