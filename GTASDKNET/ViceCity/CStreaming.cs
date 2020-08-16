using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public class CStreaming
    {
        public static CStreamingInfo GetInfoForModel(int modelID)
        {
            IntPtr addr = (IntPtr)(0x94DDD0 + (modelID * 0x14));
            return new CStreamingInfo(addr);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CStreaming__RequestModel(int id, int f);
        public static void RequestModel(int modelIndex, StreamingFlags flags)
        {
            Memory.CallFunction<CStreaming__RequestModel>(0x40E310)(modelIndex, (int)flags);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void CStreaming__LoadAllRequestedModels(bool b);
        public static void LoadAllRequestedModels(bool onlyQuickRequests)
        {
            Memory.CallFunction<CStreaming__LoadAllRequestedModels>(0x40B5F0)(onlyQuickRequests);
        }
    }
}
