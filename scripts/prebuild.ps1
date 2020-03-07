dotnet tool install -g dotnet-roundhouse
rh /d=ContosoUniversityBlazor-wasm /f=..\src\Server\App_Data /s="(LocalDb)\mssqllocaldb" /silent
rh /d=ContosoUniversityBlazor-wasm-Test /f=..\src\Server\App_Data /s="(LocalDb)\mssqllocaldb" /silent /drop
rh /d=ContosoUniversityBlazor-wasm-Test /f=..\src\Server\App_Data /s="(LocalDb)\mssqllocaldb" /silent /simple