using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Common.Constants
{
    public class ExceptionConstants
    {
        public const string GUID_IS_NULL = "Related object is null.";
        public const string VALIDATION_TYPE_ERROR = "It is not assignable for IValidator type class.";
        public const string UNAUTHORIZE_ERROR = "UnAuthorized Error. This request can not be accessible for you.";
        public const string USER_EXIST_ERROR = "User already exists. Please try another email address.";
        public const string USER_NOT_EXIST_ERROR = "User not exists. Please try another email address.";
        public const string RECORD_NOT_SAVED_ERROR = "While saving your record, something went wrong. Please try again later.";
    }
}
