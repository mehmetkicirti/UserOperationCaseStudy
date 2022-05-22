using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOperationCaseStudy.Common.Constants
{
    public class ResponseConstants
    {
        public const string REGISTER_SUCCESSFULLY = "User is registered successfully.";
        public const string CREATE_ENTITY_FAILED = "While adding entity, It occurred an error.";
        public const string GUID_IS_NOT_NULL = "GUID should not be null.";
        public const string ENTITY_NOT_EXIST = "Searched entity not found. Maybe you are using wrong object id";
        public const string DELETE_ENTITY_SUCCESFULLY = "Deleted entity value successfully.";
        public const string DELETE_ENTITY_FAILED = "While deleting entity, It occurred an error.";
        public const string UPDATE_ENTITY_SUCCESFULLY = "Updated entity value successfully.";
        public const string UPDATE_ENTITY_FAILED = "While updating entity, It occurred an error.";
    }
}
