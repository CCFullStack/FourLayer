using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourLayer.Presentation.Web.Models {
    public class TransferPostViewModel {

        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
    }
}