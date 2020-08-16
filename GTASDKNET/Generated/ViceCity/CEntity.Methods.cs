using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EasyHook;

namespace GTASDK.ViceCity
{
    public partial class CEntity
    {
        public static class Hook
        {
            public static LocalHook SetRwObjectAlpha(CEntity__SetRwObjectAlpha functionDelegate) => Memory.Hook((IntPtr)0x487990, functionDelegate);

            public static LocalHook ModifyMatrixForTreeInWind(CEntity__ModifyMatrixForTreeInWind functionDelegate) => Memory.Hook((IntPtr)0x487A20, functionDelegate);

            public static LocalHook SetupBigBuilding(CEntity__SetupBigBuilding functionDelegate) => Memory.Hook((IntPtr)0x487C70, functionDelegate);

            public static LocalHook GetDistanceFromCentreOfMassToBaseOfModel(CEntity__GetDistanceFromCentreOfMassToBaseOfModel functionDelegate) => Memory.Hook((IntPtr)0x487D10, functionDelegate);

            public static LocalHook GetIsOnScreenComplex(CEntity__GetIsOnScreenComplex functionDelegate) => Memory.Hook((IntPtr)0x488250, functionDelegate);

            public static LocalHook GetIsOnScreen(CEntity__GetIsOnScreen functionDelegate) => Memory.Hook((IntPtr)0x4885D0, functionDelegate);

            public static LocalHook GetIsVisible(CEntity__GetIsVisible functionDelegate) => Memory.Hook((IntPtr)0x488720, functionDelegate);

            public static LocalHook GetIsTouching(CEntity__GetIsTouching functionDelegate) => Memory.Hook((IntPtr)0x488740, functionDelegate);

            public static LocalHook HasPreRenderEffects(CEntity__HasPreRenderEffects functionDelegate) => Memory.Hook((IntPtr)0x489170, functionDelegate);

            public static LocalHook UpdateRpHAnim(CEntity__UpdateRpHAnim functionDelegate) => Memory.Hook((IntPtr)0x489330, functionDelegate);

            public static LocalHook UpdateRwFrame(CEntity__UpdateRwFrame functionDelegate) => Memory.Hook((IntPtr)0x489360, functionDelegate);

            public static LocalHook GetBoundCentre(CEntity__GetBoundCentre functionDelegate) => Memory.Hook((IntPtr)0x489380, functionDelegate);

            public static LocalHook DetachFromRwObject(CEntity__DetachFromRwObject functionDelegate) => Memory.Hook((IntPtr)0x489790, functionDelegate);

            public static LocalHook AttachToRwObject(CEntity__AttachToRwObject functionDelegate) => Memory.Hook((IntPtr)0x4897C0, functionDelegate);

            public static LocalHook PruneReferences(CEntity__PruneReferences functionDelegate) => Memory.Hook((IntPtr)0x4C69F0, functionDelegate);

            public static LocalHook ResolveReferences(CEntity__ResolveReferences functionDelegate) => Memory.Hook((IntPtr)0x4C6A30, functionDelegate);

            public static LocalHook CleanUpOldReference(CEntity__CleanUpOldReference functionDelegate) => Memory.Hook((IntPtr)0x4C6A80, functionDelegate);

            public static LocalHook RegisterReference(CEntity__RegisterReference functionDelegate) => Memory.Hook((IntPtr)0x4C6AC0, functionDelegate);

            public static LocalHook ProcessLightsForEntity(CEntity__ProcessLightsForEntity functionDelegate) => Memory.Hook((IntPtr)0x541590, functionDelegate);

            public static LocalHook IsEntityOccluded(CEntity__IsEntityOccluded functionDelegate) => Memory.Hook((IntPtr)0x634AE0, functionDelegate);
        }

        // VTable method: Add()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__Add(CEntity thisArg);
        public void Add()
        {
            Memory.CallVirtualFunction<CEntity__Add>(_vtable.ToInt32(), 0)(this);
        }

        // VTable method: Remove()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__Remove(CEntity thisArg);
        public void Remove()
        {
            Memory.CallVirtualFunction<CEntity__Remove>(_vtable.ToInt32(), 1)(this);
        }

