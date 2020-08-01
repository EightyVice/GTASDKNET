#include "GTASDKLoader.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Windows::Forms;

wchar_t* commandLine = NULL;

void Managed() {
	Assembly^ assembly;

	assembly = Assembly::LoadFrom("GTASDKNET.dll");
	Type^ main = assembly->GetType("GTASDK.Main");

	if (main) {
		MethodInfo^ InitFunc = main->GetMethod("Init");
		String^ cmdLine = gcnew String(commandLine);
		cmdLine->Replace("gta-vc.exe", "");
		InitFunc->Invoke(nullptr, gcnew array<Object^>{cmdLine});
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
		commandLine = GetCommandLine();

		HANDLE threadHandle = CreateThread(nullptr, 0, (LPTHREAD_START_ROUTINE)GoManaged, nullptr, 0, &threadID);

		if (threadHandle == nullptr || threadHandle == INVALID_HANDLE_VALUE)
		{
			return false;
		}

		CloseHandle(threadHandle);
		break;
	}

	return true;
}
