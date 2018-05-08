
using System.Collections;
using System.Collections.Generic;

namespace PixelSquare.Events
{
	public class EventParameters
	{
		private Dictionary<string, char> 		m_charParam 		= null;
		private Dictionary<string, int> 		m_intParam 			= null;
		private Dictionary<string, bool> 		m_boolParam 		= null;
		private Dictionary<string, string> 		m_stringParam 		= null;
		private Dictionary<string, float> 		m_floatParam 		= null;
		private Dictionary<string, double> 		m_doubleParam 		= null;
		private Dictionary<string, long> 		m_longParam 		= null;

		private Dictionary<string, ArrayList> 	m_arrayListParam 	= null;
		private Dictionary<string, object> 		m_objectParam 		= null;

		public EventParameters()
		{
			m_charParam 		= new Dictionary<string, char>();
			m_intParam 			= new Dictionary<string, int>();
			m_boolParam 		= new Dictionary<string, bool>();
			m_stringParam 		= new Dictionary<string, string>();
			m_floatParam 		= new Dictionary<string, float>();
			m_doubleParam 		= new Dictionary<string, double>();
			m_longParam 		= new Dictionary<string, long>();
			m_arrayListParam 	= new Dictionary<string, ArrayList>();
			m_objectParam 		= new Dictionary<string, object>();
		}

		public void addParam(string p_paramName, char p_value)
		{
			m_charParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, int p_value)
		{
			m_intParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, bool p_value)
		{
			m_boolParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, string p_value)
		{
			m_stringParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, float p_value)
		{
			m_floatParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, double p_value)
		{
			m_doubleParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, long p_value)
		{
			m_longParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, ArrayList p_value)
		{
			m_arrayListParam.Add(p_paramName, p_value);
		}

		public void addParam(string p_paramName, object p_value)
		{
			m_objectParam.Add(p_paramName, p_value);
		}

		public char getParam(string p_paramName, char p_defaultValue)
		{
			return m_charParam.ContainsKey(p_paramName) ? m_charParam[p_paramName] : p_defaultValue;
		}

		public int getParam(string p_paramName, int p_defaultValue)
		{
			return m_intParam.ContainsKey(p_paramName) ? m_intParam[p_paramName] : p_defaultValue;
		}

		public bool getParam(string p_paramName, bool p_defaultValue)
		{
			return m_boolParam.ContainsKey(p_paramName) ? m_boolParam[p_paramName] : p_defaultValue;
		}

		public string getParam(string p_paramName, string p_defaultValue)
		{
			return m_stringParam.ContainsKey(p_paramName) ? m_stringParam[p_paramName] : p_defaultValue;
		}

		public float getParam(string p_paramName, float p_defaultValue)
		{
			return m_floatParam.ContainsKey(p_paramName) ? m_floatParam[p_paramName] : p_defaultValue;
		}

		public double getParam(string p_paramName, double p_defaultValue)
		{
			return m_doubleParam.ContainsKey(p_paramName) ? m_doubleParam[p_paramName] : p_defaultValue;
		}

		public long getParam(string p_paramName, long p_defaultValue)
		{
			return m_longParam.ContainsKey(p_paramName) ? m_longParam[p_paramName] : p_defaultValue;
		}

		public ArrayList getParam(string p_paramName, ArrayList p_defaultValue)
		{
			return m_arrayListParam.ContainsKey(p_paramName) ? m_arrayListParam[p_paramName] : p_defaultValue;
		}

		public object getParam(string p_paramName, object p_defaultValue)
		{
			return m_objectParam.ContainsKey(p_paramName) ? m_objectParam[p_paramName] : p_defaultValue;
		}
	}
}
