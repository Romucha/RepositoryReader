﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader
{
    public interface IPackageParametersFactory
    {
        IPackageParameters CreatePackageParameters(string RawParameters);
    }
}