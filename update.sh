#!/bin/bash
rm -rf build
mkdir build
curl -L https://github.com/genocs/webapi-template/archive/master.zip -o build/webapi-master.zip
unzip build/webapi-master.zip -d build 
cp -R src/* build

rm -rf build/template/.all-contributorsrc
rm -rf build/template/.git
rm -rf build/template/.gitignore
rm -rf build/template/appveyor.yml
rm -rf build/template/docker-compose.yml
rm -rf build/template/.vscode
rm -rf build/template/docs
rm -rf build/template/LICENSE