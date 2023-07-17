#!/bin/bash
rm -rf samples
mkdir samples
pushd samples
dotnet new gnx-webapi -n "CompanyName.ProjectName.ServiceName"
popd