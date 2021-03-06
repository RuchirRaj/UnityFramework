using System;
using System.Xml;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Framework
{
	using Utils;

	namespace Serialization
	{
		namespace Xml
		{
			[XmlObjectConverter(typeof(Type), "SystemType", "OnConvertToXmlNode", "OnConvertFromXmlNode", "ShouldWriteNodeMethod")]
			public static class XmlSystemTypeConverter
			{
				#region XmlObjectConverter
				public static void OnConvertToXmlNode(object obj, XmlNode node)
				{
					Type currentType = (Type)obj;
					if (currentType != null)
						node.InnerText = currentType.FullName;
				}

				public static object OnConvertFromXmlNode(object obj, XmlNode node)
				{
					if (node == null)
						return obj;

					if (!string.IsNullOrEmpty(node.InnerText))
					{
						return SystemUtils.GetType(node.InnerText);
					}

					return null;
				}

				public static bool ShouldWriteNodeMethod(object obj, object defaultObj)
				{
					return (Type)obj != (Type)defaultObj;
				}
				#endregion
			}
		}
	}
}