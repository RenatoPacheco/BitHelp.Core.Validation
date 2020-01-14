using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation.Test.Resources
{
    public class AllValues
    {
        [Display(Name = "Single values")]
        public SingleValues SingleValues { get; set; }

        [Display(Name = "Array values")]
        public ArrayValues ArrayValues { get; set; }
    }
}
