using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace OOPESAM.Core
{
    public class EncryptMethod
    {
        public enum OOPEncryptor
        {
            USBMasterCard = 1,
            NetEncryptor
        }
        [DebuggerNonUserCode]
        public EncryptMethod()
        {
        }
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short OpenDevice();
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ConnectDevice([MarshalAs(UnmanagedType.VBByRefStr)] ref string Ip, [MarshalAs(UnmanagedType.VBByRefStr)] ref string portNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Ctime);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short CloseDevice();
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short IdentityAuthentication(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short UserControl(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate1(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate2(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterElseUpdate(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short InCreasePurse(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short InintPurse(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short KeyUpdateV2(short PutKeySum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutKeystate, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutKeyid, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short DataClear1(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short DataClear2(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short InfraredRand([MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRand1);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short InfraredAuth(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand1Endata, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand2Endata);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ChipInfo(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutChipType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string FacCode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutUserid, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamver, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutTime, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutKeyver, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutKeyid, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ElecSeal(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short MacCheck(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutMac);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short EncMacWrite(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutFileID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDataBegin, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short MacWrite(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutFileID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDataBegin, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short EncForCompare([MarshalAs(UnmanagedType.VBByRefStr)] ref string KeyIndex, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStationForMeter.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short DecreasePurse(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short Set_MeterType(int flag);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_ReadPreset_Card", ExactSpelling = true, SetLastError = true)]
        public static extern short ReadPresetCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string outData1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData3, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData4, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData5);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_Preset_Card", ExactSpelling = true, SetLastError = true)]
        public static extern short PresetCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string outData1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData3, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData4, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData5);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "OpenDevice", ExactSpelling = true, SetLastError = true)]
        public static extern short OpenDeviceNet();
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "ConnectDevice", ExactSpelling = true, SetLastError = true)]
        public static extern short ConnectDeviceNet([MarshalAs(UnmanagedType.VBByRefStr)] ref string Ip, [MarshalAs(UnmanagedType.VBByRefStr)] ref string portNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Ctime);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short CloseDeviceNet();
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_IdentityAuthentication", ExactSpelling = true, SetLastError = true)]
        public static extern short IdentityAuthenticationNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_UserControl", ExactSpelling = true, SetLastError = true)]
        public static extern short UserControlNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_ParameterUpdate", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdateNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_ParameterUpdate1", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate1Net(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_ParameterUpdate2", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate2Net(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_ParameterElseUpdate", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterElseUpdateNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_InCreasePurse", ExactSpelling = true, SetLastError = true)]
        public static extern short InCreasePurseNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_InintPurse", ExactSpelling = true, SetLastError = true)]
        public static extern short InintPurseNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_DataClear1", ExactSpelling = true, SetLastError = true)]
        public static extern short DataClear1Net(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_DataClear2", ExactSpelling = true, SetLastError = true)]
        public static extern short DataClear2Net(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_InfraredRand", ExactSpelling = true, SetLastError = true)]
        public static extern short InfraredRandNet([MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRand1);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_InfraredAuth", ExactSpelling = true, SetLastError = true)]
        public static extern short InfraredAuthNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand1Endata, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand2Endata);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_MacCheck", ExactSpelling = true, SetLastError = true)]
        public static extern short MacCheckNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutApdu, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutMac);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_EncMacWrite", ExactSpelling = true, SetLastError = true)]
        public static extern short EncMacWriteNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutFileID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDataBegin, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_MacWrite", ExactSpelling = true, SetLastError = true)]
        public static extern short MacWriteNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutEsamNo, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutFileID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDataBegin, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_EncForCompare", ExactSpelling = true, SetLastError = true)]
        public static extern short EncForCompareNet([MarshalAs(UnmanagedType.VBByRefStr)] ref string KeyIndex, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_ReadPreset_Card", ExactSpelling = true, SetLastError = true)]
        public static extern short ReadPresetCardNet([MarshalAs(UnmanagedType.VBByRefStr)] ref string outData1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData3, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData4, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData5);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_Preset_Card", ExactSpelling = true, SetLastError = true)]
        public static extern short PresetCardNet([MarshalAs(UnmanagedType.VBByRefStr)] ref string outData1, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData2, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData3, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData4, [MarshalAs(UnmanagedType.VBByRefStr)] ref string outData5);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, EntryPoint = "Meter_Formal_DecreasePurse", ExactSpelling = true, SetLastError = true)]
        public static extern short DecreasePurseNet(short Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short OpenPortTest();
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern short ClosePort();
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "IdentityAuthentication", ExactSpelling = true, SetLastError = true)]
        public static extern short IdentityAuthenticationOldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string PutDiv, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutEndata);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "InCreasePurse", ExactSpelling = true, SetLastError = true)]
        public static extern short InCreasePurseOldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "UserControl", ExactSpelling = true, SetLastError = true)]
        public static extern short UserControlOldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivEsamNumData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "ParameterUpdate", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdateOldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "ParameterElseUpdate", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterElseUpdateOldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "Parameter1", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate1OldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivApduData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "Parameter2", ExactSpelling = true, SetLastError = true)]
        public static extern short ParameterUpdate2OldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivApduData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("TestZhuzhan.dll", CharSet = CharSet.Ansi, EntryPoint = "Maccheck", ExactSpelling = true, SetLastError = true)]
        public static extern short MacCheckOldTestCard([MarshalAs(UnmanagedType.VBByRefStr)] ref string RandDivData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string DataOut);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int CreateRand(int RandLength, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSign);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Formal_GetRandHost(int RandLength, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSign);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Test_GetRandHost(int RandLength, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSign);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_InitSession(int KeyState, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ASCTR, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSessinInit, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSign);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_InitSession(int KeyState, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ASCTR, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Flag, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSessinInit, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSign);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_VerifySession(int KeyState, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TestEsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string RandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Sign, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSessionKey);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_VerifySession(int KeyState, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TestEsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string RandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Sign, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSessionKey);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_VerifyReadData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string RandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReadData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Mac, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_VerifyReadData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string RandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReadData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Mac, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_VerifyReportData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string RandTerminal, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReportData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Mac, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRSPCTR);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_GetResponseData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string RandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string ReportData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_GetMeterSetData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_GetMeterSetData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_VerifyMeterData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Mac, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_VerifyMeterData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string Mac, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_GetSessionData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, int TaskType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_GetSessionData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, int TaskType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_SetESAMData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string MeterNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAddData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_SetESAMData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string MeterNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAddData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_GetESAMData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OAD, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAddData);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_GetESAMData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OAD, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutRandHost, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAddData);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_VerifyESAMData(int KeyState, int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OAD, [MarshalAs(UnmanagedType.VBByRefStr)] ref string MeterNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamRand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string PutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string InMac, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_GetPurseData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, int TaskType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_GetPurseData(int OperateMode, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, int TaskType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string TaskData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("SocketAPI.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Formal_GetTrmKeyData(int KeyState, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string MeterNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string KeyType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutTrmKeyData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        [DllImport("MasterStation.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int Obj_Meter_Test_GetTrmKeyData(int KeyState, [MarshalAs(UnmanagedType.VBByRefStr)] ref string EsamId, [MarshalAs(UnmanagedType.VBByRefStr)] ref string SessionKey, [MarshalAs(UnmanagedType.VBByRefStr)] ref string MeterNum, [MarshalAs(UnmanagedType.VBByRefStr)] ref string KeyType, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutSID, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutAttachData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutTrmKeyData, [MarshalAs(UnmanagedType.VBByRefStr)] ref string OutMac);
        
    }
}
