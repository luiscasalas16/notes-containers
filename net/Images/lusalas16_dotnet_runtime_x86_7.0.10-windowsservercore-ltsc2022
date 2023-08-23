# escape=`

FROM mcr.microsoft.com/windows/servercore:ltsc2022-amd64

ENV `
    # Configure web servers to bind to port 80 when present
    ASPNETCORE_URLS=http://+:80 `
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true `
    # .NET Runtime version
    DOTNET_VERSION=7.0.10

# Install .NET Runtime
RUN powershell -Command `
        $ErrorActionPreference = 'Stop'; `
        $ProgressPreference = 'SilentlyContinue'; `
        `
        Invoke-WebRequest -OutFile dotnet.zip https://dotnetcli.azureedge.net/dotnet/Runtime/$Env:DOTNET_VERSION/dotnet-runtime-$Env:DOTNET_VERSION-win-x86.zip; `
        $dotnet_sha512 = '8C0CA0CE75D8581D0641B6DD3AB5CB84DA13DDEFB8D9FD807FE843E266272B7624DFBCFDC584CBF74452EAD92C719D872C6E781789BB33CBF73ACA77ECB8F28F'; `
        if ((Get-FileHash dotnet.zip -Algorithm sha512).Hash -ne $dotnet_sha512) { `
            Write-Host 'CHECKSUM VERIFICATION FAILED!'; `
            exit 1; `
        }; `
        `
        mkdir 'C:\Program Files (x86)\dotnet'; `
        tar -oxzf dotnet.zip -C 'C:\Program Files (x86)\dotnet'; `
        Remove-Item -Force dotnet.zip

RUN setx /M PATH "%PATH%;C:\Program Files (x86)\dotnet"
