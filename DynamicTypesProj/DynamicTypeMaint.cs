using System;
using System.Collections;
using System.Collections.Generic;
using PX.Api;
using PX.Common;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.FA;


namespace DynamicTypesProj
{
    public class DynamicTypeMaint : PXGraph<DynamicTypeMaint>
    {
        public PXSave<DynamicallyDac> Save;

        #region Views

        public SelectFrom<DynamicallyDac>.View SSDynamicView;

        public PXSelect<FixedAsset> FixedAssets;

        #endregion

        #region Constants

        private const string TypeString = "String";
        private const string TypeInt = "Int";
        private const string TypeBool = "Bool";
        private const string TypeDate = "Date";
        private const string TypeDecimal = "Decimal";
        private const string TypeSelector = "Selector";

        #endregion

        protected Dictionary<int, string> TypesOfFields = new Dictionary<int, string>
        {
            { 1, TypeString},
            { 2, TypeInt},
            { 3, TypeBool},
            { 4, TypeDate},
            { 5, TypeDecimal},
            { 6, TypeSelector}
        };

        public IEnumerable sSDynamicView()
        {
            IEnumerable rez = SelectFrom<DynamicallyDac>.View.Select(this);

            if (rez.Any_() == false)
            {
                for (int i = 1; i < 7; i++)
                {
                    DynamicallyDac row = new DynamicallyDac
                    {
                        Type = TypesOfFields[i],
                        Index = i
                    };
                    SSDynamicView.Insert(row);
                }
            }

            return rez;
        }

        protected void DynamicallyDac_Value_FieldSelecting(PXCache cache, PXFieldSelectingEventArgs e)
        {
            var row = (DynamicallyDac)e.Row;
            if (row == null)
                return;
            string fieldName = nameof(DynamicallyDac.value);
            switch (row.Type)
            {
                case TypeString:
                    e.ReturnState = GetState(row.Value, typeof(string), fieldName);
                    break;
                case TypeInt:
                    e.ReturnState = GetState(row.Value, typeof(int), fieldName);
                    break;
                case TypeBool:
                    e.ReturnState = GetState(row.Value, typeof(bool), fieldName);
                    break;
                case TypeDate:
                    e.ReturnState = GetState(row.Value, typeof(DateTime), fieldName);
                    break;
                case TypeDecimal:
                    e.ReturnState = GetState(row.Value, typeof(decimal), fieldName, false, 2);
                    break;
                case TypeSelector:
                    e.ReturnState = GetState(row.Value, typeof(string), fieldName, true);
                    break;
            }

        }

        private PXFieldState GetState(string value, Type type, string fieldName, bool isSelector = false, int precision = 0)
        {
            var state = PXFieldState.CreateInstance(value,
                type, false, true, 1, precision, null, null, fieldName);

            if (isSelector)
            {
                state.ViewName = nameof(FixedAssets);
                state.DescriptionName = nameof(FixedAsset.description);
                state.FieldList = new[]
                {
                    nameof(FixedAsset.assetID),
                    nameof(FixedAsset.description),
                    nameof(FixedAsset.assetTypeID),
                    nameof(FixedAsset.assetCD)
                };
                var selectorCache = this.Caches<FixedAsset>();
                state.HeaderList = new[]
                {
                    PXUIFieldAttribute.GetDisplayName<FixedAsset.assetID>(selectorCache),
                    PXUIFieldAttribute.GetDisplayName<FixedAsset.description>(selectorCache),
                    PXUIFieldAttribute.GetDisplayName<FixedAsset.assetTypeID>(selectorCache),
                    PXUIFieldAttribute.GetDisplayName<FixedAsset.assetCD>(selectorCache),
                };
            }
            return state;
        }

    }
}
