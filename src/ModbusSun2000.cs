using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using HomeAutomation.Modbus.Converter;
using HomeAutomation.Modbus.Model;

namespace HomeAutomation.Modbus
{
    public class ModbusSun2000
    {
        private static ModbusClient _modbusClient = new ModbusClient();
        public static string ModbusIpSun2000;
        public static int Port = 502;
        public static bool ModbusSun2000Connected;
        public static SUN2000 sun2000 = new SUN2000();

        public static void ReadSun2000()
        {
            DateTime date;
            _modbusClient.IPAddress = ModbusIpSun2000;
            _modbusClient.Port = Port;
            

            try
            {
                if (!_modbusClient.Connected)
                {
                    _modbusClient.Connect();
                    WriteDateTimeToSun2000(); //Schreibe Zeit beim ersten Verbinden
                    ModbusSun2000Connected = false;
                }

                if (_modbusClient.Connected)
                {
                    ModbusSun2000Connected = true;

                   //WERTE
                    //Dynamische Werte
                    sun2000.Time = UnixTimeStampToDateTime(ReadModbusInt(40000, 2))[0];

                    int[] _32000 = ReadModbus(32000, 120);

                    sun2000.State1 = _32000[0];
                    sun2000.State1Text = ConverterSun2000.GetState1(sun2000.State1);
                    sun2000.State2 = _32000[1];
                    sun2000.State2Text = ConverterSun2000.GetState2(sun2000.State2);
                    sun2000.State3 = _32000[2];
                    sun2000.State3Text = ConverterSun2000.GetState3(sun2000.State3);
                    sun2000.Alarm1 = _32000[8];
                    sun2000.Alarm1Text = ConverterSun2000.GetAlarm1(sun2000.Alarm1);
                    sun2000.Alarm2 = _32000[9];
                    sun2000.Alarm2Text = ConverterSun2000.GetAlarm2(sun2000.Alarm2);
                    sun2000.Alarm3 = _32000[10];
                    sun2000.Alarm3Text = ConverterSun2000.GetAlarm3(sun2000.Alarm3);

                    sun2000.PV1_U_V = (double)_32000[16] / 10;
                    sun2000.PV1_I_A = (double)_32000[17] / 100;
                    sun2000.PV1_P_W = sun2000.PV1_U_V * sun2000.PV1_I_A;

                    sun2000.PV2_U_V = (double)_32000[18] / 10;
                    sun2000.PV2_I_A = (double)_32000[19] / 100;
                    sun2000.PV2_P_W = sun2000.PV2_U_V * sun2000.PV2_I_A;

                    sun2000.PV3_U_V = (double)_32000[20] / 10;
                    sun2000.PV3_I_A = (double)_32000[21] / 100;
                    sun2000.PV3_P_W = sun2000.PV3_U_V * sun2000.PV3_I_A;

                    sun2000.PV4_U_V = (double)_32000[22] / 10;
                    sun2000.PV4_I_A = (double)_32000[23] / 100;
                    sun2000.PV4_P_W = sun2000.PV4_U_V * sun2000.PV4_I_A;

                    sun2000.PV_P_kW = (double)(_32000[64] + _32000[65]) / 1000;

                    sun2000.U_L1L2_V = (double)_32000[66] / 10;
                    sun2000.U_L2L3_V = (double)_32000[67] / 10;
                    sun2000.U_L1L3_V = (double)_32000[68] / 10;

                    sun2000.U_L1_V = (double)_32000[69] / 10;
                    sun2000.U_L2_V = (double)_32000[70] / 10;
                    sun2000.U_L3_V = (double)_32000[71] / 10;

                    sun2000.I_L1_A = (double)(_32000[72] + _32000[73])/1000;
                    sun2000.I_L2_A = (double)(_32000[74] + _32000[75]) / 1000;
                    sun2000.I_L3_A = (double)(_32000[76] + _32000[77]) / 1000;

                    sun2000.P_peak_kW = (double)(_32000[78] + _32000[79]) / 1000;
                    sun2000.P_active_kW = (double)(_32000[80] + _32000[81]) / 1000;
                    sun2000.P_reactive_kVar = (double)(_32000[82] + _32000[83]) / 1000;
                    sun2000.PowerFactor = (double)_32000[84] / 1000;
                    sun2000.Frequency_Hz = (double)_32000[85] / 100;
                    sun2000.N_Proz = (double)_32000[86] / 100;
                    sun2000.Temp_C = (double)_32000[87] / 10;
                    sun2000.Insulation_ohm = (double)_32000[88] / 1000;

                    sun2000.Status = (ushort)_32000[89];
                    sun2000.StatusText = ConverterSun2000.GetStatus(sun2000.Status);
                    sun2000.Fault = _32000[90];

                    sun2000.StartupTime = UnixTimeSpampIntToDateTime(_32000[91], _32000[92]);
                    sun2000.ShutdownTime = UnixTimeSpampIntToDateTime(_32000[93], _32000[94]);

                    sun2000.P_accum_kWh = ConverterIntToDouble(_32000[106], _32000[107]) / 100;
                    sun2000.Tot_DC_In_Power_kWh = ConverterIntToDouble(_32000[108], _32000[109]) / 100;


                    sun2000.Cur_Elec_Gen_Stat_Time_s = UnixTimeSpampIntToDateTime(_32000[110], _32000[111]);

                    sun2000.P_hour_kWh = ConverterIntToDouble(_32000[112], _32000[113]) / 100;
                    sun2000.P_daily_kWh = ConverterIntToDouble(_32000[114], _32000[115]) / 100;
                    sun2000.P_monthly_kWh = ConverterIntToDouble(_32000[116], _32000[117]) / 100;
                    sun2000.P_yearly_kWh = ConverterIntToDouble(_32000[118], _32000[119]) / 100;

                    int[] _32324 = ReadModbus(32324, 4);
                    sun2000.P_MPPT1_Tot_kW = (double)(_32324[0] + _32324[1]) / 1000;
                    sun2000.P_MPPT2_Tot_kW = (double)(_32324[2] + _32324[3]) / 1000;

                    int[] _40122 = ReadModbus(40122, 5);
                    sun2000.PowerFactor_comp = (double)_40122[0] / 1000;
                    sun2000.PowerFactor_compQ_S = (double)_40122[1] / 1000;
                    sun2000.Derating_Proz = (double)_40122[2] / 10;
                    sun2000.Derating_W = (double)(_40122[3] + _40122[4]) / 10000;


                    int[] _40200 = ReadModbus(40200, 2);
                    sun2000.Power_on = _40200[0];
                    sun2000.Power_off = _40200[1];

                    /*
                   //Statische Werte
                   int[] _30073 = ReadModbus(30073, 10);

                   sun2000.Pn_kW = (double)(_30073[0] + _30073[1] * 10000) / 10000;
                   sun2000.Pmax_kW = (double)(_30073[2] + _30073[3] * 10000) / 10000;
                   sun2000.Smax_kVA = (double)(_30073[4] + _30073[5] * 10000) / 10000;
                   sun2000.Qmax_kVar = (double)(_30073[6] + _30073[7] * 10000) / 10000;
                   sun2000.Qgrid_kVar = (double)(_30073[8] + _30073[9] * 10000) / 10000;


                   int[] _42000 = ReadModbus(42000, 1);

                   sun2000.GridCode = _42000[0];


                   int[] _43006 = ReadModbus(43006, 1);

                   sun2000.TimeZone_min = _43006[0];
                   */
                }
            }
            catch (Exception e)
            {
                Logger.Logger.WriteSyslog("Fehler ModbusSun2000: " + e, "error");
                _modbusClient.Disconnect();
            }
        }

