using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using HomeAutomation.Client.Context;

namespace HomeAutomation.Client.Backgroundworker
{
    public class LoopModbusMaster
    {
        private static BackgroundWorker _worker;
        public static bool ResetCount = false;
        private static ModbusServer modbusServer = new ModbusServer();
        public static double EM24_U1;
        public static double EM24_U2;
        public static double EM24_U3;

        public static double EM24_I1;
        public static double EM24_I2;
        public static double EM24_I3;

        public static double EM24_P1;
        public static double EM24_P2;
        public static double EM24_P3;

        public static double EM24_E1;
        public static double EM24_E2;
        public static double EM24_E3;

        public static double EM24_EtotPlusKwh;
        public static double EM24_EtotMinusKwh;
        public static double EM24_EtotPlusKvarh;
        public static double EM24_EtotMinusKvarh;

        public static double EM24_PTotal;

        public static double EM24_Frequenz;

        public static double EM24_U1_U2;
        public static double EM24_U2_U3;
        public static double EM24_U3_U1;

        public static double EM24_VA1;
        public static double EM24_VA2;
        public static double EM24_VA3;

        public static double EM24_VAR1;
        public static double EM24_VAR2;
        public static double EM24_VAR3;

        public static double EM24_V_LN_AVG;
        public static double EM24_V_LL_AVG;

        public static double EM24_QTotal;
        public static double EM24_STotal;

        public static double EM24_PF_L1;
        public static double EM24_PF_L2;
        public static double EM24_PF_L3;
        public static double EM24_PF_SUM;

        public void Execute()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += worker_DoWorkLoop;
            _worker.RunWorkerCompleted += worker_RunWorkerCompletedLoop;
            _worker.ProgressChanged += worker_ProgressChanged;

            modbusServer.Listen();

