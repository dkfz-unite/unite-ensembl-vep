using System.Runtime.Serialization;

namespace Unite.Vep.Web.Services.Enums
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
