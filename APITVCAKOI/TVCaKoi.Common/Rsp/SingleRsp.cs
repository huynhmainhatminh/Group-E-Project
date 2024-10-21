namespace TVcaKoi.Common.Rsp
{
    public class SingleRsp : BaseRsp
    {
        #region --Methods--
        public SingleRsp() : base() { }

        public SingleRsp(string message) : base(message) { }

        public SingleRsp(string message, string titleError) : base(message, titleError) { }

        public void SetData(string code, object data)
        {
            Code = code;
            Data = data;
        }
        #endregion


        #region --Properties--
        public object Data { get; set; }
        #endregion
    }
}
