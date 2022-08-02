echo "copying razor files to web folder"
mkdir -p wwwroot/pages
for file in Pages/*.razor
do
  if [ "$file" != "*.css" ];
  then
    cp "$file" "wwwroot/${file%.razor}.html"
  fi
done