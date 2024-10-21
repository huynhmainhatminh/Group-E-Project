namespace TVcaKoi.Common.Res
{
    public class SimpleReq : BaseReq<BaseModel>
    {

        #region --Overrides--
        public override BaseModel ToModel(int? createBy = null)
        {
            return new BaseModel(Id);
        }
        #endregion

        #region --Methods--
        public SimpleReq() : base() { }
        public SimpleReq(int id) : base(id) { }

        public SimpleReq(string keyword) : base(keyword) { }

        #endregion
    }
}
