using EduHome.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EduHome.UI.ViewModel
{
    public class TeacherVM
    {
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<TeacherDetail> TeacherDetails { get; set; }
        [Required, MaxLength(255)]
        public string ImagePath { get; set; }

        [Required, MaxLength(55)]
        public string FullName { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Position { get; set; } = null!;
        [Required, MaxLength(500)]
        public string About { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Degree { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Experience { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Hobbies { get; set; } = null!;
        [Required, MaxLength(100)]
        public string Faculty { get; set; } = null!;
        [Required, MaxLength(255)]
        public string Mail { get; set; } = null!;
        [Required, MaxLength(55)]
        public string Phone { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Skype { get; set; } = null!;
        [Required]
        public int LanguageDegree { get; set; }
        [Required]
        public int TeamLeaderDegree { get; set; }
        [Required]
        public int DevelopmentDegree { get; set; }
        [Required]
        public int DesignDegree { get; set; }
        [Required]
        public int InnovationDegree { get; set; }
        [Required]
        public int CommunicationDegree { get; set; }


    }
}
