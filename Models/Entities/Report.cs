﻿using System.ComponentModel.DataAnnotations;
namespace crp_api.Models.Entities
{
    public class Report
    {
        [Key]
        public Guid REPORT_ID { get; set; }
        public string? TITLE { get; set; }
        public string? BODY { get; set; }
        public string? URL { get; set; }
        
        public Guid? REPORTTYPE_ID { get; set; }
        public ReportType? REPORTTYPE { get; set; }
        public Guid? USER_ID { get; set; }
        public User? USER { get; set; }
        public Guid? REPORTSTATUS_ID { get; set; }
        public ReportStatus? REPORTSTATUS { get; set; }

        public virtual ICollection<ReportLog>? REPORTLOGS { get; set; }

    }
}