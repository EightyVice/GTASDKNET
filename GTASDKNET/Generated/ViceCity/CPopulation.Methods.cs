using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EasyHook;

namespace GTASDK.ViceCity
{
    public partial class CPopulation
    {
        public static class Hook
        {
            public static LocalHook AddDeadPedInFrontOfCar(CPopulation__AddDeadPedInFrontOfCar functionDelegate) => Memory.Hook((IntPtr)0x53B180, functionDelegate);

            public static LocalHook AddPed(CPopulation__AddPed functionDelegate) => Memory.Hook((IntPtr)0x53B600, functionDelegate);

            public static LocalHook AddPedInCar(CPopulation__AddPedInCar functionDelegate) => Memory.Hook((IntPtr)0x53A8A0, functionDelegate);

            public static LocalHook AddToPopulation(CPopulation__AddToPopulation functionDelegate) => Memory.Hook((IntPtr)0x53BA80, functionDelegate);

            public static LocalHook CanJeerAtStripper(CPopulation__CanJeerAtStripper functionDelegate) => Memory.Hook((IntPtr)0x53A670, functionDelegate);

            public static LocalHook CanSolicitPlayerInCar(CPopulation__CanSolicitPlayerInCar functionDelegate) => Memory.Hook((IntPtr)0x53A6A0, functionDelegate);

            public static LocalHook CanSolicitPlayerOnFoot(CPopulation__CanSolicitPlayerOnFoot functionDelegate) => Memory.Hook((IntPtr)0x53A6C0, functionDelegate);

            public static LocalHook ChooseCivilianCoupleOccupations(CPopulation__ChooseCivilianCoupleOccupations functionDelegate) => Memory.Hook((IntPtr)0x53AE90, functionDelegate);

            public static LocalHook ChooseCivilianOccupation(CPopulation__ChooseCivilianOccupation functionDelegate) => Memory.Hook((IntPtr)0x53B070, functionDelegate);

            public static LocalHook ChooseNextCivilianOccupation(CPopulation__ChooseNextCivilianOccupation functionDelegate) => Memory.Hook((IntPtr)0x53AFD0, functionDelegate);

            public static LocalHook ConvertAllObjectsToDummyObjects(CPopulation__ConvertAllObjectsToDummyObjects functionDelegate) => Memory.Hook((IntPtr)0x53D430, functionDelegate);

            public static LocalHook ConvertToDummyObject(CPopulation__ConvertToDummyObject functionDelegate) => Memory.Hook((IntPtr)0x53D290, functionDelegate);

            public static LocalHook ConvertToRealObject(CPopulation__ConvertToRealObject functionDelegate) => Memory.Hook((IntPtr)0x53D340, functionDelegate);

            public static LocalHook GeneratePedsAtStartOfGame(CPopulation__GeneratePedsAtStartOfGame functionDelegate) => Memory.Hook((IntPtr)0x53E3E0, functionDelegate);

            public static LocalHook Initialise(CPopulation__Initialise functionDelegate) => Memory.Hook((IntPtr)0x53EAF0, functionDelegate);

            public static LocalHook IsFemale(CPopulation__IsFemale functionDelegate) => Memory.Hook((IntPtr)0x53AD50, functionDelegate);

            public static LocalHook IsMale(CPopulation__IsMale functionDelegate) => Memory.Hook((IntPtr)0x53ADF0, functionDelegate);

            public static LocalHook IsSkateable(CPopulation__IsSkateable functionDelegate) => Memory.Hook((IntPtr)0x53ACA0, functionDelegate);

            public static LocalHook IsSunbather(CPopulation__IsSunbather functionDelegate) => Memory.Hook((IntPtr)0x53A6F0, functionDelegate);

            public static LocalHook LoadPedGroups(CPopulation__LoadPedGroups functionDelegate) => Memory.Hook((IntPtr)0x53E9C0, functionDelegate);

            public static LocalHook ManagePopulation(CPopulation__ManagePopulation functionDelegate) => Memory.Hook((IntPtr)0x53D690, functionDelegate);

