using System.Runtime.Serialization;

namespace Unite.Annotations.VEP.Web.Services.Enums
{
    public enum Format
    {
        [EnumMember(Value = "json")]
        JSON,

        [EnumMember(Value = "vcf")]
        VCF,

        [EnumMember(Value = "vep")]
        VEP
    }
}
