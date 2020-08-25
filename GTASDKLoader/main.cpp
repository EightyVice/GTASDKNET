#include "GTASDKLoader.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Windows::Forms;
using namespace System::IO;

void Managed() {
	String^ assemblyLocaiton = "";
	if (File::Exists("gta-vc.exe") || File::Exists("..\\gta3.exe")) { assemblyLocaiton = "GTASDK.NET\\GTASDKNET.dll"; }

	auto assembly = Assembly::LoadFrom(assemblyLocaiton);
	auto main = assembly->GetType("GTASDK.Main");

	if (main) {
		auto initFunc = main->GetMethod("Init");
		initFunc->Invoke(nullptr, nullptr);
	}
}

#pragma unmanaged

DWORD GoManaged() {
	Managed();
	return 0;
}

BOOL APIENTRY DllMain(HINSTANCE hInstance, DWORD reason, LPVOID reserved)
{
	switch (reason)
	{
	case DLL_PROCESS_ATTACH:
		DWORD threadID = 0;
		HANDLE threadHandle = CreateThread(nullptr, 0, (LPTHREAD_START_ROUTINE)GoManaged, nullptr, 0, &threadID);
		break;
	}

	return true;
}
