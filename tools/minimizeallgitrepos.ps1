


Set-Location 'C:\TANGJ15\code\00 Modularity'
Get-ChildItem -Recurse -Directory -Hidden  -Filter .git | ForEach-Object {
    $tempgitname = $_.Parent.Name, "tmpgit" -join ""
    $temppath = join-path  $_.Parent.Parent.FullName $tempgitname
    $originalgitObjects = Join-Path $_.FullName "objects" 
    $targetgitobjects = join-path $temppath "objects"
    $targetgitshallow = join-path $temppath "objects"
    $sourcerepo = "file://", $_.Parent.FullName -join ""
    try {
        # git clone --mirror --depth=1 -l $sourcerepo $temppath 
        set-location $_.Parent.FullName
        git reflog expire --all --expire=now 
        git gc --prune=now --aggressive
        git remote rm origin || true
        #git tag | xargs git tag -d
        git branch -D in || true 
        (
            cd .git
            rm -rf refs/remotes/ refs/original/ *_HEAD logs/
        )
        git for-each-ref --format="%(refname)" refs/original/ | xargs -n1 --no-run-if-empty git update-ref -d
        git -c gc.reflogExpire=0 -c gc.reflogExpireUnreachable=0 -c gc.rerereresolved=0 -c gc.rerereunresolved=0 -c gc.pruneExpire=now gc "$@"
        #  Remove-Item -Path $originalgitObjects -Recurse -force |
        #  Move-Item -Path  $targetgitobjects  -Destination $_.FullName |
        #  Move-Item -Path   $targetgitshallow  -Destination $_.FullName
    }
    finally { 
        #Remove-Item  $temppath -Recurse -force
    } 
    
}
