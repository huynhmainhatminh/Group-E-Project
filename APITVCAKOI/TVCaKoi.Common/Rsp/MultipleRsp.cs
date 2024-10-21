namespace TVcaKoi.Common.Rsp
{
    public class MultipleRsp : BaseRsp
    {
        #region --Methods--
        public MultipleRsp() : base() { }

        public MultipleRsp(string message) : base(message) { }

        public MultipleRsp(string message, string titleError) : base(message, titleError) { }

        public void SetData(string key, object o)
        {
            if (Data == null)
            {
                Data = new Dictionary<string, object>();
            }
            Data.Add(key, o);
        }

        public void SetSuccess(object o, string message)
        {
            var t = new Dto(o, message);
            SetData("success", t);
        }

        public void SetFailure(object o, string message)
        {
            var t = new Dto(o, message);
            SetData("failure", t);

        }
        #endregion

        #region --Properties--
        public Dictionary<string, object> Data { get; private set; }
        #endregion

        #region --Classes--
        public class Dto
        {
            #region --Methods--
            public Dto(object data, string message)
            {
                Data = data;
                Message = message;
            }
            #endregion

            #region --Properties--
            public object Data { get; private set; }
            public string Message { get; private set; }
            #endregion

        }
        #endregion

    }
}
