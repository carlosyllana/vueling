﻿using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao.DAO;

namespace Vueling.DataAccess.Dao

{
    public interface IDAO<T>: ICreate<T>, IReadDoc<T> where T : VuelingObject
    {
    }
}
