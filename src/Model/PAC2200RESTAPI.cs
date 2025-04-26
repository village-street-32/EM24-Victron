using System;

namespace HomeAutomation.Modbus.Model
{
    public class PAC2200RESTAPI
    {
        public double ZaehlerstandTotKWhBezug { get; set; }
        public double ZaehlerstandTotKWhAbgabe { get; set; }
        public double ImportHeuteKWh { get; set; }
        public double ExportHeuteKWh { get; set; }
        public double Frequenz { get; set; }
        public double WirkLeistungTotW { get; set; }
        public double WirkLeistungL1W { get; set; }
        public double WirkLeistungL2W { get; set; }
        public double WirkLeistungL3W { get; set; }
        public double ScheinLeistungTotVA { get; set; }
        public double ScheinLeistungL1VA { get; set; }
        public double ScheinLeistungL2VA { get; set; }
        public double ScheinLeistungL3VA { get; set; }
        public double BlindLeistungTotVAR { get; set; }
        public double BlindLeistungL1VAR { get; set; }
        public double BlindLeistungL2VAR { get; set; }
        public double BlindLeistungL3VAR { get; set; }
        public double LeistungsfaktorL1 {get; set; }
        public double LeistungsfaktorL2 { get; set; }
        public double LeistungsfaktorL3 { get; set; }
        public double Leistungsfaktor { get; set; }
        public double SpannungL1V { get; set; }
        public double SpannungL2V { get; set; }
        public double SpannungL3V { get; set; }
        public double SpannungL12V { get; set; }
        public double SpannungL23V { get; set; }
        public double SpannungL31V { get; set; }
        public double StromTotA { get; set; }
        public double StromL1A { get; set; }
        public double StromL2A { get; set; }
        public double StromL3A { get; set; }
        public double StromNA { get; set; }
        public double Spannung_LN_AVG { get; set; }
        public double Spannung_LL_AVG { get; set; }

        //Wirkleistung Import
        public double ImportT1TotKWh { get; set; }
        public double ImportT1L1KWh { get; set; }
        public double ImportT1L2KWh { get; set; }
        public double ImportT1L3KWh { get; set; }
        public double ImportT2TotKWh { get; set; }
        public double ImportT2L1KWh { get; set; }
        public double ImportT2L2KWh { get; set; }
        public double ImportT2L3KWh { get; set; }

        //Wirkenergie Export
        public double ExportT1TotKWh { get; set; }
        public double ExportT1L1KWh { get; set; }
        public double ExportT1L2KWh { get; set; }
        public double ExportT1L3KWh { get; set; }
        public double ExportT2TotKWh { get; set; }
        public double ExportT2L1KWh { get; set; }
        public double ExportT2L2KWh { get; set; }
        public double ExportT2L3KWh { get; set; }

        //Blindenergie Import
        public double ImportT1TotKvarh { get; set; }
        public double ImportT1L1Kvarh { get; set; }
        public double ImportT1L2Kvarh { get; set; }
        public double ImportT1L3Kvarh { get; set; }
        public double ImportT2TotKvarh { get; set; }
        public double ImportT2L1Kvarh { get; set; }
        public double ImportT2L2Kvarh { get; set; }
        public double ImportT2L3Kvarh { get; set; }

        //Blindenergie Export
        public double ExportT1TotKVAh { get; set; }
        public double ExportT1L1KVAh { get; set; }
        public double ExportT1L2KVAh { get; set; }
        public double ExportT1L3KVAh { get; set; }
        public double ExportT2TotVAh { get; set; }
        public double ExportT2L1KVAh { get; set; }
        public double ExportT2L2KVAh { get; set; }
        public double ExportT2L3KVAh { get; set; }

        //Scheinenergie 
        public double T1TotKVAh { get; set; }
        public double T1L1KVAh { get; set; }
        public double T1L2KVAh { get; set; }
        public double T1L3KVAh { get; set; }
        public double T2TotVAh { get; set; }
        public double T2L1KVAh { get; set; }
        public double T2L2KVAh { get; set; }
        public double T2L3KVAh { get; set; }


        public DateTime Date { get; set; }
    }
}