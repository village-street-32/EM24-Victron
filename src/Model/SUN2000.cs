using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Modbus.Model
{
    public class SUN2000
    {
        /// <summary>
        /// Insulation	32088	1	 Insulation resistance            	1000	 U16  	 MΩ 
        /// </summary>
        public double Insulation_ohm { get; set; }

        /// <summary>
        /// State1	32000	1	 Status 1                         	1	 Bit16	 
        /// </summary>
        public int State1 { get; set; }
        public string State1Text { get; set; }

        /// <summary>
        /// State2	32002	1	 Status 2                         	1	 Bit16	 
        /// </summary>
        public int State2 { get; set; }
        public string State2Text { get; set; }

        /// <summary>
        /// State3	32003	1	 Status 3                         	1	 Bit16	 
        /// </summary>
        public int State3 { get; set; }
        public string State3Text { get; set; }

        /// <summary>
        /// Alarm1	32008	1	 Alarm 1                          	1	 Bit16		 
        /// </summary>
        public int Alarm1 { get; set; }
        public string Alarm1Text { get; set; }

        /// <summary>
        /// Alarm2	32009	1	 Alarm 2                          	1	 Bit16		 
        /// </summary>
        public int Alarm2 { get; set; }
        public string Alarm2Text { get; set; }

        /// <summary>
        /// Alarm3	32010	1	 Alarm 3                          	1	 Bit16		 
        /// </summary>
        public int Alarm3 { get; set; }
        public string Alarm3Text { get; set; }

        /// <summary>
        /// Status	32089	1	 Device status                    	1	 U16  		 
        /// </summary>
        public ushort Status { get; set; }
        public string StatusText { get; set; }

        /// <summary>
        /// Fault	32090	1	 Fault code                       	1	 U16  	  		 
        /// </summary>
        public int Fault { get; set; }

        /// <summary>
        /// PV1_U	32016	1	 PV1 voltage                      	10	 I16  	 V 	  		 
        /// </summary>
        public double PV1_U_V { get; set; }

        /// <summary>
        /// PV1_I	32017	1	 PV1 current                      	100	 I16  	 A  	  		 
        /// </summary>
        public double PV1_I_A { get; set; }
        public double PV1_P_W { get; set; }

        /// <summary>
        /// PV2_U	32018	1	 PV2 voltage                      	10	 I16  	 V 	  		 
        /// </summary>
        public double PV2_U_V { get; set; }

        /// <summary>
        /// PV_I2	32019	1	 PV2 current                      	100	 I16  	 A  	  		 
        /// </summary>
        public double PV2_I_A { get; set; }
        public double PV2_P_W { get; set; }

        /// <summary>
        /// PV2_U	32020	1	 PV2 voltage                      	10	 I16  	 V 	  		 
        /// </summary>
        public double PV3_U_V { get; set; }

        /// <summary>
        /// PV_I2	32021	1	 PV2 current                      	100	 I16  	 A  	  		 
        /// </summary>
        public double PV3_I_A { get; set; }
        public double PV3_P_W { get; set; }

        /// <summary>
        /// PV2_U	32022	1	 PV2 voltage                      	10	 I16  	 V 	  		 
        /// </summary>
        public double PV4_U_V { get; set; }

        /// <summary>
        /// PV_I2	32023	1	 PV2 current                      	100	 I16  	 A  	  		 
        /// </summary>
        public double PV4_I_A { get; set; }
        public double PV4_P_W { get; set; }

        /// <summary>
        /// PV_P	32064	2	 Input power                      	1000	 I32  	 kW  	  		 
        /// </summary>
        public double PV_P_kW { get; set; }

        /// <summary>
        /// U_A-B	32066	1	 Line Voltage A-B                 	10	 U16  	 V  	  		 
        /// </summary>
        public double U_L1L2_V { get; set; }

        /// <summary>
        /// U_B-C	32067	1	 Line Voltage B-C                 	10	 U16  	 V  	  		 
        /// </summary>
        public double U_L2L3_V { get; set; }

        /// <summary>
        /// U_C-A	32068	1	 Line Voltage C-A                 	10	 U16  	 V  	  		 
        /// </summary>
        public double U_L1L3_V { get; set; }

        /// <summary>
        /// U_A		32069	1	 Phase Voltage A                  	10	 U16  	 V    	  		 
        /// </summary>
        public double U_L1_V { get; set; }

        /// <summary>
        /// U_B		32070	1	 Phase Voltage B                  	10	 U16  	 V    	  		 
        /// </summary>
        public double U_L2_V { get; set; }

        /// <summary>
        /// U_C		32071	1	 Phase Voltage C                  	10	 U16  	 V    	  		 
        /// </summary>
        public double U_L3_V { get; set; }

        /// <summary>
        /// I_A		32072	2	 Phase Current A                  	1000	 I32  	 A    	  		 
        /// </summary>
        public double I_L1_A { get; set; }

        /// <summary>
        /// I_B		32074	2	 Phase Current B                  	1000	 I32  	 A   	  		 
        /// </summary>
        public double I_L2_A { get; set; }

        /// <summary>
        /// I_C		32076	2	 Phase Current C                  	1000	 I32  	 A   	  		 
        /// </summary>
        public double I_L3_A { get; set; }

        /// <summary>
        /// P_peak	32078	2	 Peak Power                       	1000	 I32  	 kW    	  		 
        /// </summary>
        public double P_peak_kW { get; set; }

        /// <summary>
        /// P_active	32080	2	 Active power                     	1000	 I32  	 kW    	  		 
        /// </summary>
        public double P_active_kW { get; set; }

        /// <summary>
        /// P_reactive	32082	2	 Reactive power                   	1000	 I32  	 kVar    	  		 
        /// </summary>
        public double P_reactive_kVar { get; set; }

        /// <summary>
        /// PF		32084	1	 Power Factor                     	1000	 I16    	  		 
        /// </summary>
        public double PowerFactor { get; set; }

        /// <summary>
        /// Frequency	32085	1	 Grid frequency                   	100	 U16  	 Hz    	  		 
        /// </summary>
        public double Frequency_Hz { get; set; }

        /// <summary>
        /// η		32086	1	 Efficiency                       	100	 U16  	 %     	  		 
        /// </summary>
        public double N_Proz { get; set; }

        /// <summary>
        /// Temp	32087	1	 Internal temperature             	10	 I16  	 °C     	  		 
        /// </summary>
        public double Temp_C { get; set; }

        /// <summary>
        /// Start	32091	2	 Startup time                     	1	 U32  	 DateTime  
        /// </summary>
        public DateTime StartupTime { get; set; }

        /// <summary>
        /// Shutdown	32093	2	 Shutdown time                    	1	 U32  	 DateTime 
        /// </summary>
        public DateTime ShutdownTime { get; set; }

        /// <summary>
        /// P_accum	32106	2	 Accumulated energy yield         	100	 U32  	 kWh     	  		 
        /// </summary>
        public double P_accum_kWh { get; set; }

        /// <summary>
        /// Tot_DC_In_Power	32108	2	 Total DC Input Power         	100	 U32  	 kWh     	  		 
        /// </summary>
        public double Tot_DC_In_Power_kWh { get; set; }

        /// <summary>
        /// Cur_Elec_Gen_Stat_Time	32110	2	 Current Electricity Generation Statistic Time         	100	 DateTime  	 s     	  		 
        /// </summary>
        public DateTime Cur_Elec_Gen_Stat_Time_s { get; set; }

        /// <summary>
        /// P_Hour_energy	32112	2	 Hourly Yield Energy         	100	 U32  	 kWh     	  		 
        /// </summary>
        public double P_hour_kWh { get; set; }

        /// <summary>
        /// Daily_energy	32114	2	 Daily Yield Energy         	100	 U32  	 kWh     	  		 
        /// </summary>
        public double P_daily_kWh { get; set; }

        /// <summary>
        /// P_monthly	32116	2	 Daily energy yield               	100	 U32  	 kWh      	  		 
        /// </summary>
        public double P_monthly_kWh { get; set; }

        /// <summary>
        /// P_yearly	32118	2	 Yearly energy yield               	100	 U32  	 kWh      	  		 
        /// </summary>
        public double P_yearly_kWh { get; set; }

        /// <summary>
        /// P_MPPT1_Tot	32324	2	 Total input Power of MPPT1        1000	 U32  	 kW      	  		 
        /// </summary>
        public double P_MPPT1_Tot_kW { get; set; }

        /// <summary>
        /// P_MPPT2_Tot	32326	2	 Total input Power of MPPT2        1000	 U32  	 kW      	  		 
        /// </summary>
        public double P_MPPT2_Tot_kW { get; set; }

        /// <summary>
        /// Time		40000	2	 Current Time                  1	 U32	    	   		 
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// PF_comp	40122	1	 Reactive power compensation      	1000	 I16       	   		 
        /// </summary>
        public double PowerFactor_comp { get; set; }

        /// <summary>
        /// Q/S		40123	1	 Reactive power compensation(Q/S) 	1000	 I16      	   		 
        /// </summary>
        public double PowerFactor_compQ_S { get; set; }

        /// <summary>
        /// Derating	40125	1	 Active power derating percent    	10	 U16     	   		 
        /// </summary>
        public double Derating_Proz { get; set; }

        /// <summary>
        /// Derating_w	40126	2	 Active power derating            	1	 U32  	 W     	   		 
        /// </summary>
        public double Derating_W { get; set; }

        /// <summary>
        /// Power_on	40200	1	 Power on                         	1	 U16  	    	   		 
        /// </summary>
        public int Power_on { get; set; }

        /// <summary>
        /// Power_off	40201	1	 Power off                        	1	 U16 	    	   		 
        /// </summary>
        public int Power_off { get; set; }


        /*Static Values
        //
          /// <summary>
        /// Grid	42000	1	 Grid Code                        	1	 U16 	    	   		 
        /// </summary>
        public int GridCode { get; set; }

        /// <summary>
        /// TZ		43006	1	 Time Zone                        	1	 I16  	 min	    	   		 
        /// </summary>
        public int TimeZone_min { get; set; }

          /// <summary>
        /// Pn		30073	2	 Rated power                      	1000	 U32  	 kW 
        /// </summary>
        public double Pn_kW { get; set; }

        /// <summary>
        /// Pmax	30075	2	 Maximum active power             	1000	 U32  	 kW  
        /// </summary>
        public double Pmax_kW { get; set; }

        /// <summary>
        /// Smax	30077	2	 Maximum apparent power           	1000	 U32  	 kVA 
        /// </summary>
        public double Smax_kVA { get; set; }

        /// <summary>
        /// Qmax	30079	2	 Maximum reactive power to grid   	1000	 I32  	 kVar 
        /// </summary>
        public double Qmax_kVar { get; set; }

        /// <summary>
        /// Qgrid	30081	2	 Maximum reactive power from grid 	1000	 I32  	 kVar 
        /// </summary>
        public double Qgrid_kVar { get; set; }



        PowerMeter
        /// <summary>
        /// M_status	37100	1	 Meter status                     	1	 U16    	  		 
        /// </summary>
        public int MeterStatus { get; set; }

        /// <summary>
        /// M_check	37138	1	 Meter detection result           	1	 U16   	  		 
        /// </summary>
        public int MeterDetectionResult { get; set; }

        /// <summary>
        /// M_		37125	1	 Meter                        		1	 U16    	  		 
        /// </summary>
        public int Meter { get; set; }

        /// <summary>
        /// M_P		37113	2	 Active Grid power                	1	 I32  	 W     	  		 
        /// </summary>
        public int M_P { get; set; }

        /// <summary>
        /// M_Pr	37115	2	 Active Grid reactive power       	1	 I32  	 VAR     	  		 
        /// </summary>
        public int M_Pr { get; set; }

        /// <summary>
        /// M_A-U	37101	2	 Active Grid A Voltage            	10	 I32  	 V     	  		 
        /// </summary>
        public int M_U_L1 { get; set; }

        /// <summary>
        /// M_B-U	37103	2	 Active Grid B Voltage            	10	 I32  	 V     	  		 
        /// </summary>
        public int M_U_L2 { get; set; }

        /// <summary>
        /// M_C-U	37105	2	 Active Grid C Voltage            	10	 I32  	 V   	  		 
        /// </summary>
        public int M_U_L3 { get; set; }

        /// <summary>
        /// M_A-I	37107	2	 Active Grid A Current            	100	 I32  	 I  	  		 
        /// </summary>
        public int M_A_L1 { get; set; }

        /// <summary>
        /// M_B-I	37109	2	 Active Grid B Current            	100	 I32  	 I 	  		 
        /// </summary>
        public int M_A_L2 { get; set; }

        /// <summary>
        /// M_C-I	37111	2	 Active Grid C Current            	100	 I32  	 I 	  		 
        /// </summary>
        public int M_A_L3 { get; set; }

        /// <summary>
        /// M_PF	37117	1	 Active Grid PF                   	1000	 I16  	   		 
        /// </summary>
        public int M_ActiveGridPowerFactor { get; set; }

        /// <summary>
        /// M_Freq	37118	1	 Active Grid Frequency            	100	 I16  	 Hz    	   		 
        /// </summary>
        public int M_ActiveGridFrequency { get; set; }

        /// <summary>
        /// M_PExp	37119	2	 Grid Exported Energy             	100	 I32  	 kWh     	   		 
        /// </summary>
        public int M_PExp { get; set; }

        /// <summary>
        /// M_U_AB	37126	2	 Active Grid A-B Voltage          	10	 I32  	 V      	   		 
        /// </summary>
        public int M_U_L1L2 { get; set; }

        /// <summary>
        /// M_U_BC	37128	2	 Active Grid B-C Voltage          	10	 I32  	 V      	   		 
        /// </summary>
        public int M_U_L2L3 { get; set; }

        /// <summary>
        /// M_U_CA	37130	2	 Active Grid C-A Voltage          	10	 I32  	 V     	   		 
        /// </summary>
        public int M_U_L1L3 { get; set; }

        /// <summary>
        /// M_A-P	37132	2	 Active Grid A power              	1	 I32  	 W      	   		 
        /// </summary>
        public int M_P_L1 { get; set; }

        /// <summary>
        /// M_B-P	37134	2	 Active Grid B power              	1	 I32  	 W       	   		 
        /// </summary>
        public int M_P_L2 { get; set; }

        /// <summary>
        /// M_C-P	37136	2	 Active Grid C power              	1	 I32  	 W       	   		 
        /// </summary>
        public int M_P_L3 { get; set; }

        /// <summary>
        /// M_PTot	37121	2	 Grid Accumulated Energy          	100	 U32  	 kWh       	   		 
        /// </summary>
        public int M_PTot { get; set; }

        /// <summary>
        /// M_RPTot	37123	2	 Grid Accumulated Reactive Energy 	100	 I32  	 KVarh      	   		 
        /// </summary>
        public int M_RPTot { get; set; }

        /// <summary>
        /// ModelID	30070	1	 Model ID                         	1	 U16      	   		 
        /// </summary>
        public int M_ModelID { get; set; }

        /// <summary>
        /// MPPT_N	30072	1	 MPPT Number                      	1	 U16       	   		 
        /// </summary>
        public int M_MPPT_N { get; set; }
        */

    }
}
