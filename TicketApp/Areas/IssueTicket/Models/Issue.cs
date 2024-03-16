using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TicketApp.Areas.IssueTicket.Models
{
    public class Issue
    {
        public int TicketID { get; set; }

        [Required (ErrorMessage = "Enter a title that summarizes your problem")]
        public string? ticketTitle { get; set; }

        [Required (ErrorMessage = "Enter a description of your problem")]
        public string? ticketDescription { get; set; }

        [Required (ErrorMessage = "Enter your name")]
        public string? ticketName { get; set; }

        [Required]
        [EmailAddress (ErrorMessage = "Enter a valid email address")]
        public string? ticketEmail { get; set; }

        [DataType(DataType.Date)]
        public DateTime submitDate { get; set; }

        [Required (ErrorMessage = "Select a priority for your ticket")]
        public string priorityID { get; set; } = string.Empty;

        [ValidateNever]
        public Priority ticketPriority { get; set; } = null!;

        [Required (ErrorMessage = "Select a status for your ticket")]
        public string statusID { get; set; } = string.Empty;

        [ValidateNever]
        public Status ticketStatus { get; set; } = null!;
    }
}