        public static void WriteDateTimeToSun2000()
        {
            int num = DateTimeToUnixTimeStampDouble(DateTime.Now);
            int[] intDateTime = new int[2];
            intDateTime[1] = (short)(num & 0xFFFF); // Niedrigere 16 Bits extrahieren
            intDateTime[0] = (short)((num >> 16) & 0xFFFF); // Höhere 16 Bits extrahieren und rechts verschieben
            _modbusClient.WriteMultipleRegisters(40000, intDateTime);
            Console.WriteLine(UnixTimeStampToDateTime(ReadModbusInt(40000, 2))[0]);
        }
        public static DateTime UnixTimeSpampIntToDateTime(int int1, int int2)
        {
            int[] result = new[] { int1, int2 };
            double[] doubleResult = new double[(result.Length / 2)];
            for (int i = 0; i < result.Length; i = i + 2)
            {
                int[] b = new[] { result[i + 1], result[i] };
                doubleResult[i / 2] = ModbusClient.ConvertRegistersToInt(b);
            }

            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            for (int i = 0; i < doubleResult.Length; i++)
            {
                dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
                dtDateTime = dtDateTime.AddSeconds(doubleResult[i]).ToLocalTime();
            }

            return dtDateTime;
        }

        public static DateTime[] UnixTimeStampToDateTime(double[] unixTimeStamp)
        {
            DateTime[] dtDateTimes = new DateTime[unixTimeStamp.Length];
            for (int i = 0; i < unixTimeStamp.Length; i++)
            {
                dtDateTimes[i] = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
                dtDateTimes[i] = dtDateTimes[i].AddSeconds(unixTimeStamp[i]).ToLocalTime();
            }

            return dtDateTimes;
        }

