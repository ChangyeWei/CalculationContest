# CalculationContest
* basic math operators (+,-,*,/,sqrt)
* undo and clear

# Run UnitTest
    - dotnet add test\CalculatorDemo.UnitTest\CalculatorDemo.UnitTest.csproj package coverlet.msbuild
    - dotnet test test\CalculatorDemo.UnitTest /p:CollectCoverage=true /p:CoverletOutput=..\..\test-result\coverage.opencover.xml /p:CoverletOutputFormat=opencover


# Generate coverage detail
    - dotnet add test\CalculatorDemo.UnitTest\CalculatorDemo.UnitTest.csproj package ReportGenerator
    - dotnet system-path-to\ReportGenerator.dll -reports:test-result\coverage.opencover.xml -targetdir:test-result\coverage\
