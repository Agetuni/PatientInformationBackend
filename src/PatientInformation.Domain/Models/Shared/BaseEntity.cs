namespace PatientInformation.Domain.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }

        //Auditlog
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public string TimeZoneInfo { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }
        public string RegisteredBy { get; set; } = string.Empty;
        public DateTime LastUpdateDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public RecordStatus RecordStatus { get; set; } = RecordStatus.Active;
        public bool IsReadOnly { get; set; }

        public BaseEntity()
        {
            StartDate = DateTime.UtcNow;
            EndDate = DateTime.MaxValue;
            RegisteredDate = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
            IsReadOnly = false;
            Activate();

        }
        public virtual void Activate()
        {
            RecordStatus = Common.RecordStatus.Active;
        }
        public virtual void Deactivate()
        {
            RecordStatus = Common.RecordStatus.InActive;
        }
        public virtual void Delete()
        {
            RecordStatus = Common.RecordStatus.Deleted;
        }
        public virtual void UpdateAudit(string updateBy)
        {
            LastUpdateDate = DateTime.UtcNow;
            UpdatedBy = updateBy;

        }
    }
}
