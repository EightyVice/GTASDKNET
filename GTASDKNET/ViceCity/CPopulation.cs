using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public static class CPopulation
    {

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CPopulation__IsFemale(int id);
        /// <summary>
        /// Indicates whether a model is used for female peds
        /// </summary>
        /// <param name="modelIndex">ID of the model</param>
        /// <returns></returns>
        public static bool IsFemale(int modelIndex)
        {
            return Memory.CallFunction<CPopulation__IsFemale>(0x53AD50)(modelIndex);
        }


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CPopulation__IsMale(int id);
        /// <summary>
        /// Indicates whether a model is used for male peds
        /// </summary>
        /// <param name="modelIndex">ID of the model</param>
        /// <returns></returns>
        public static bool IsMale(int modelIndex)
        {
            return Memory.CallFunction<CPopulation__IsFemale>(0x53AD50)(modelIndex);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool CPopulation__IsSunbather(int id);
        public static bool IsSunbather(int modelIndex)
        {
            return Memory.CallFunction<CPopulation__IsSunbather>(0x53A6F0)(modelIndex);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CPopulation__LoadPedGroups();
        public static void LoadPedGroups()
        {
            Memory.CallFunction<CPopulation__LoadPedGroups>(0x53E9C0)();
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CPopulation__Update(bool g);
        public static void Update(bool generatePeds)
        {
            Memory.CallFunction<CPopulation__Update>(0x53A720)(generatePeds);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void CPopulation__RemovePed(IntPtr p);
        public static void RemovePed(CPed ped)
        {
            Memory.CallFunction<CPopulation__RemovePed>(0x53B160)((IntPtr)ped.BaseAddress);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr AddPed(int p, int m)
    }
}
