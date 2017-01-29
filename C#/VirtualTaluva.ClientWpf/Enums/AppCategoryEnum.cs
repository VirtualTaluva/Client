using Com.Ericmas001.Common.Attributes;

namespace IconeIA.App.VieUtil.Enums
{
    public enum AppCategoryEnum
    {
        [DisplayName("Quick")]
        [Priority(10)]
        [Color("Orange")]
        Quick,

        [DisplayName("SignIn")]
        [Priority(20)]
        [Color("Green")]
        SignIn,

        [DisplayName("Register")]
        [Color("MediumOrchid")]
        [Priority(30)]
        Register,
    }
}
