using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MmgGameApiCs.net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class used to store rows of information from a class config text file.
    /// Created by Middlemind Games 03/15/2020
    /// 
    /// @author Victor G.Brusca
    /// </summary>
    public class MmgCfgFileEntry : IComparer<MmgCfgFileEntry>
    {
        public MmgCfgFileEntry()
        {
        }

        public int Compare([AllowNull] MmgCfgFileEntry x, [AllowNull] MmgCfgFileEntry y)
        {
            throw new NotImplementedException();
        }
    }
}
