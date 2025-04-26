using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Modbus.Converter
{
    public class ConverterSun2000
    {
        public static string GetStatus(ushort status)
        {
            switch (status)
            {
                case 0x000:
                    return "Standby: initializing";
                    break;
                case 0x0002:
                    return "Standby: detecting irradiation";
                    break;
                case 0x0003:
                    return "Standby: grid detecting";
                    break;
                case 0x0100:
                    return "Starting";
                    break;
                case 0x0200:
                    return "On-grid (Off-grid mode: running)";
                    break;
                case 0x0201:
                    return "Grid connection: power limited (Off-grid mode: running: power limited)";
                    break;
                case 0x0202:
                    return "Grid connection: self-derating (Off-grid mode: running: self-derating)";
                    break;
                case 0x0300:
                    return "Shutdown: fault";
                    break;
                case 0x0301:
                    return "Shutdown: command";
                    break;
                case 0x0302:
                    return "Shutdown: OVGR";
                    break;
                case 0x0303:
                    return "Shutdown: communication disconnected";
                    break;
                case 0x0304:
                    return "Shutdown: power limited";
                    break;
                case 0x0305:
                    return "Shutdown: manual startup required";
                    break;
                case 0x0306:
                    return "Shutdown: DC switches disconnected";
                    break;
                case 0x0307:
                    return "Shutdown: rapid cutoff";
                    break;
                case 0x0308:
                    return "Shutdown: input underpower";
                    break;
                case 0x0401:
                    return "Grid scheduling: cos F-P curve";
                    break;
                case 0x0402:
                    return "Grid scheduling: Q-U curve";
                    break;
                case 0x0403:
                    return "Grid scheduling: PF-U curve";
                    break;
                case 0x0404:
                    return "Grid scheduling: dry contact";
                    break;
                case 0x0405:
                    return "Grid scheduling: Q-P curve";
                    break;
                case 0x0500:
                    return "Spot-check ready";
                    break;
                case 0x0501:
                    return "Spot-checking";
                    break;
                case 0x0600:
                    return "Inspecting";
                    break;
                case 0x0700:
                    return "AFCI self check";
                    break;
                case 0x0800:
                    return "I-V scanning";
                    break;
                case 0x0900:
                    return "DC input detection";
                    break;
                case 0x0a00:
                    return "Running: off-grid charging";
                    break;
                case 0xa000:
                    return "Standby: no irradiation";
                    break;
                default:
                    return "NO STATUS";
                    break;
            }

        }

        public static string GetState1(int value)
        {

            string status = " ";

            if (Test_bit(value, 0))
                status += "standby | ";
            if (Test_bit(value, 1))
                status += "grid-connected | ";
            if (Test_bit(value, 2))
                status += "grid-connected normally | ";
            if (Test_bit(value, 3))
                status += "connection with derating due to power rationing | ";
            if (Test_bit(value, 4))
                status += "grid connection with derating due to internal causes of the solar inverter | ";
            if (Test_bit(value, 5))
                status += "normal stop | ";
            if (Test_bit(value, 6))
                status += "stop due to faults | ";
            if (Test_bit(value, 7))
                status += "stop due to power rationing | ";
            if (Test_bit(value, 8))
                status += "shutdown | ";
            if (Test_bit(value, 9))
                status += "spot check ";

            return status;

        }

        public static string GetState2(int value)
        {
            string status = " ";

            // Überprüfe das erste Bit
            bool bit0 = Test_bit(value, 0);
            switch (bit0)
            {
                case true:
                    status += "unlocked | ";
                    break;
                case false:
                    status += "locked | ";
                    break;
            }

            // Überprüfe das zweite Bit
            bool bit1 = Test_bit(value, 1);
            switch (bit1)
            {
                case true:
                    status += "connected | ";
                    break;
                case false:
                    status += "disconnected | ";
                    break;
            }

            // Überprüfe das dritte Bit
            bool bit2 = Test_bit(value, 2);
            switch (bit2)
            {
                case true:
                    status += "DSP collecting | ";
                    break;
                case false:
                    status += "DSP not collecting | ";
                    break;
            }

            return status;
        }

        public static string GetState3(int value)
        {
            string status = " ";

            // Überprüfe das erste Bit
            bool bit0 = Test_bit(value, 0);
            switch (bit0)
            {
                case true:
                    status += "off-grid | ";
                    break;
                case false:
                    status += "on-grid | ";
                    break;
            }

            // Überprüfe das zweite Bit
            bool bit1 = Test_bit(value, 1);
            switch (bit1)
            {
                case true:
                    status += "off-grid switch enable | ";
                    break;
                case false:
                    status += "off-grid switch disable | ";
                    break;
            }

            return status;
        }

        public static string GetAlarm1(int value)
        {
            string status = " ";

            if (Test_bit(value, 0))
                status += "High String Input Voltage | ";
            if (Test_bit(value, 1))
                status += "DC Arc Fault | ";
            if (Test_bit(value, 2))
                status += "String Reverse Connection | ";
            if (Test_bit(value, 3))
                status += "String Current Backfeed | ";
            if (Test_bit(value, 4))
                status += "Abnormal String Power | ";
            if (Test_bit(value, 5))
                status += "AFCI Self-Check Fail | ";
            if (Test_bit(value, 6))
                status += "Phase Wire Short-Circuited to PE | ";
            if (Test_bit(value, 7))
                status += "Grid Loss | ";
            if (Test_bit(value, 8))
                status += "Grid Undervoltage | ";
            if (Test_bit(value, 9))
                status += "Grid Overvoltage | ";
            if (Test_bit(value, 10))
                status += "Grid Volt. Imbalance | ";
            if (Test_bit(value, 11))
                status += "Grid Overfrequency | ";
            if (Test_bit(value, 12))
                status += "Grid Underfrequency | ";
            if (Test_bit(value, 13))
                status += "Unstable Grid Frequency | ";
            if (Test_bit(value, 14))
                status += "Output Overcurrent | ";
            if (Test_bit(value, 15))
                status += "Output DC Component Overhigh | ";

            return status;
        }

        public static string GetAlarm2(int value)
        {
            string status = " ";

            if (Test_bit(value, 0))
                status += "Abnormal Residual Current | ";
            if (Test_bit(value, 1))
                status += "Abnormal Grounding | ";
            if (Test_bit(value, 2))
                status += "Low Insulation Resistance | ";
            if (Test_bit(value, 3))
                status += "Overtemperature | ";
            if (Test_bit(value, 4))
                status += "Device Fault | ";
            if (Test_bit(value, 5))
                status += "Upgrade Failed or Version Mismatch | ";
            if (Test_bit(value, 6))
                status += "License Expired | ";
            if (Test_bit(value, 7))
                status += "Faulty Monitoring Unit | ";
            if (Test_bit(value, 8))
                status += "Faulty Power Collector | ";
            if (Test_bit(value, 9))
                status += "Battery abnormal | ";
            if (Test_bit(value, 10))
                status += "Active Islanding | ";
            if (Test_bit(value, 11))
                status += "Passive Islanding | ";
            if (Test_bit(value, 12))
                status += "Transient AC Overvoltage | ";
            if (Test_bit(value, 13))
                status += "Peripheral port short circuit | ";
            if (Test_bit(value, 14))
                status += "Churn output overload | ";
            if (Test_bit(value, 15))
                status += "Abnormal PV module configuration | ";

            return status;
        }
        public static string GetAlarm3(int value)
        {
            string status = " ";

            if (Test_bit(value, 0))
                status += "Optimizer fault | ";
            if (Test_bit(value, 1))
                status += "Built-in PID operation abnormal | ";
            if (Test_bit(value, 2))
                status += "High input string voltage to ground | ";
            if (Test_bit(value, 3))
                status += "External Fan Abnormal | ";
            if (Test_bit(value, 4))
                status += "Battery Reverse Connection | ";
            if (Test_bit(value, 5))
                status += "On-grid/Off-grid controller abnormal | ";
            if (Test_bit(value, 6))
                status += "PV String Loss | ";
            if (Test_bit(value, 7))
                status += "Internal Fan Abnormal | ";
            if (Test_bit(value, 8))
                status += "DC Protection Unit Abnormal | ";

            return status;
        }

        public static bool Test_bit(int value, int bitPosition)
        {
            return (value & (1 << bitPosition)) != 0;
        }
    }
}
