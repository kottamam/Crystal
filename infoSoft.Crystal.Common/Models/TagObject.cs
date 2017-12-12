#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 04.08.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for tag objects
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives

using System;

#endregion

namespace tv.Crystal.Common.Models
{
    public class TagObject
    {
        public int ObjectId
        {
            get;
            set;
        } = 0;

        public string ObjectName
        {
            get;
            set;
        } = string.Empty;

        public override string ToString() => ObjectName;
    }
}
