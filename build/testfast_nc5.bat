@echo off
msbuild BaseAspNetAngularUnity.xml /t:BuildCommon;AddEnableCoverage;DropDatabase;CreateDatabase;TestOnly;SimianReport;GetCoverageReport