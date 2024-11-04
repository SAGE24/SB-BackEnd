namespace SB.Entity.Domain;
public class EntityModel
{
    public int Code { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }

}
