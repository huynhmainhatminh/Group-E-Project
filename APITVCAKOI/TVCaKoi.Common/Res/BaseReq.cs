namespace TVcaKoi.Common.Res
{
    public abstract class BaseReq<T>
    {
        #region --Methods--
        public BaseReq()
        {
            Keyword = string.Empty;
        }

        public BaseReq(int id)
        {
            Id = id;
        }

        public BaseReq(string keyword)
        {
            Keyword = keyword;
        }

        public abstract T ToModel(int? createBy = null);
        #endregion

        #region --Properties--
        public int Id { get; set; }
        public string Keyword { get; set; }
        #endregion
    }
}