            public static LocalHook PlaceCouple(CPopulation__PlaceCouple functionDelegate) => Memory.Hook((IntPtr)0x5388F0, functionDelegate);

            public static LocalHook PlaceGangMembersInCircle(CPopulation__PlaceGangMembersInCircle functionDelegate) => Memory.Hook((IntPtr)0x5397F0, functionDelegate);

            public static LocalHook PlaceGangMembersInFormation(CPopulation__PlaceGangMembersInFormation functionDelegate) => Memory.Hook((IntPtr)0x539FC0, functionDelegate);

            public static LocalHook PlaceMallPedsAsStationaryGroup(CPopulation__PlaceMallPedsAsStationaryGroup functionDelegate) => Memory.Hook((IntPtr)0x538E90, functionDelegate);

            public static LocalHook RemovePed(CPopulation__RemovePed functionDelegate) => Memory.Hook((IntPtr)0x53B160, functionDelegate);

            public static LocalHook RemovePedsIfThePoolGetsFull(CPopulation__RemovePedsIfThePoolGetsFull functionDelegate) => Memory.Hook((IntPtr)0x53D560, functionDelegate);

            public static LocalHook TestSafeForRealObject(CPopulation__TestSafeForRealObject functionDelegate) => Memory.Hook((IntPtr)0x53CF80, functionDelegate);

            public static LocalHook Update(CPopulation__Update functionDelegate) => Memory.Hook((IntPtr)0x53E5F0, functionDelegate);

            public static LocalHook UpdatePedCount(CPopulation__UpdatePedCount functionDelegate) => Memory.Hook((IntPtr)0x53A720, functionDelegate);
        }

        // Method: AddDeadPedInFrontOfCar(CVector& posn, CVehicle* vehicle)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate CPed CPopulation__AddDeadPedInFrontOfCar(ref CVector posn, IntPtr vehicle);
        private static readonly CPopulation__AddDeadPedInFrontOfCar Call_CPopulation__AddDeadPedInFrontOfCar = Memory.CallFunction<CPopulation__AddDeadPedInFrontOfCar>(0x53B180);
        public static CPed AddDeadPedInFrontOfCar(ref CVector posn, CVehicle vehicle)
        {
            return Call_CPopulation__AddDeadPedInFrontOfCar(ref posn, (IntPtr)vehicle.BaseAddress);
        }

        // Method: AddPed(ePedType pedType, unsigned int modelIndex, CVector& posn, int arg3)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate CPed CPopulation__AddPed(ePedType pedType, uint modelIndex, ref CVector posn, int arg3);
        private static readonly CPopulation__AddPed Call_CPopulation__AddPed = Memory.CallFunction<CPopulation__AddPed>(0x53B600);
        public static CPed AddPed(ePedType pedType, uint modelIndex, ref CVector posn, int arg3)
        {
            return Call_CPopulation__AddPed(pedType, modelIndex, ref posn, arg3);
        }

        // Method: AddPedInCar(CVehicle* vehicle, bool driver)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate CPed CPopulation__AddPedInCar(IntPtr vehicle, int driver);
        private static readonly CPopulation__AddPedInCar Call_CPopulation__AddPedInCar = Memory.CallFunction<CPopulation__AddPedInCar>(0x53A8A0);
        public static CPed AddPedInCar(CVehicle vehicle, int driver)
        {
            return Call_CPopulation__AddPedInCar((IntPtr)vehicle.BaseAddress, driver);
        }

        // Method: AddToPopulation(float arg0, float arg1, float arg2, float arg3)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__AddToPopulation(float arg0, float arg1, float arg2, float arg3);
        private static readonly CPopulation__AddToPopulation Call_CPopulation__AddToPopulation = Memory.CallFunction<CPopulation__AddToPopulation>(0x53BA80);
        public static void AddToPopulation(float arg0, float arg1, float arg2, float arg3)
        {
            Call_CPopulation__AddToPopulation(arg0, arg1, arg2, arg3);
        }

