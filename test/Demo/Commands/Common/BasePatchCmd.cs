using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BitHelp.Core.Validation.Test.Demo.Commands.Common {
    public abstract class BasePatchCmd {

        protected IList<string> _registeredFields = new List<string>();

        protected bool HasRegisteredFields() {
            return _registeredFields.Any();
        }

        protected string[] GetRegisteredFields() {
            return _registeredFields.ToArray();
        }

        protected void RegisterField([CallerMemberName] string name = null) {
            if (!_registeredFields.Contains(name)) {
                _registeredFields.Add(name);
            }
        }

        protected bool IsFieldRegistered(string field) {
            return _registeredFields.Contains(field);
        }

        protected void ClearRegisteredField(string field = null) {
            if (field is null) {
                _registeredFields.Clear();
            } else {
                _registeredFields = _registeredFields.Where(x => x != field).ToList();
            }
        }
    }
}
