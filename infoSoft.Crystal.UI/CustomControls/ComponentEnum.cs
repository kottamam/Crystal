#region Copyright

// ©Copyright 2015, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 14.07.2015
// Created By   : Noble
// Description  : Class for define enum used in component classes
// -----------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion Code history

#region Using directives

using System.Runtime.InteropServices;

#endregion

namespace tv.Crystal.UI.CustomControls
{
    [ComVisible(true)]
    public enum CellContentType
    {
        String = 0,
        Number = 1,
        Amount = 2,
        Date = 3
    }
}
