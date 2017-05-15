Name:       csapi-nui
Summary:    dali-NUI
Version:    0.2.38
Release:    1
Group:      Development/Libraries
License:    Apache-2.0 and BSD-3-Clause and MIT
URL:        https://www.tizen.org
Source0:    %{name}-%{version}.tar.gz
Source1:    %{name}.manifest

AutoReqProv: no
ExcludeArch: aarch64

BuildRequires: dotnet-build-tools

# C# API Requires

BuildRequires: csapi-tizen-nuget
BuildRequires: csapi-application-common-nuget
BuildRequires: csapi-application-ui-nuget

%define Assemblies Tizen.NUI

%description
%{summary}

%_nuget_package

%prep
%setup -q
cp %{SOURCE1} .

%build
for ASM in %{Assemblies}; do
%dotnet_build $ASM /p:DefineConstants="DOT_NET_CORE","DEBUG_ON"
%dotnet_pack $ASM/$ASM.nuspec %{version}
done


%install
for ASM in %{Assemblies}; do
%dotnet_install $ASM
done

%files
%manifest %{name}.manifest
%license LICENSE
%attr(644,root,root) %{dotnet_assembly_files}