        public static DateTime[] UnixTimeStampIntToDateTime(int[] unixTimeStamp)
        {
            DateTime[] dtDateTimes = new DateTime[unixTimeStamp.Length];
            for (int i = 0; i < unixTimeStamp.Length; i++)
            {
                dtDateTimes[i] = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
                dtDateTimes[i] = dtDateTimes[i].AddSeconds(unixTimeStamp[i]).ToLocalTime();
            }

            return dtDateTimes;
        }

        public static int DateTimeToUnixTimeStampDouble(DateTime dateTime)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int)(dateTime - unixEpoch).TotalSeconds;
        }

        public static double[] ReadModbusLong(int startAddr, int quantity)
        {
            int[] result = _modbusClient.ReadHoldingRegisters(startAddr, quantity);
            double[] doubleResult = new double[(result.Length / 4)];
            for (int i = 0; i < result.Length; i = i + 4)
            {
                int[] b = new[] { result[i + 3], result[i + 2], result[i + 1], result[i] };
                doubleResult[i / 4] = ModbusClient.ConvertRegistersToLong(b);
            }

            return doubleResult;
        }

        public static double[] ReadModbusInt(int startAddr, int quantity)
        {
            int[] result = _modbusClient.ReadHoldingRegisters(startAddr, quantity);
            double[] doubleResult = new double[(result.Length / 2)];
            for (int i = 0; i < result.Length; i = i + 2)
            {
                int[] b = new[] { result[i + 1], result[i] };
                doubleResult[i / 2] = ModbusClient.ConvertRegistersToInt(b);
            }

            return doubleResult;
        }



        public static double[] ReadModbusByte(int startAddr, int quantity)
        {
            int[] result = _modbusClient.ReadHoldingRegisters(startAddr, quantity);
            double[] doubleResult = new double[(result.Length)];
            for (int i = 0; i < result.Length; i++)
            {
                doubleResult[i] = result[i];
            }

            return doubleResult;
        }

        public static int[] ReadModbus(int startAddr, int quantity)
        {
            int[] result = _modbusClient.ReadHoldingRegisters(startAddr, quantity);
            return result;
        }

        public static double ConverterIntToDouble(int a, int b)
        {
            return Convert.ToDouble((a << 16) | (ushort)b);
        }
    }
}
