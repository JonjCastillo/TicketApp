using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TicketApp.Models
{
    public class IssueViewModel
    {
        public int issueID { get; set; }

        [Required(ErrorMessage = "Select a status for your ticket")]
        public string StatusID { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Select a priority for your ticket")]
        public string PriorityID { get; set; } = string.Empty;
    }
}
