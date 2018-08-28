using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Common.Validation
{
    //
    // Summary:
    //     Enumeration of the possible error kinds.
    public enum ValidationErrorKind
    {
        //
        // Summary:
        //     An unknown error.
        Unknown = 0,
        //
        // Summary:
        //     A string is expected.
        StringExpected = 1,
        //
        // Summary:
        //     A number is expected.
        NumberExpected = 2,
        //
        // Summary:
        //     An integer is expected.
        IntegerExpected = 3,
        //
        // Summary:
        //     A boolean is expected.
        BooleanExpected = 4,
        //
        // Summary:
        //     An object is expected.
        ObjectExpected = 5,
        //
        // Summary:
        //     The property is required but not found.
        PropertyRequired = 6,
        //
        // Summary:
        //     An array is expected.
        ArrayExpected = 7,
        //
        // Summary:
        //     An array is expected.
        NullExpected = 8,
        //
        // Summary:
        //     The Regex pattern does not match.
        PatternMismatch = 9,
        //
        // Summary:
        //     The string is too short.
        StringTooShort = 10,
        //
        // Summary:
        //     The string is too long.
        StringTooLong = 11,
        //
        // Summary:
        //     The number is too small.
        NumberTooSmall = 12,
        //
        // Summary:
        //     The number is too big.
        NumberTooBig = 13,
        //
        // Summary:
        //     The integer is too big.
        IntegerTooBig = 14,
        //
        // Summary:
        //     The array contains too many items.
        TooManyItems = 15,
        //
        // Summary:
        //     The array contains too few items.
        TooFewItems = 16,
        //
        // Summary:
        //     The items in the array are not unique.
        ItemsNotUnique = 17,
        //
        // Summary:
        //     A date time is expected.
        DateTimeExpected = 18,
        //
        // Summary:
        //     A date is expected.
        DateExpected = 19,
        //
        // Summary:
        //     A time is expected.
        TimeExpected = 20,
        //
        // Summary:
        //     A time-span is expected.
        TimeSpanExpected = 21,
        //
        // Summary:
        //     An URI is expected.
        UriExpected = 22,
        //
        // Summary:
        //     An IP v4 address is expected.
        IpV4Expected = 23,
        //
        // Summary:
        //     An IP v6 address is expected.
        IpV6Expected = 24,
        //
        // Summary:
        //     A valid GUID is expected.
        GuidExpected = 25,
        //
        // Summary:
        //     The object is not any of the given schemas.
        NotAnyOf = 26,
        //
        // Summary:
        //     The object is not all of the given schemas.
        NotAllOf = 27,
        //
        // Summary:
        //     The object is not one of the given schemas.
        NotOneOf = 28,
        //
        // Summary:
        //     The object matches the not allowed schema.
        ExcludedSchemaValidates = 29,
        //
        // Summary:
        //     The number is not a multiple of the given number.
        NumberNotMultipleOf = 30,
        //
        // Summary:
        //     The integer is not a multiple of the given integer.
        IntegerNotMultipleOf = 31,
        //
        // Summary:
        //     The value is not one of the allowed enumerations.
        NotInEnumeration = 32,
        //
        // Summary:
        //     An Email is expected.
        EmailExpected = 33,
        //
        // Summary:
        //     An hostname is expected.
        HostnameExpected = 34,
        //
        // Summary:
        //     The array tuple contains too many items.
        TooManyItemsInTuple = 35,
        //
        // Summary:
        //     An array item is not valid.
        ArrayItemNotValid = 36,
        //
        // Summary:
        //     The item is not valid with the AdditionalItems schema.
        AdditionalItemNotValid = 37,
        //
        // Summary:
        //     The additional properties are not valid.
        AdditionalPropertiesNotValid = 38,
        //
        // Summary:
        //     Additional/unspecified properties are not allowed.
        NoAdditionalPropertiesAllowed = 39,
        //
        // Summary:
        //     There are too many properties in the object.
        TooManyProperties = 40,
        //
        // Summary:
        //     There are too few properties in the tuple.
        TooFewProperties = 41,
        //
        // Summary:
        //     A Base64 string is expected.
        Base64Expected = 42,
        //
        // Summary:
        //     No type of the types does validate (check error details in NJsonSchema.Validation.MultiTypeValidationError).
        NoTypeValidates = 43
    }

}