            _worker.RunWorkerAsync();
            _worker.WorkerReportsProgress = true;

        }
        private static void worker_DoWorkLoop(object sender, DoWorkEventArgs e)
        {
            var time = DateTime.Now;
            var appStatusTask = AppCtx.ReadAppStatusTaskWithName("LoopModbusMaster");

            //Task OnOff
            if (appStatusTask.TaskOnOff == 0)
            {
                appStatusTask.CycleTime = (Convert.ToDouble(DateTime.Now.Ticks - time.Ticks)) / 10000;
                AppCtx.Update(appStatusTask);
                return;
            }

            appStatusTask.StartTime = DateTime.Now;

            try
            {
                ModbusServer.HoldingRegisters regs = modbusServer.holdingRegisters;
                regs[40961] = 0x07; // application set to H
                regs[771] = 8 * 256 + 1 * 256 + 1; // hardware version
                regs[773] = 8 * 256 + 6 * 256 + 1; // firmware version
                regs[4099] = 0x00; // phase config: 3P.n
                regs[41217] = 0x03; // Front selector status
                regs[20481] = 21359; // serial
                regs[20482] = 27745; // serial
                regs[20483] = 29270; // serial
                regs[20484] = 26981; // serial
                regs[20485] = 30551; // serial
                regs[20486] = 21041; // serial
                regs[20487] = 0; // serial


                Int32 value = Convert.ToInt32(EM24_U1 * 10);
                regs[1] = (Int16)(value & 0xFFFF);
                regs[2] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_U2 * 10);
                regs[3] = (Int16)(value & 0xFFFF);
                regs[4] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_U3 * 10);
                regs[5] = (Int16)(value & 0xFFFF);
                regs[6] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_U1_U2 * 10);
                regs[7] = (Int16)(value & 0xFFFF);
                regs[8] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_U2_U3 * 10);
                regs[9] = (Int16)(value & 0xFFFF);
                regs[10] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_U3_U1 * 10);
                regs[11] = (Int16)(value & 0xFFFF);
                //regs[12] = (Int16)(value >> 16); //Ist gleich Modell nummer, wenn das aktiv ist funktioniert es nicht
                
                regs[12] = 1650; // model: 1650->EM24DINAV23XE1PFB 1648->EM24DINAV23XE1X

                value = Convert.ToInt32(EM24_I1 * 1000);
                regs[13] = (Int16)(value & 0xFFFF);
                regs[14] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_I2 * 1000);
                regs[15] = (Int16)(value & 0xFFFF);
                regs[16] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_I3 * 1000);
                regs[17] = (Int16)(value & 0xFFFF);
                regs[18] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_P1 * 10);
                regs[19] = (Int16)(value & 0xFFFF);
                regs[20] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_P2 * 10);
                regs[21] = (Int16)(value & 0xFFFF);
                regs[22] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_P3 * 10);
                regs[23] = (Int16)(value & 0xFFFF);
                regs[24] = (Int16)(value >> 16);

                
                value = Convert.ToInt32(EM24_VA1 * 10);
                regs[25] = (Int16)(value & 0xFFFF);
                regs[26] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_VA2 * 10);
                regs[27] = (Int16)(value & 0xFFFF);
                regs[28] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_VA3 * 10);
                regs[29] = (Int16)(value & 0xFFFF);
                regs[30] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_VAR1 * 10);
                regs[31] = (Int16)(value & 0xFFFF);
                regs[32] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_VAR2 * 10);
                regs[33] = (Int16)(value & 0xFFFF);
                regs[34] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_VAR3 * 10);
                regs[35] = (Int16)(value & 0xFFFF);
                regs[36] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_V_LN_AVG * 10);
                regs[37] = (Int16)(value & 0xFFFF);
                regs[38] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_V_LL_AVG * 10);
                regs[39] = (Int16)(value & 0xFFFF);
                regs[40] = (Int16)(value >> 16);
                
                value = Convert.ToInt32(EM24_PTotal * 10);
                regs[41] = (Int16)(value & 0xFFFF);
                regs[42] = (Int16)(value >> 16);
                
                value = Convert.ToInt32(EM24_QTotal * 10);
                regs[43] = (Int16)(value & 0xFFFF);
                regs[44] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_STotal * 10);
                regs[45] = (Int16)(value & 0xFFFF);
                regs[46] = (Int16)(value >> 16);
                
                regs[47] = (short)(EM24_PF_L1 * 1000);
                regs[48] = (short)(EM24_PF_L2 * 1000);
                regs[49] = (short)(EM24_PF_L3 * 1000);
                regs[50] = (short)(EM24_PF_SUM * 1000);

                regs[51] = 0; // PhaseSequence 
                regs[52] = (short)(EM24_Frequenz * 10); // frequency *10

                value = Convert.ToInt32(EM24_EtotPlusKwh * 10);
                regs[53] = (Int16)(value & 0xFFFF);
                regs[54] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_EtotPlusKvarh * 10);
                regs[55] = (Int16)(value & 0xFFFF);
                regs[56] = (Int16)(value >> 16);

                //TEST
                value = Convert.ToInt32(EM24_EtotPlusKwh * 10);
                regs[61] = (Int16)(value & 0xFFFF);
                regs[62] = (Int16)(value >> 16);

                //TEST
                value = Convert.ToInt32(EM24_EtotPlusKvarh * 10);
                regs[63] = (Int16)(value & 0xFFFF);
                regs[64] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_E1 * 10);
                regs[65] = (Int16)(value & 0xFFFF);
                regs[66] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_E2 * 10);
                regs[67] = (Int16)(value & 0xFFFF);
                regs[68] = (Int16)(value >> 16);
                value = Convert.ToInt32(EM24_E3 * 10);
                regs[69] = (Int16)(value & 0xFFFF);
                regs[70] = (Int16)(value >> 16);

                //TEST
                value = Convert.ToInt32(EM24_EtotPlusKvarh * 10);
                regs[71] = (Int16)(value & 0xFFFF);
                regs[72] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_EtotMinusKwh * -10);
                regs[79] = (Int16)(value & 0xFFFF);
                regs[80] = (Int16)(value >> 16);

                value = Convert.ToInt32(EM24_EtotMinusKvarh * -10);
                regs[81] = (Int16)(value & 0xFFFF);
                regs[82] = (Int16)(value >> 16);






            }
            catch (Exception a)
            {
                appStatusTask.StatusDevice = 0;
                Logger.Logger.WriteSyslog("LoopModbusMaster " + a, "error");
                if (appStatusTask.CountsError == null)
                {
                    appStatusTask.CountsError = 0;
                }
                if (ResetCount)
                {
                    appStatusTask.CountsError = 0;
                    ResetCount = false;
                }
                else
                {
                    appStatusTask.CountsError++;
                }
            }
            appStatusTask.CycleTime = (Convert.ToDouble(DateTime.Now.Ticks - time.Ticks)) / 10000;
            AppCtx.Update(appStatusTask);
        }
        private static void worker_RunWorkerCompletedLoop(object sender, RunWorkerCompletedEventArgs e)
        {
            _worker.RunWorkerAsync();
        }

        private static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
    }
}

