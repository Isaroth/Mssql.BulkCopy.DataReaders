using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace DataReaders
{
    public class ArrayDataReader : IDataReader
    {
        protected string[][] _data;
        protected int _index = -1;
        protected string[] _row;
        private bool disposedValue;

        protected bool Eof { get; set; }
        public ArrayDataReader(string[][] data)
        {
            _data = data;
            IsClosed = false;
        }

        public int Depth => 1;
        public int RecordsAffected => -1;
        public int FieldCount => _data[0].Length;
        public bool IsClosed { get; set; }

        public object this[string name] => throw new NotImplementedException();

        public object this[int i] => throw new NotImplementedException();

        public void Close()
        {
            IsClosed = true;
            Dispose();
        }

        public DataTable GetSchemaTable()
        {
            return null;
        }
        public bool NextResult()
        {
            return false;
        }
        public bool Read()
        {
            if (IsClosed)
                throw new ObjectDisposedException(GetType().Name);

            bool _eof = (_index + 1 >= _data.Length);

            _index += (_eof) ? 0 : 1;
            
            if (!_eof) { _row = _data[_index]; }

            return !_eof;
        }

        public object GetValue(int i)
        {
            return _row[i];
        }

        #region Not Implemented

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        #endregion
       
        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _data = new string[0][];
                }                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}