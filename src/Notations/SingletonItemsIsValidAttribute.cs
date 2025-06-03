using System;
using System.Collections;
using System.Collections.Generic;
using BitHelp.Core.Validation.Resources;

namespace BitHelp.Core.Validation.Notations {

    [AttributeUsage(AttributeTargets.Property |
           AttributeTargets.Field, AllowMultiple = false)]
    public class SingletonItemsIsValidAttribute : BaseIsValidAttribute {

        public SingletonItemsIsValidAttribute() : base() {
            ErrorMessageResourceName = nameof(Resource.XSingletonItemsInvalid);
        }

        protected override bool Check(object value) {
            IList input = value as IList;
            bool result = true;

            if (input != null && input.Count > 1) {
                IList<object> list = new List<object>();
                foreach (var item in input) {
                    if (item != null) {
                        if (list.Contains(item)) {
                            result = false;
                            break;
                        }
                        list.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
