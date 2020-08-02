#include "GTASDKLoader.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Windows::Forms;

wchar_t* commandLine = nullptr;

void Managed() {
	auto assembly = Assembly::LoadFrom("GTASDKNET.dll");
	auto main = assembly->GetType("GTASDK.Main");

	if (main) {
		auto initFunc = main->GetMethod("Init");
		auto cmdLine = gcnew String(commandLine);
		cmdLine->Replace("gta-vc.exe", "");
		initFunc->Invoke(nullptr, gcnew array<Object^>{cmdLine});
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
		DWORD threadId = 0;
		commandLine = GetCommandLine();

		const auto threadHandle = CreateThread(nullptr, 0, reinterpret_cast<LPTHREAD_START_ROUTINE>(GoManaged), nullptr, 0, &threadId);

		if (threadHandle == nullptr || threadHandle == INVALID_HANDLE_VALUE)
		{
			return false;
		}

		CloseHandle(threadHandle);
		break;
	}

	return true;
}
