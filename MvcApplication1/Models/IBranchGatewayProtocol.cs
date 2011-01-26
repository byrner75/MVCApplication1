using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gateway.Data.Entities
{
    public interface IBranchGatewayProtocol
    {
        [HiddenInput(DisplayValue = false)]
        int id { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(30,ErrorMessage="!")]
        string ClientApplicationName { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"\w\w\w\w\w", ErrorMessage="!")]
        string GatewayId { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("001|002", ErrorMessage = "!")]
        string FinancialInstitution { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("NSC|ICS|INT|TMB", ErrorMessage = "!")]
        string SourceType { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"\d\d\d\d\d\d", ErrorMessage = "!")]
        string Branch { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression(@"\d\d", ErrorMessage = "!")]
        string SubOffice { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("HTTP|DFSM", ErrorMessage = "!")]
        string Protocol { get; set; }
    }

    [MetadataType(typeof(IBranchGatewayProtocol))]
    public partial class BranchGatewayProtocol 
    {
    }
}
