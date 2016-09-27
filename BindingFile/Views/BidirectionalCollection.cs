using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Views
{
    public class DictionaryCollection<T, U>
    {
        private Dictionary<T, Dictionary<U, string>> _keyDictionary;
        private IEqualityComparer<U> _comparer2 = null;

        public DictionaryCollection()
            : this(null, null)
        {
        }

        public DictionaryCollection(IEqualityComparer<T> comparer1, IEqualityComparer<U> comparer2)
        {
            if (comparer1 != null)
            {
                _keyDictionary = new Dictionary<T, Dictionary<U, string>>(comparer1);
            }
            else
            {
                _keyDictionary = new Dictionary<T, Dictionary<U, string>>();
            }
            _comparer2 = comparer2;
        }

        public IEnumerable<T> Keys
        {
            get
            {
                return _keyDictionary.Keys;
            }
        }

        public bool ContainsKey(T key)
        {
            return _keyDictionary.ContainsKey(key);
        }

        public void Add(T key, U value)
        {
            Dictionary<U, string> _valueDictionary;

            if (_keyDictionary.ContainsKey(key))
            {
                _valueDictionary = _keyDictionary[key];
                
                if (!_valueDictionary.ContainsKey(value))
                {
                    _valueDictionary.Add(value, null);
                }
            }
            else
            {
                if (_comparer2 != null)
                {
                    _valueDictionary = new Dictionary<U, string>(_comparer2);
                }
                else
                {
                    _valueDictionary = new Dictionary<U, string>();
                }
                _valueDictionary.Add(value, null);
                _keyDictionary.Add(key, _valueDictionary);
            }                   
        }

        public IEnumerable<U> this[T key]
        {
            get
            {
                return _keyDictionary[key].Keys;
            }
        }
    }

    public class BidirectionalCollection<A, B>
    {
        DictionaryCollection<A, B> _ab;
        DictionaryCollection<B, A> _ba;

        public BidirectionalCollection()
            : this(null, null)
        {
        }

        public BidirectionalCollection(IEqualityComparer<A> comparer1, IEqualityComparer<B> comparer2)
        {
            _ab = new DictionaryCollection<A, B>(comparer1, comparer2);
            _ba = new DictionaryCollection<B, A>(comparer2, comparer1);
        }

        public void Add(A key1, B key2)
        {
            _ab.Add(key1, key2);
            _ba.Add(key2, key1);
        }

        public bool ContainsKey1(A key1)
        {
            return _ab.ContainsKey(key1);
        }

        public bool ContainsKey2(B key2)
        {
            return _ba.ContainsKey(key2);
        }

        public IEnumerable<A> Keys1
        {
            get
            {
                return _ab.Keys;
            }
        }

        public IEnumerable<B> Keys2
        {
            get
            {
                return _ba.Keys;
            }
        }

        public IEnumerable<B> GetKey1Values(A key1)
        {
            return _ab[key1];
        }

        public IEnumerable<A> GetKey2Values(B key2)
        {
            return _ba[key2];
        }
    }
}
