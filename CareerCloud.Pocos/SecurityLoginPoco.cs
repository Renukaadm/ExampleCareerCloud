namespace CareerCloud.Pocos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Security_Logins")]
    public class SecurityLoginPoco : IPoco
    {
        public SecurityLoginPoco()
        {
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Column("Created_Date")]
        public DateTime Created { get; set; }

        [Column("Password_Update_Date")]
        public DateTime? PasswordUpdate { get; set; }

        [Column("Agreement_Accepted_Date")]
        public DateTime? AgreementAccepted { get; set; }

        [Column("Is_Locked")]
        public bool IsLocked { get; set; }

        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }

        [Column("Email_Address")]
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Column("Phone_Number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column("Full_Name")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Column("Force_Change_Password")]
        public bool ForceChangePassword { get; set; }

        [Column("Prefferred_Language")]
        //[StringLength(6)]
        public string PrefferredLanguage { get; set; }

        [Column(name: "Time_Stamp", TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
    }
}