        // Method: CanJeerAtStripper(int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__CanJeerAtStripper(int modelIndex);
        private static readonly CPopulation__CanJeerAtStripper Call_CPopulation__CanJeerAtStripper = Memory.CallFunction<CPopulation__CanJeerAtStripper>(0x53A670);
        public static int CanJeerAtStripper(int modelIndex)
        {
            return Call_CPopulation__CanJeerAtStripper(modelIndex);
        }

        // Method: CanSolicitPlayerInCar(int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__CanSolicitPlayerInCar(int modelIndex);
        private static readonly CPopulation__CanSolicitPlayerInCar Call_CPopulation__CanSolicitPlayerInCar = Memory.CallFunction<CPopulation__CanSolicitPlayerInCar>(0x53A6A0);
        public static int CanSolicitPlayerInCar(int modelIndex)
        {
            return Call_CPopulation__CanSolicitPlayerInCar(modelIndex);
        }

        // Method: CanSolicitPlayerOnFoot(int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__CanSolicitPlayerOnFoot(int modelIndex);
        private static readonly CPopulation__CanSolicitPlayerOnFoot Call_CPopulation__CanSolicitPlayerOnFoot = Memory.CallFunction<CPopulation__CanSolicitPlayerOnFoot>(0x53A6C0);
        public static int CanSolicitPlayerOnFoot(int modelIndex)
        {
            return Call_CPopulation__CanSolicitPlayerOnFoot(modelIndex);
        }

        // Method: ChooseCivilianCoupleOccupations(int arg0, int& arg1, int& arg2)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__ChooseCivilianCoupleOccupations(int arg0, ref int arg1, ref int arg2);
        private static readonly CPopulation__ChooseCivilianCoupleOccupations Call_CPopulation__ChooseCivilianCoupleOccupations = Memory.CallFunction<CPopulation__ChooseCivilianCoupleOccupations>(0x53AE90);
        public static void ChooseCivilianCoupleOccupations(int arg0, ref int arg1, ref int arg2)
        {
            Call_CPopulation__ChooseCivilianCoupleOccupations(arg0, ref arg1, ref arg2);
        }

        // Method: ChooseCivilianOccupation(int arg0)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__ChooseCivilianOccupation(int arg0);
        private static readonly CPopulation__ChooseCivilianOccupation Call_CPopulation__ChooseCivilianOccupation = Memory.CallFunction<CPopulation__ChooseCivilianOccupation>(0x53B070);
        public static int ChooseCivilianOccupation(int arg0)
        {
            return Call_CPopulation__ChooseCivilianOccupation(arg0);
        }

        // Method: ChooseNextCivilianOccupation(int arg0)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__ChooseNextCivilianOccupation(int arg0);
        private static readonly CPopulation__ChooseNextCivilianOccupation Call_CPopulation__ChooseNextCivilianOccupation = Memory.CallFunction<CPopulation__ChooseNextCivilianOccupation>(0x53AFD0);
        public static int ChooseNextCivilianOccupation(int arg0)
        {
            return Call_CPopulation__ChooseNextCivilianOccupation(arg0);
        }

        // Method: ConvertAllObjectsToDummyObjects()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__ConvertAllObjectsToDummyObjects();
        private static readonly CPopulation__ConvertAllObjectsToDummyObjects Call_CPopulation__ConvertAllObjectsToDummyObjects = Memory.CallFunction<CPopulation__ConvertAllObjectsToDummyObjects>(0x53D430);
        public static void ConvertAllObjectsToDummyObjects()
        {
            Call_CPopulation__ConvertAllObjectsToDummyObjects();
        }

        // Method: ConvertToDummyObject(CObject* aobject)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__ConvertToDummyObject(IntPtr aobject);
        private static readonly CPopulation__ConvertToDummyObject Call_CPopulation__ConvertToDummyObject = Memory.CallFunction<CPopulation__ConvertToDummyObject>(0x53D290);
        public static void ConvertToDummyObject(IntPtr aobject)
        {
            Call_CPopulation__ConvertToDummyObject(aobject);
        }

