namespace TVcaKoi.Common.Res
{
    public class BaseModel
    {
        #region --Methods--
        public BaseModel(int id)
        {
            Id = id;
        }
        #endregion

        #region --Properties--
        public int Id { get; set; }

        public Enum Status { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        #endregion

    }
}
