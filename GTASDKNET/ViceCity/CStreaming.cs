using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace GTASDK.ViceCity
{
    public enum StreamingFlags
    {
        GAME_REQUEST = 0x1,
        MISSION_REQUEST = 0x2,
        PRIORITY_REQUEST = 0x8,
        NOT_VISIBLE = 0x10
    };

    public class CStreaming
    {


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
