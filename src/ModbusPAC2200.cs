using System;
using EasyModbus;
using HomeAutomation.Modbus.Model;

namespace HomeAutomation.Modbus
{
    public class ModbusPAC2200
    {
        public static string ModbusIpPAC2200;
        public static PAC2200 ValuesPAC2200 = new PAC2200();
        private static ModbusClient _modbusClient = new ModbusClient();
        public static bool ModbusPAC2200Connected;

        public static PAC2200 ReadEnergyMeter()
        {
            _modbusClient.IPAddress = ModbusIpPAC2200;
            _modbusClient.Port = 502;

            try
            {
                if (!_modbusClient.Connected)
                {
                    ModbusPAC2200Connected = false;
                    _modbusClient.Connect();
                }

                if (_modbusClient.Connected)
                {
                    ModbusPAC2200Connected = true;
                    ValuesPAC2200.Date = UnixTimeStampToDateTime(ReadModbusInt(30001, 2))[0];

                    double[] zaehlerstandBezug = ReadModbusLong(801, 4);
                    ValuesPAC2200.ZaehlerstandTotKWhBezug = zaehlerstandBezug[0] / 1000;

                    double[] frequenz = ReadModbusFloat(55, 2);
                    ValuesPAC2200.Frequenz = frequenz[0];

                    double[] zaehlerstandAbgabe = ReadModbusLong(809, 4);
                    ValuesPAC2200.ZaehlerstandTotKWhAbgabe = zaehlerstandAbgabe[0] / 1000;

                    double[] aktLeistung = ReadModbusFloat(19, 24);
                    ValuesPAC2200.ScheinLeistungL1VA = aktLeistung[0];
                    ValuesPAC2200.ScheinLeistungL2VA = aktLeistung[1];
                    ValuesPAC2200.ScheinLeistungL3VA = aktLeistung[2];
                    ValuesPAC2200.WirkLeistungL1W = aktLeistung[3];
                    ValuesPAC2200.WirkLeistungL2W = aktLeistung[4];
                    ValuesPAC2200.WirkLeistungL3W = aktLeistung[5];
                    ValuesPAC2200.BlindLeistungL1VAR = aktLeistung[6];
                    ValuesPAC2200.BlindLeistungL2VAR = aktLeistung[7];
                    ValuesPAC2200.BlindLeistungL3VAR = aktLeistung[8];


                    double[] aktLeistungGes = ReadModbusFloat(63, 6);
                    ValuesPAC2200.ScheinLeistungTotVA = aktLeistungGes[0];
                    ValuesPAC2200.WirkLeistungTotW = aktLeistungGes[1];
                    ValuesPAC2200.BlindLeistungTotVA = aktLeistungGes[2];

                    double[] aktSpannung = ReadModbusFloat(1, 6);
                    ValuesPAC2200.SpannungL1V = aktSpannung[0];
                    ValuesPAC2200.SpannungL2V = aktSpannung[1];
                    ValuesPAC2200.SpannungL3V = aktSpannung[2];

                    double[] aktStrom = ReadModbusFloat(13, 6);
                    ValuesPAC2200.StromL1A = aktStrom[0];
                    ValuesPAC2200.StromL2A = aktStrom[1];
                    ValuesPAC2200.StromL3A = aktStrom[2];
                    ValuesPAC2200.StromTotA = aktStrom[0] + aktStrom[1] + aktStrom[2];
                }
            }
            catch (Exception e)
            {
                Logger.Logger.WriteSyslog("Fehler ModbusPAC2200: " + e, "error");
                _modbusClient.Disconnect();
            }
            return ValuesPAC2200;
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

        public static double[] ReadModbusFloat(int startAddr, int quantity)
        {
            int[] result = _modbusClient.ReadHoldingRegisters(startAddr, quantity);
            double[] doubleResult = new double[(result.Length / 2)];
            for (int i = 0; i < result.Length; i = i + 2)
            {
                int[] res = { result[i + 1], result[i] };
                doubleResult[i / 2] = Convert.ToDouble(ModbusClient.ConvertRegistersToFloat(res));
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

        public static double[] ReadModbusLong(int startAddr, int quantity)
        {
            int[] result = _modbusClient.ReadHoldingRegisters(startAddr, quantity);
            double[] doubleResult = new double[(result.Length / 4)];
            for (int i = 0; i < result.Length; i = i + 4)
            {
                int[] res = { result[i + 3], result[i + 2], result[i + 1], result[i] };
                doubleResult[i / 2] = Convert.ToDouble(ModbusClient.ConvertRegistersToDouble(res));
            }
            return doubleResult;
        }
    }
}
