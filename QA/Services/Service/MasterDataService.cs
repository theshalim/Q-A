using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QA.Areas.MasterData.Models;
using QA.Data;

namespace QA.Services.Service
{
    public class MasterDataService : IMasterData
    {
        private readonly ApplicationDbContext _Context;
        public MasterDataService(ApplicationDbContext Context)
        {
            this._Context = Context;
        }

        public MasterData DeleteMasterData(int Id)
        {
            MasterData mas = new MasterData();
            
                if (mas != null)
            {
                _Context.MasterDatas.Remove(mas);
                _Context.SaveChanges();
            }
            return mas;
            
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _Context.Categorys;
        }

        public IEnumerable<MasterData> GetAllMasterData()
        {
            return _Context.MasterDatas;
        }

        public MasterData GetMasterDataById(int Id)
        {
            MasterData mas = _Context.MasterDatas.Find(Id);
            return mas;
        }

        public Category SaveCategory(Category obj)
        {
            _Context.Categorys.Add(obj);
            _Context.SaveChanges();
            return obj;
        }

        public MasterData SaveMasterData(MasterData obj)
        {
            _Context.MasterDatas.Add(obj);
            _Context.SaveChanges();
            return obj;
        }

        public MasterData UpdateMasterData(MasterData upobj)
        {
            var mas = _Context.MasterDatas.Attach(upobj);
            mas.State = EntityState.Modified;
            _Context.SaveChanges();
            return upobj;
        }
    }
}