        // VTable method: SetModelIndex(unsigned int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__SetModelIndex(CEntity thisArg, uint modelIndex);
        public void SetModelIndex(uint modelIndex)
        {
            Memory.CallVirtualFunction<CEntity__SetModelIndex>(_vtable.ToInt32(), 3)(this, modelIndex);
        }

        // VTable method: SetModelIndexNoCreate(unsigned int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__SetModelIndexNoCreate(CEntity thisArg, uint modelIndex);
        public void SetModelIndexNoCreate(uint modelIndex)
        {
            Memory.CallVirtualFunction<CEntity__SetModelIndexNoCreate>(_vtable.ToInt32(), 4)(this, modelIndex);
        }

        // VTable method: CreateRwObject()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__CreateRwObject(CEntity thisArg);
        public void CreateRwObject()
        {
            Memory.CallVirtualFunction<CEntity__CreateRwObject>(_vtable.ToInt32(), 5)(this);
        }

        // VTable method: DeleteRwObject()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__DeleteRwObject(CEntity thisArg);
        public void DeleteRwObject()
        {
            Memory.CallVirtualFunction<CEntity__DeleteRwObject>(_vtable.ToInt32(), 6)(this);
        }

        // VTable method: GetBoundRect(CRect& result)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__GetBoundRect(CEntity thisArg, ref CRect result);
        public void GetBoundRect(ref CRect result)
        {
            Memory.CallVirtualFunction<CEntity__GetBoundRect>(_vtable.ToInt32(), 7)(this, ref result);
        }

        // Partial method: GetBoundRect()
        public CRect GetBoundRect()
        {
            return GetBoundRectImpl(0x7);
        }

        // VTable method: ProcessControl()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__ProcessControl(CEntity thisArg);
        public void ProcessControl()
        {
            Memory.CallVirtualFunction<CEntity__ProcessControl>(_vtable.ToInt32(), 8)(this);
        }

        // VTable method: ProcessCollision()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__ProcessCollision(CEntity thisArg);
        public void ProcessCollision()
        {
            Memory.CallVirtualFunction<CEntity__ProcessCollision>(_vtable.ToInt32(), 9)(this);
        }

        // VTable method: ProcessShift()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__ProcessShift(CEntity thisArg);
        public void ProcessShift()
        {
            Memory.CallVirtualFunction<CEntity__ProcessShift>(_vtable.ToInt32(), 10)(this);
        }

        // VTable method: Teleport(CVector posn)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__Teleport(CEntity thisArg, CVector posn);
        public void Teleport(CVector posn)
        {
            Memory.CallVirtualFunction<CEntity__Teleport>(_vtable.ToInt32(), 11)(this, posn);
        }

        // VTable method: PreRender()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__PreRender(CEntity thisArg);
        public void PreRender()
        {
            Memory.CallVirtualFunction<CEntity__PreRender>(_vtable.ToInt32(), 12)(this);
        }

        // VTable method: Render()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__Render(CEntity thisArg);
        public void Render()
        {
            Memory.CallVirtualFunction<CEntity__Render>(_vtable.ToInt32(), 13)(this);
        }

        // VTable method: SetupLighting()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__SetupLighting(CEntity thisArg);
        public int SetupLighting()
        {
            return Memory.CallVirtualFunction<CEntity__SetupLighting>(_vtable.ToInt32(), 14)(this);
        }

        // VTable method: RemoveLighting(bool resetWorldColors)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__RemoveLighting(CEntity thisArg, int resetWorldColors);
        public void RemoveLighting(int resetWorldColors)
        {
            Memory.CallVirtualFunction<CEntity__RemoveLighting>(_vtable.ToInt32(), 15)(this, resetWorldColors);
        }

        // VTable method: FlagToDestroyWhenNextProcessed()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__FlagToDestroyWhenNextProcessed(CEntity thisArg);
        public void FlagToDestroyWhenNextProcessed()
        {
            Memory.CallVirtualFunction<CEntity__FlagToDestroyWhenNextProcessed>(_vtable.ToInt32(), 16)(this);
        }