        // Method: ConvertToRealObject(CDummyObject* dummyObject)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__ConvertToRealObject(IntPtr dummyObject);
        private static readonly CPopulation__ConvertToRealObject Call_CPopulation__ConvertToRealObject = Memory.CallFunction<CPopulation__ConvertToRealObject>(0x53D340);
        public static void ConvertToRealObject(IntPtr dummyObject)
        {
            Call_CPopulation__ConvertToRealObject(dummyObject);
        }

        // Method: GeneratePedsAtStartOfGame()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__GeneratePedsAtStartOfGame();
        private static readonly CPopulation__GeneratePedsAtStartOfGame Call_CPopulation__GeneratePedsAtStartOfGame = Memory.CallFunction<CPopulation__GeneratePedsAtStartOfGame>(0x53E3E0);
        public static void GeneratePedsAtStartOfGame()
        {
            Call_CPopulation__GeneratePedsAtStartOfGame();
        }

        // Method: Initialise()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__Initialise();
        private static readonly CPopulation__Initialise Call_CPopulation__Initialise = Memory.CallFunction<CPopulation__Initialise>(0x53EAF0);
        public static void Initialise()
        {
            Call_CPopulation__Initialise();
        }

        // Method: IsFemale(int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__IsFemale(int modelIndex);
        private static readonly CPopulation__IsFemale Call_CPopulation__IsFemale = Memory.CallFunction<CPopulation__IsFemale>(0x53AD50);
        public static int IsFemale(int modelIndex)
        {
            return Call_CPopulation__IsFemale(modelIndex);
        }

        // Method: IsMale(int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__IsMale(int modelIndex);
        private static readonly CPopulation__IsMale Call_CPopulation__IsMale = Memory.CallFunction<CPopulation__IsMale>(0x53ADF0);
        public static int IsMale(int modelIndex)
        {
            return Call_CPopulation__IsMale(modelIndex);
        }

        // Method: IsSkateable(CVector& point)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__IsSkateable(ref CVector point);
        private static readonly CPopulation__IsSkateable Call_CPopulation__IsSkateable = Memory.CallFunction<CPopulation__IsSkateable>(0x53ACA0);
        public static int IsSkateable(ref CVector point)
        {
            return Call_CPopulation__IsSkateable(ref point);
        }

        // Method: IsSunbather(int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__IsSunbather(int modelIndex);
        private static readonly CPopulation__IsSunbather Call_CPopulation__IsSunbather = Memory.CallFunction<CPopulation__IsSunbather>(0x53A6F0);
        public static int IsSunbather(int modelIndex)
        {
            return Call_CPopulation__IsSunbather(modelIndex);
        }

        // Method: LoadPedGroups()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__LoadPedGroups();
        private static readonly CPopulation__LoadPedGroups Call_CPopulation__LoadPedGroups = Memory.CallFunction<CPopulation__LoadPedGroups>(0x53E9C0);
        public static void LoadPedGroups()
        {
            Call_CPopulation__LoadPedGroups();
        }

        // Method: ManagePopulation()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__ManagePopulation();
        private static readonly CPopulation__ManagePopulation Call_CPopulation__ManagePopulation = Memory.CallFunction<CPopulation__ManagePopulation>(0x53D690);
        public static void ManagePopulation()
        {
            Call_CPopulation__ManagePopulation();
        }

        // Method: PlaceCouple(ePedType pedType1, int modelIndex1, ePedType pedType2, int modelIndex2, CVector posn)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__PlaceCouple(ePedType pedType1, int modelIndex1, ePedType pedType2, int modelIndex2, CVector posn);
        private static readonly CPopulation__PlaceCouple Call_CPopulation__PlaceCouple = Memory.CallFunction<CPopulation__PlaceCouple>(0x5388F0);
        public static void PlaceCouple(ePedType pedType1, int modelIndex1, ePedType pedType2, int modelIndex2, CVector posn)
        {
            Call_CPopulation__PlaceCouple(pedType1, modelIndex1, pedType2, modelIndex2, posn);
        }

