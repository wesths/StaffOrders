using System;
using System.Collections.Generic;
using System.Text;

namespace StaffOrder.Domain
{
    public class Stock
    {
        public string AXCategory { get; set; }
        public string AXSubCategory { get; set; }
        public string AXClass { get; set; }
        public string Pattern { get; set; }
        public string OrdCodeDescrip { get; set; }
        public string OrdCode { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public string Variation { get; set; }
        public int Page { get; set; }
        public int SequenceNo { get; set; }
        public int ItemNo { get; set; }
        public decimal CashPrice { get; set; }
        public int QtyAvail { get; set; }
    }
}