        // Method: SetRwObjectAlpha(int alpha)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__SetRwObjectAlpha(CEntity thisArg, int alpha);
        private static readonly CEntity__SetRwObjectAlpha Call_CEntity__SetRwObjectAlpha = Memory.CallFunction<CEntity__SetRwObjectAlpha>(0x487990);
        public void SetRwObjectAlpha(int alpha)
        {
            Call_CEntity__SetRwObjectAlpha(this, alpha);
        }

        // Method: ModifyMatrixForTreeInWind()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__ModifyMatrixForTreeInWind(CEntity thisArg);
        private static readonly CEntity__ModifyMatrixForTreeInWind Call_CEntity__ModifyMatrixForTreeInWind = Memory.CallFunction<CEntity__ModifyMatrixForTreeInWind>(0x487A20);
        public void ModifyMatrixForTreeInWind()
        {
            Call_CEntity__ModifyMatrixForTreeInWind(this);
        }

        // Method: SetupBigBuilding()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__SetupBigBuilding(CEntity thisArg);
        private static readonly CEntity__SetupBigBuilding Call_CEntity__SetupBigBuilding = Memory.CallFunction<CEntity__SetupBigBuilding>(0x487C70);
        public void SetupBigBuilding()
        {
            Call_CEntity__SetupBigBuilding(this);
        }

        // Method: GetDistanceFromCentreOfMassToBaseOfModel()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate float CEntity__GetDistanceFromCentreOfMassToBaseOfModel(CEntity thisArg);
        private static readonly CEntity__GetDistanceFromCentreOfMassToBaseOfModel Call_CEntity__GetDistanceFromCentreOfMassToBaseOfModel = Memory.CallFunction<CEntity__GetDistanceFromCentreOfMassToBaseOfModel>(0x487D10);
        public float GetDistanceFromCentreOfMassToBaseOfModel()
        {
            return Call_CEntity__GetDistanceFromCentreOfMassToBaseOfModel(this);
        }

        // Method: GetIsOnScreenComplex()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__GetIsOnScreenComplex(CEntity thisArg);
        private static readonly CEntity__GetIsOnScreenComplex Call_CEntity__GetIsOnScreenComplex = Memory.CallFunction<CEntity__GetIsOnScreenComplex>(0x488250);
        public int GetIsOnScreenComplex()
        {
            return Call_CEntity__GetIsOnScreenComplex(this);
        }

        // Method: GetIsOnScreen()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__GetIsOnScreen(CEntity thisArg);
        private static readonly CEntity__GetIsOnScreen Call_CEntity__GetIsOnScreen = Memory.CallFunction<CEntity__GetIsOnScreen>(0x4885D0);
        public int GetIsOnScreen()
        {
            return Call_CEntity__GetIsOnScreen(this);
        }

        // Method: GetIsVisible()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__GetIsVisible(CEntity thisArg);
        private static readonly CEntity__GetIsVisible Call_CEntity__GetIsVisible = Memory.CallFunction<CEntity__GetIsVisible>(0x488720);
        public int GetIsVisible()
        {
            return Call_CEntity__GetIsVisible(this);
        }

        // Method: GetIsTouching(CVector& posn, float radius)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__GetIsTouching(CEntity thisArg, ref CVector posn, float radius);
        private static readonly CEntity__GetIsTouching Call_CEntity__GetIsTouching = Memory.CallFunction<CEntity__GetIsTouching>(0x488740);
        public int GetIsTouching(ref CVector posn, float radius)
        {
            return Call_CEntity__GetIsTouching(this, ref posn, radius);
        }

        // Method: HasPreRenderEffects()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__HasPreRenderEffects(CEntity thisArg);
        private static readonly CEntity__HasPreRenderEffects Call_CEntity__HasPreRenderEffects = Memory.CallFunction<CEntity__HasPreRenderEffects>(0x489170);
        public int HasPreRenderEffects()
        {
            return Call_CEntity__HasPreRenderEffects(this);
        }

        // Method: UpdateRpHAnim()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__UpdateRpHAnim(CEntity thisArg);
        private static readonly CEntity__UpdateRpHAnim Call_CEntity__UpdateRpHAnim = Memory.CallFunction<CEntity__UpdateRpHAnim>(0x489330);
        public void UpdateRpHAnim()
        {
            Call_CEntity__UpdateRpHAnim(this);
        }

