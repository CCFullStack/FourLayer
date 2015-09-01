using FourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FourLayer.Presentation.Web.Models {
    public class TransferViewModel {

        public IList<AccountDTO> myAccounts { get; set; }
        public IList<AccountDTO> allAccounts { get; set; }
    }
}