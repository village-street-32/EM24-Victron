using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAutomation.Modbus.Model
{
    public class PAC2200
    {
        public double ZaehlerstandTotKWhBezug { get; set; }
        public double ZaehlerstandTotKWhAbgabe { get; set; }
        public double Frequenz { get; set; }
        public double WirkLeistungTotW { get; set; }
        public double WirkLeistungL1W { get; set; }
        public double WirkLeistungL2W { get; set; }
        public double WirkLeistungL3W { get; set; }
        public double ScheinLeistungTotVA { get; set; }
        public double ScheinLeistungL1VA { get; set; }
        public double ScheinLeistungL2VA { get; set; }
        public double ScheinLeistungL3VA { get; set; }
        public double BlindLeistungTotVA { get; set; }
        public double BlindLeistungL1VAR { get; set; }
        public double BlindLeistungL2VAR { get; set; }
        public double BlindLeistungL3VAR { get; set; }
        public double SpannungL1V { get; set; }
        public double SpannungL2V { get; set; }
        public double SpannungL3V { get; set; }
        public double StromTotA { get; set; }
        public double StromL1A { get; set; }
        public double StromL2A { get; set; }
        public double StromL3A { get; set; }
        public DateTime Date { get; set; }
    }
}