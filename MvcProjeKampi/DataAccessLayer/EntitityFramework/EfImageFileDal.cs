﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitityFramework
{
    public class EfImageFileDal:GenericRepository<ImageFile>,IImageFileDal
    {
    }
}
