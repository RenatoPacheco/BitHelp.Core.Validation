# BitHelp.Core.Validation

## Release 1.0.0

- fix: Text fixes
- fix: Method name fixes
- feat: Simplifying error message definition
- feat: Ignore null values ​​in lists, in the same way as individual values

## Release 0.17.0

- feat: Add RequiredIfOtherIsNullIsValid
- feat: Update Sonar Cloud Analyze

## Release 0.16.0

- feature: Increase in test coverage
- feature: Increase in tests for date validations
- feature: Including CultureInfo in validations for TimeSpan

## Release 0.15.1

- fix: Removing property T _ not using

## Release 0.15.0

**Features:**

- Checking if type is Enum for EnumIsValid
- Requiring type indication for BetweenEnumIsValid
- Using support classes to convert some types
- Removing the responsibility from barring Between**Some**IsValid classes for invalid conversions

## Release 0.14.0

**Features:**

- Including list various types of numbers for comparison in BetweenNumberIsValid
- Adding BetweenGuidIsValid
- Adding option to deny betweens validates
- Avoiding converting values if not necessary
- Update packages test
- Adding more tests


## Release 0.13.0

**Features:**

- Adding DenyRegexIsValid
- Update packages test
- Delete folder doc
- Adding more tests

## Release 0.12.0

**Features:**

- Reviewed all EqualItems tests
- Review required validate
- Review compare less date time validate
- Review compare plus date time validate
- Adding note to coverage report generate
- Set to report only errors
- Remove fuget badge
- Remove methods obsolete
- Adding IEquatable<ValidationMessage>
- Adding testing exception
- Update packages
- Remove software dependencies in readme

**Bug fixing**

- Fixing IsTypeError check
- Update input Func<T, IList> to Func<T, IEnumerable>

## Release 0.11.0

**Features:**

- Adding type error to not found with message
- Adding package in github
- Optimization of the any tests validation

## Release 0.10.0

**Features:**

- Fixing the RemoveAtReference extension
- There is no need to keep .nupkg files
- Add extension to check for notifications
- Add extension to add notifications for ISelfValidation