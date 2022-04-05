using QA.Areas.MasterData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QA.Services
{
   public interface IMasterData
    {
        IEnumerable<MasterData> GetAllMasterData();
        MasterData GetMasterDataById (int Id);
        MasterData SaveMasterData(MasterData obj);
        MasterData UpdateMasterData(MasterData upobj);
        MasterData DeleteMasterData(int Id);
        Category SaveCategory(Category obj);
        IEnumerable<Category> GetAllCategory();
    }
}
