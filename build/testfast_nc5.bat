@echo off
msbuild BaseAspNetAngularUnity.xml /t:BuildCommon;DropDatabase;CreateDatabase;AddEnableCoverage;TestOnly;SimianReport;GetCoverageReport