        // Method: UpdateRwFrame()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__UpdateRwFrame(CEntity thisArg);
        private static readonly CEntity__UpdateRwFrame Call_CEntity__UpdateRwFrame = Memory.CallFunction<CEntity__UpdateRwFrame>(0x489360);
        public void UpdateRwFrame()
        {
            Call_CEntity__UpdateRwFrame(this);
        }

        // Method: GetBoundCentre(CVector& result)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__GetBoundCentre(CEntity thisArg, ref CVector result);
        private static readonly CEntity__GetBoundCentre Call_CEntity__GetBoundCentre = Memory.CallFunction<CEntity__GetBoundCentre>(0x489380);
        public void GetBoundCentre(ref CVector result)
        {
            Call_CEntity__GetBoundCentre(this, ref result);
        }

        // Partial method: GetBoundCentre()
        public CVector GetBoundCentre()
        {
            return GetBoundCentreImpl(0x489380);
        }

        // Method: DetachFromRwObject()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__DetachFromRwObject(CEntity thisArg);
        private static readonly CEntity__DetachFromRwObject Call_CEntity__DetachFromRwObject = Memory.CallFunction<CEntity__DetachFromRwObject>(0x489790);
        public void DetachFromRwObject()
        {
            Call_CEntity__DetachFromRwObject(this);
        }

        // Method: AttachToRwObject(RwObject* rwObject)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__AttachToRwObject(CEntity thisArg, IntPtr rwObject);
        private static readonly CEntity__AttachToRwObject Call_CEntity__AttachToRwObject = Memory.CallFunction<CEntity__AttachToRwObject>(0x4897C0);
        public void AttachToRwObject(IntPtr rwObject)
        {
            Call_CEntity__AttachToRwObject(this, rwObject);
        }

        // Method: PruneReferences()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__PruneReferences(CEntity thisArg);
        private static readonly CEntity__PruneReferences Call_CEntity__PruneReferences = Memory.CallFunction<CEntity__PruneReferences>(0x4C69F0);
        public void PruneReferences()
        {
            Call_CEntity__PruneReferences(this);
        }

        // Method: ResolveReferences()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__ResolveReferences(CEntity thisArg);
        private static readonly CEntity__ResolveReferences Call_CEntity__ResolveReferences = Memory.CallFunction<CEntity__ResolveReferences>(0x4C6A30);
        public void ResolveReferences()
        {
            Call_CEntity__ResolveReferences(this);
        }

        // Method: CleanUpOldReference(CEntity** pEntity)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__CleanUpOldReference(CEntity thisArg, IntPtr pEntity);
        private static readonly CEntity__CleanUpOldReference Call_CEntity__CleanUpOldReference = Memory.CallFunction<CEntity__CleanUpOldReference>(0x4C6A80);
        public void CleanUpOldReference(IntPtr pEntity)
        {
            Call_CEntity__CleanUpOldReference(this, pEntity);
        }

        // Method: RegisterReference(CEntity** pEntity)
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__RegisterReference(CEntity thisArg, IntPtr pEntity);
        private static readonly CEntity__RegisterReference Call_CEntity__RegisterReference = Memory.CallFunction<CEntity__RegisterReference>(0x4C6AC0);
        public void RegisterReference(IntPtr pEntity)
        {
            Call_CEntity__RegisterReference(this, pEntity);
        }

        // Method: ProcessLightsForEntity()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CEntity__ProcessLightsForEntity(CEntity thisArg);
        private static readonly CEntity__ProcessLightsForEntity Call_CEntity__ProcessLightsForEntity = Memory.CallFunction<CEntity__ProcessLightsForEntity>(0x541590);
        public void ProcessLightsForEntity()
        {
            Call_CEntity__ProcessLightsForEntity(this);
        }

        // Method: IsEntityOccluded()
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CEntity__IsEntityOccluded(CEntity thisArg);
        private static readonly CEntity__IsEntityOccluded Call_CEntity__IsEntityOccluded = Memory.CallFunction<CEntity__IsEntityOccluded>(0x634AE0);
        public int IsEntityOccluded()
        {
            return Call_CEntity__IsEntityOccluded(this);
        }
    }
}