        // Method: PlaceGangMembersInCircle(ePedType pedType, int modelIndex, CVector& posn)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__PlaceGangMembersInCircle(ePedType pedType, int modelIndex, ref CVector posn);
        private static readonly CPopulation__PlaceGangMembersInCircle Call_CPopulation__PlaceGangMembersInCircle = Memory.CallFunction<CPopulation__PlaceGangMembersInCircle>(0x5397F0);
        public static void PlaceGangMembersInCircle(ePedType pedType, int modelIndex, ref CVector posn)
        {
            Call_CPopulation__PlaceGangMembersInCircle(pedType, modelIndex, ref posn);
        }

        // Method: PlaceGangMembersInFormation(ePedType pedType, int modelIndex, CVector& posn)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__PlaceGangMembersInFormation(ePedType pedType, int modelIndex, ref CVector posn);
        private static readonly CPopulation__PlaceGangMembersInFormation Call_CPopulation__PlaceGangMembersInFormation = Memory.CallFunction<CPopulation__PlaceGangMembersInFormation>(0x539FC0);
        public static void PlaceGangMembersInFormation(ePedType pedType, int modelIndex, ref CVector posn)
        {
            Call_CPopulation__PlaceGangMembersInFormation(pedType, modelIndex, ref posn);
        }

        // Method: PlaceMallPedsAsStationaryGroup(CVector& posn, int modelIndex)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__PlaceMallPedsAsStationaryGroup(ref CVector posn, int modelIndex);
        private static readonly CPopulation__PlaceMallPedsAsStationaryGroup Call_CPopulation__PlaceMallPedsAsStationaryGroup = Memory.CallFunction<CPopulation__PlaceMallPedsAsStationaryGroup>(0x538E90);
        public static void PlaceMallPedsAsStationaryGroup(ref CVector posn, int modelIndex)
        {
            Call_CPopulation__PlaceMallPedsAsStationaryGroup(ref posn, modelIndex);
        }

        // Method: RemovePed(CPed* ped)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__RemovePed(IntPtr ped);
        private static readonly CPopulation__RemovePed Call_CPopulation__RemovePed = Memory.CallFunction<CPopulation__RemovePed>(0x53B160);
        public static void RemovePed(CPed ped)
        {
            Call_CPopulation__RemovePed((IntPtr)ped.BaseAddress);
        }

        // Method: RemovePedsIfThePoolGetsFull()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__RemovePedsIfThePoolGetsFull();
        private static readonly CPopulation__RemovePedsIfThePoolGetsFull Call_CPopulation__RemovePedsIfThePoolGetsFull = Memory.CallFunction<CPopulation__RemovePedsIfThePoolGetsFull>(0x53D560);
        public static void RemovePedsIfThePoolGetsFull()
        {
            Call_CPopulation__RemovePedsIfThePoolGetsFull();
        }

        // Method: TestSafeForRealObject(CDummyObject* dummyObject)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CPopulation__TestSafeForRealObject(IntPtr dummyObject);
        private static readonly CPopulation__TestSafeForRealObject Call_CPopulation__TestSafeForRealObject = Memory.CallFunction<CPopulation__TestSafeForRealObject>(0x53CF80);
        public static int TestSafeForRealObject(IntPtr dummyObject)
        {
            return Call_CPopulation__TestSafeForRealObject(dummyObject);
        }

        // Method: Update(bool generatePeds)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__Update(int generatePeds);
        private static readonly CPopulation__Update Call_CPopulation__Update = Memory.CallFunction<CPopulation__Update>(0x53E5F0);
        public static void Update(int generatePeds)
        {
            Call_CPopulation__Update(generatePeds);
        }

        // Method: UpdatePedCount(ePedType pedType, unsigned char updateState)
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CPopulation__UpdatePedCount(ePedType pedType, byte updateState);
        private static readonly CPopulation__UpdatePedCount Call_CPopulation__UpdatePedCount = Memory.CallFunction<CPopulation__UpdatePedCount>(0x53A720);
        public static void UpdatePedCount(ePedType pedType, byte updateState)
        {
            Call_CPopulation__UpdatePedCount(pedType, updateState);
        }
    }
}