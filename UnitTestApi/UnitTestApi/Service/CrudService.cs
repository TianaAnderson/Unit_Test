using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApi.Service
{
    public class CrudService
    {
        IDataStorage _dataStorage;

        public CrudService(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public int Create(string name)
        {
            return _dataStorage.Insert(name);
        }

        public string Read()
        {
            return _dataStorage.Read();
        }

        public int Update(string oldName, string newName)
        {
            return _dataStorage.Update(oldName, newName);
        }

        public void Delete(string name)
        {
             _dataStorage.Delete(name);
        }
    }

    public interface IDataStorage
    {
        int Insert(string name);

        string Read();

        int Update(string oldName, string newName);

        void Delete(string name);

    }


}
