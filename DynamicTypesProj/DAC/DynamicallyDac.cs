using System;
using PX.Data;
using PX.Objects.PM;


namespace DynamicTypesProj
{
    [Serializable]
    [PXCacheName("DynamicallyDac")]
    public class DynamicallyDac : IBqlTable
    {
        #region Type
        [PXDBString(60)]
        [PXUIField(DisplayName = "Type")]
        public virtual string Type { get; set; }
        public abstract class type : PX.Data.BQL.BqlString.Field<type> { }
        #endregion

        #region Value
        [PXDBString(60)]
        [PXUIField(DisplayName = "Value")]
        public virtual string Value { get; set; }
        public abstract class value : PX.Data.BQL.BqlString.Field<value> { }
        #endregion

        #region Index
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Index")]
        public virtual int? Index { get; set; }
        public abstract class index : PX.Data.BQL.BqlInt.Field<index> { }
        #endregion

    }
}
