using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository
{
    public class ObjectStateManager<T> where T : IEntity
    {
        // ? How to handle relationship objects?

        private Collection<T> _originalValues;
        private Collection<T> _currentValues;
        private Dictionary<Guid, ObjectState> _objectsStates;

        public List<T> CurrentObjects 
        {
            get { return _currentValues.ToList(); }
        }

        public List<T> OriginalObjects
        {
            get { return _originalValues.ToList(); }
        }

        public List<T> WorkObjects 
        {
            get 
            {
                List<Guid> guidList = GetGuidByState(ObjectState.Deleted);
                return _currentValues.Where(x => !guidList.Contains(x.Guid)).ToList();
            }
        }


        public ObjectStateManager() 
        {
            _originalValues = new Collection<T>();
            _currentValues = new Collection<T>();
            _objectsStates = new Dictionary<Guid, ObjectState>();
        }

        public void RegisterObject(T obj) 
        {
            AddingObjectOriginalValue(obj);
            ChangeObjectState(obj.Guid, ObjectState.Unchanged);
        }

        public void NewObject(T obj)
        {
            HandleOjectCurrentValue(obj);
            ChangeObjectState(obj.Guid, ObjectState.New);
        }

        public void ModifyObject(T obj)
        {
            HandleOjectCurrentValue(obj);
            switch(GetObjectState(obj))
            {
                case ObjectState.New : 
                    break;
                default:
                    ChangeObjectState(obj.Guid, ObjectState.Modified);
                    break;
            }
        }

        public void DeleteObject(T obj) 
        {
            switch(GetObjectState(obj))
            {
                case ObjectState.New : 
                    RemoveObject(obj);
                    break;
                default:
                    ChangeObjectState(obj.Guid, ObjectState.Deleted);
                    break;
            }
        }

        public ICollection<T> GetObjectsByState(ObjectState objectState) 
        {
            List<Guid> guidList = GetGuidByState(objectState);
            return _currentValues.Where(x => guidList.Contains(x.Guid)).ToList();
        }

        private List<Guid> GetGuidByState(ObjectState objectState) 
        {
            List<KeyValuePair<Guid, ObjectState>> listOfSameState = _objectsStates.Where(x => x.Value == objectState).ToList();

            List<Guid> guidList = new List<Guid>();
            foreach (KeyValuePair<Guid, ObjectState> keyValue in listOfSameState)
            {
                guidList.Add(keyValue.Key);
            }

            return guidList;
        }

        private void ChangeObjectState(Guid identiy, ObjectState state) 
        {
            if (_objectsStates.ContainsKey(identiy))
            {
                _objectsStates[identiy] = state;
            }
            else 
            {
                _objectsStates.Add(identiy, state);
            }
        }

        private void HandleOjectCurrentValue(T obj) 
        {
            if (!HasObject(_currentValues, obj)) 
            {
                _currentValues.Add(obj);
                return;
            }

            T findObject = _currentValues.FirstOrDefault(x => x.Guid == obj.Guid);
            int index = _currentValues.IndexOf(findObject);
            _currentValues.Remove(findObject);
            _currentValues.Insert(index,obj);
        }

        private void AddingObjectOriginalValue(T obj) 
        {
            if (!HasObject(_originalValues, obj)) 
            {
                _originalValues.Add(obj);
                _currentValues.Add(obj);
            }
        }

        private bool HasObject(ICollection<T> collection, T obj) 
        {
            T findObject = collection.FirstOrDefault(x => x.Guid == obj.Guid);
            return findObject != null ? true : false;
        }

        private ObjectState GetObjectState(T obj)
        {
            //no State????
            if (_objectsStates.ContainsKey(obj.Guid))
            {
                KeyValuePair<Guid, ObjectState> objState = _objectsStates.SingleOrDefault(x => x.Key == obj.Guid);
                return objState.Value;
            }
            else
            {
                return ObjectState.NoState;
            }
        }

        private void RemoveObject(T obj)
        {
            T curObj = _currentValues.SingleOrDefault(x => x.Guid == obj.Guid);
            if (curObj != null) 
            {
                _currentValues.Remove(curObj);
            }

            _objectsStates.Remove(obj.Guid);
        }
    }
}
