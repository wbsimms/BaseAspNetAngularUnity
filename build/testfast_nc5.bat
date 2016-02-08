@echo off
msbuild BaseAspNetAngularUnity.xml /t:SimianReport;BuildCommon;AddEnableCoverage;DropDatabase;CreateDatabase;TestOnly;GetCoverageReport