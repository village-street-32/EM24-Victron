using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HomeAutomation.Modbus.Model;

namespace HomeAutomation.Modbus
{
    public class Pac2200_RESTAPI
    {
        public PAC2200RESTAPI ValuesPAC2200 = new PAC2200RESTAPI();
        class ApiResponse
        {
            public JObject INST_VALUES { get; set; }
            public JObject COUNTER { get; set; }
            public JObject DAILYPROFILE { get; set; }
        }

        public PAC2200RESTAPI ReadEnergyMeterRestApi(string ip)
        {
            try
            {
                string apiUrl = "http://"+ ip +"/data.json?type=INST";
                ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(GetDataFromApi(apiUrl));
                JObject instValues = response.INST_VALUES;

                var localTimeValue = instValues["LOCAL_TIME"].Value<string>();
                string dateFormat = "MM/dd/yyyy HH:mm:ssK";
                ValuesPAC2200.Date = DateTime.ParseExact(localTimeValue, dateFormat, System.Globalization.CultureInfo.InvariantCulture);

                ValuesPAC2200.SpannungL1V = instValues["V_L1"]["value"].Value<double>();
                ValuesPAC2200.SpannungL2V = instValues["V_L2"]["value"].Value<double>();
                ValuesPAC2200.SpannungL3V = instValues["V_L3"]["value"].Value<double>();

                ValuesPAC2200.SpannungL12V = instValues["V_L12"]["value"].Value<double>();
                ValuesPAC2200.SpannungL23V = instValues["V_L23"]["value"].Value<double>();
                ValuesPAC2200.SpannungL31V = instValues["V_L31"]["value"].Value<double>();

                ValuesPAC2200.Spannung_LN_AVG = instValues["V_LN_AVG"]["value"].Value<double>();
                ValuesPAC2200.Spannung_LL_AVG = instValues["V_LL_AVG"]["value"].Value<double>();

                ValuesPAC2200.StromL1A = instValues["I_L1"]["value"].Value<double>();
                ValuesPAC2200.StromL2A = instValues["I_L2"]["value"].Value<double>();
                ValuesPAC2200.StromL3A = instValues["I_L3"]["value"].Value<double>();
                ValuesPAC2200.StromNA = instValues["I_N_SEL"]["value"].Value<double>();
                ValuesPAC2200.StromTotA = ValuesPAC2200.StromL1A + ValuesPAC2200.StromL2A + ValuesPAC2200.StromL3A;

                ValuesPAC2200.ScheinLeistungL1VA = instValues["VA_L1"]["value"].Value<double>() * 1000;
                ValuesPAC2200.ScheinLeistungL2VA = instValues["VA_L2"]["value"].Value<double>() * 1000;
                ValuesPAC2200.ScheinLeistungL3VA = instValues["VA_L3"]["value"].Value<double>() * 1000;
                ValuesPAC2200.WirkLeistungL1W = instValues["P_L1"]["value"].Value<double>() * 1000;
                ValuesPAC2200.WirkLeistungL2W = instValues["P_L2"]["value"].Value<double>() * 1000;
                ValuesPAC2200.WirkLeistungL3W = instValues["P_L3"]["value"].Value<double>() * 1000;
                ValuesPAC2200.BlindLeistungL1VAR = instValues["VARQ1_L1"]["value"].Value<double>() * 1000;
                ValuesPAC2200.BlindLeistungL2VAR = instValues["VARQ1_L2"]["value"].Value<double>() * 1000;
                ValuesPAC2200.BlindLeistungL3VAR = instValues["VARQ1_L3"]["value"].Value<double>() * 1000;
                ValuesPAC2200.LeistungsfaktorL1 = instValues["PF_L1"]["value"].Value<double>();
                ValuesPAC2200.LeistungsfaktorL2 = instValues["PF_L2"]["value"].Value<double>();
                ValuesPAC2200.LeistungsfaktorL3 = instValues["PF_L3"]["value"].Value<double>();

                ValuesPAC2200.ScheinLeistungTotVA = instValues["VA_SUM"]["value"].Value<double>() * 1000;
                ValuesPAC2200.WirkLeistungTotW = instValues["P_SUM"]["value"].Value<double>() * 1000;
                ValuesPAC2200.BlindLeistungTotVAR = instValues["VARQ1_SUM"]["value"].Value<double>() * 1000;
                ValuesPAC2200.Leistungsfaktor = instValues["PF_SUM"]["value"].Value<double>();

                ValuesPAC2200.Frequenz = instValues["FREQ"]["value"].Value<double>();

                apiUrl = "http://" + ip + "/data.json?type=COUNTER";
                ApiResponse responseCounter = JsonConvert.DeserializeObject<ApiResponse>(GetDataFromApi(apiUrl));
                JObject counterValues = responseCounter.COUNTER;
                var apparentEnergyObject = counterValues["ACTIVE_ENERGY"];
                var netObject = apparentEnergyObject["IMPORT"];
                var t1Object = netObject["T1"];
                ValuesPAC2200.ZaehlerstandTotKWhBezug = t1Object["total"].Value<double>();
                // Wirkleistung Import
                ValuesPAC2200.ImportT1TotKWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T1"]["total"].Value<double>();
                ValuesPAC2200.ImportT1L1KWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T1"]["L1"].Value<double>();
                ValuesPAC2200.ImportT1L2KWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T1"]["L2"].Value<double>();
                ValuesPAC2200.ImportT1L3KWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T1"]["L3"].Value<double>();
                ValuesPAC2200.ImportT2TotKWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T2"]["total"].Value<double>();
                ValuesPAC2200.ImportT2L1KWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T2"]["L1"].Value<double>();
                ValuesPAC2200.ImportT2L2KWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T2"]["L2"].Value<double>();
                ValuesPAC2200.ImportT2L3KWh = counterValues["ACTIVE_ENERGY"]["IMPORT"]["T2"]["L3"].Value<double>();

                // Wirkenergie Export
                ValuesPAC2200.ExportT1TotKWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T1"]["total"].Value<double>();
                ValuesPAC2200.ExportT1L1KWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T1"]["L1"].Value<double>();
                ValuesPAC2200.ExportT1L2KWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T1"]["L2"].Value<double>();
                ValuesPAC2200.ExportT1L3KWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T1"]["L3"].Value<double>();
                ValuesPAC2200.ExportT2TotKWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T2"]["total"].Value<double>();
                ValuesPAC2200.ExportT2L1KWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T2"]["L1"].Value<double>();
                ValuesPAC2200.ExportT2L2KWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T2"]["L2"].Value<double>();
                ValuesPAC2200.ExportT2L3KWh = counterValues["ACTIVE_ENERGY"]["EXPORT"]["T2"]["L3"].Value<double>();

                // Blindenergie Import
                ValuesPAC2200.ImportT1TotKvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T1"]["total"].Value<double>();
                ValuesPAC2200.ImportT1L1Kvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T1"]["L1"].Value<double>();
                ValuesPAC2200.ImportT1L2Kvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T1"]["L2"].Value<double>();
                ValuesPAC2200.ImportT1L3Kvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T1"]["L3"].Value<double>();
                ValuesPAC2200.ImportT2TotKvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T2"]["total"].Value<double>();
                ValuesPAC2200.ImportT2L1Kvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T2"]["L1"].Value<double>();
                ValuesPAC2200.ImportT2L2Kvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T2"]["L2"].Value<double>();
                ValuesPAC2200.ImportT2L3Kvarh = counterValues["REACTIVE_ENERGY"]["IMPORT"]["T2"]["L3"].Value<double>();

                // Blindenergie Export
                ValuesPAC2200.ExportT1TotKVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T1"]["total"].Value<double>();
                ValuesPAC2200.ExportT1L1KVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T1"]["L1"].Value<double>();
                ValuesPAC2200.ExportT1L2KVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T1"]["L2"].Value<double>();
                ValuesPAC2200.ExportT1L3KVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T1"]["L3"].Value<double>();
                ValuesPAC2200.ExportT2TotVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T2"]["total"].Value<double>();
                ValuesPAC2200.ExportT2L1KVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T2"]["L1"].Value<double>();
                ValuesPAC2200.ExportT2L2KVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T2"]["L2"].Value<double>();
                ValuesPAC2200.ExportT2L3KVAh = counterValues["REACTIVE_ENERGY"]["EXPORT"]["T2"]["L3"].Value<double>();

                // Scheinenergie Import
                ValuesPAC2200.T1TotKVAh = counterValues["APPARENT_ENERGY"]["NET"]["T1"]["total"].Value<double>();
                ValuesPAC2200.T1L1KVAh = counterValues["APPARENT_ENERGY"]["NET"]["T1"]["L1"].Value<double>();
                ValuesPAC2200.T1L2KVAh = counterValues["APPARENT_ENERGY"]["NET"]["T1"]["L2"].Value<double>();
                ValuesPAC2200.T1L3KVAh = counterValues["APPARENT_ENERGY"]["NET"]["T1"]["L3"].Value<double>();
                ValuesPAC2200.T2TotVAh = counterValues["APPARENT_ENERGY"]["NET"]["T2"]["total"].Value<double>();
                ValuesPAC2200.T2L1KVAh = counterValues["APPARENT_ENERGY"]["NET"]["T2"]["L1"].Value<double>();
                ValuesPAC2200.T2L2KVAh = counterValues["APPARENT_ENERGY"]["NET"]["T2"]["L2"].Value<double>();
                ValuesPAC2200.T2L3KVAh = counterValues["APPARENT_ENERGY"]["NET"]["T2"]["L3"].Value<double>();




                netObject = apparentEnergyObject["EXPORT"];
                t1Object = netObject["T1"];
                ValuesPAC2200.ZaehlerstandTotKWhAbgabe = t1Object["total"].Value<double>();

                apiUrl = "http://" + ip + "/data.json?type=DAILYPROFILE&count=1";
                ApiResponse responseDailyprofile = JsonConvert.DeserializeObject<ApiResponse>(GetDataFromApi(apiUrl));
                JObject dailyProfile = responseDailyprofile.DAILYPROFILE;
                var instObject = dailyProfile["INST"];
                ValuesPAC2200.ImportHeuteKWh = instObject["import"].Value<double>();
                ValuesPAC2200.ExportHeuteKWh = instObject["export"].Value<double>();
            }
            catch (Exception e)
            {
                Logger.Logger.WriteSyslog("Fehler" + ip + " Pac2200: " + e, "error");
            }
            return ValuesPAC2200;
        }

        
        static string GetDataFromApi(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = response.Content.ReadAsStringAsync().Result;
                        return jsonContent;
                    }
                    else
                    {
                        Logger.Logger.WriteSyslog($"Fehler: {response.StatusCode} - {response.ReasonPhrase}", "error");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Logger.WriteSyslog($"Fehler: {ex.Message}", "error");
                }
            }

            return null;
        }
    }
}
