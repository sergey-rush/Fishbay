Git repo info
-----------------
Commit

git status
git add --all
git commit -m "Improved project structure"
git push -u origin master

Repo

git checkout CommitHash
git branch BranchName
git merge BranchName
git rebase

git config --global user.email "you@example.com"
git config --global user.name "Your Name"


…or create a new repository on the command line
echo "# PackerApp" >> README.md
git init
git add README.md
git commit -m "first commit"
git remote add origin https://github.com/sergey-rush/Fishbay.git
git push -u origin master
…or push an existing repository from the command line
git remote add origin https://github.com/sergey-rush/Fishbay.git
git push -u origin master