using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetsRepository.DAL;

namespace WidgetsRepository
{
    public abstract class FileSystemGateway<TFileSystemObject, TEntity> : DataGateway<TEntity>
        where TFileSystemObject : class, IFileSystemObject
        where TEntity : IEntity
    {
        FileSystemMapper<TFileSystemObject, TEntity> _mapper;
        FileSystemQuery<TFileSystemObject> _query;

        public FileSystemGateway(FileSystemQuery<TFileSystemObject> query, FileSystemMapper<TFileSystemObject, TEntity> mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public override TEntity Find(string name)
        {
            TFileSystemObject fileData = _query.Find(name);
            return _mapper.MapToEntity(fileData);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            List<TFileSystemObject> fileDataList = _query.GetAll();
            List<TEntity> entitiesList = new List<TEntity>();
            foreach (TFileSystemObject fileData in fileDataList) 
            {
                TEntity entity = _mapper.MapToEntity(fileData);
                entitiesList.Add(entity);
            }

            return entitiesList;
        }

        public override void Insert(TEntity entity)
        {
            TFileSystemObject fileData = _mapper.MapToFileSystemObject(entity);
            _query.Insert(fileData);
        }

        public override void Update(TEntity entity)
        {
            TFileSystemObject fileData = _mapper.MapToFileSystemObject(entity);
            _query.Update(fileData);
        }

        public override void Delete(TEntity entity)
        {
            TFileSystemObject fileData = _mapper.MapToFileSystemObject(entity);
            _query.Delete(fileData);
        }
    }
}
