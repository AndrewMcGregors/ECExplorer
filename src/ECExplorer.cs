/*
 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 +                                                                  +
 +                                                                  +
 + EC Explorer  An Embedded Controller viewer and hardware          +
 +                                                                  +
 +              resource monitoring                                 +
 +                                                                  +
 +              This file is part of the EC Explorer distribution.  +
 +                                                                  +
 +                                                                  +
 +                                                                  +
 +                                                                  +  
 + Author:  Andrew McGregor, <andrew.drunkyduck@gmail.com>          +
 +                                                                  +
 +          Copyright 2025 Andrew McGregor.                         +
 +                                                                  +
 +                                                                  +
 +                                                                  +
 +                                                                  +  
 +  This Source Code Form is subject to the terms of the            +
 +  Mozilla Public License, v. 2.0. If a copy of the MPL            +
 +  was not distributed with this file, You can obtain              +
 +  one at http://mozilla.org/MPL/2.0/.                             +
 +                                                                  +
 +                                                                  +
 +                                                                  +
 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace ECExplorerFormsApp
{
    static class ECExplorer
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ECExplorerForm());
        }
    }
}
