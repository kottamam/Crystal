#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 18.06.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for form properties.
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
    public class FormProperties
    {
        public int MenuId
        {
            get;
            set;
        } = 0;

        public string MenuName
        {
            get;
            set;
        } = string.Empty;
    }
}
