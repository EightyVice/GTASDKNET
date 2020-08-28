using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GTASDK.ViceCity
{
    public partial class CEntity
    {
        public int BaseAddress;

        public CEntity(IntPtr address)
        {
            BaseAddress = address.ToInt32();
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void _SetModelIndex(IntPtr _this, short modelindex);
        /// <summary>
        /// Sets Entity's Model index
        /// </summary>
        /// <param name="modelIndex">Model ID to be set, Note: You must load the model using <see cref="CStreaming"/> functions</param>
        public virtual void SetModelIndex(short modelIndex)
        {
            Memory.CallFunction<_SetModelIndex>(0x4898B0)((IntPtr)BaseAddress, modelIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private CRect GetBoundRectImpl(uint offset)
        {
            CRect result = default;
            GetBoundRect(ref result);
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private CVector GetBoundCentreImpl(uint offset)
        {
            CVector result = default;
            GetBoundCentre(ref result);
            return result;
        }
    }

}
