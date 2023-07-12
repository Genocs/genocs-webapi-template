#!/bin/bash
rm -rf samples
mkdir samples
pushd samples
dotnet new webapi -n "CompanyName.ProjectName.ServiceName"
popd