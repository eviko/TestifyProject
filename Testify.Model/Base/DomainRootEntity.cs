using System.ComponentModel.DataAnnotations.Schema;

namespace Testify.Model.Base
{
    public class DomainRootEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var objAsDomainEntity = obj as DomainRootEntity;
            if (objAsDomainEntity == null) return false;

            if (GetType() != obj.GetType())
                return false;

            return Id == objAsDomainEntity.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType()} {Id}";
        }
    }
}