using System;
using System.Collections.Generic;
using System.Text;

namespace XFFirebase.Models
{
    public class MyMoney
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string InvoiceNo { get; set; }
        public int Cost { get; set; }
    }
}
