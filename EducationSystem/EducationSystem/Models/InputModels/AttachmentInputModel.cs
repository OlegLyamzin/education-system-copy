namespace EducationSystem.API.Models
{
    public class AttachmentInputModel
    {
        public int Id { get; set; }     
        public string Path { get; set; }
        public AttachmentTypeInputModel AttachmentType { get; set; }
    }
}