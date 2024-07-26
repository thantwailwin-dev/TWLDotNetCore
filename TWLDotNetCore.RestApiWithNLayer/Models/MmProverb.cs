namespace TWLDotNetCore.RestApiWithNLayer.Models
{
    public class MmProverb
    {
        public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
        public Tbl_Mmproverbs[] Tbl_MMProverbs { get; set; }
    }

    public class Tbl_Mmproverbstitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
    }

    public class Tbl_Mmproverbs
    {
        public int TitleId { get; set; }
        public int ProverbId { get; set; }
        public string ProverbName { get; set; }
        public string ProverbDesp { get; set; }
    }

}
