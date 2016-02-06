@echo off
msbuild BaseAspNetAngularUnit.xml /t:SimianReport;BuildCommon;AddEnableCoverage;TestOnly;GetCoverageReport