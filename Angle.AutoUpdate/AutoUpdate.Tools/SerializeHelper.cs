/* 
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2016/12/30 13:48:28 
 * 文件名(File Name)：SerializeHelper 
 * 
 * 修改记录(Update Record):
 *  R1.
 *      修改作者(Update Author):           
 *      修改时间(Update Datetime):               
 *      修改说明(Update Description): 
 * ======================================================================== 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace AutoUpdate.Tools
{
    public class SerializeHelper
    {
        /// <summary>
        /// xml序列化文件保存
        /// </summary>
        /// <param name="obj">待序列化对象</param>
        /// <param name="filePath">保存路径</param>
        public static void XmlSerializeToFile(object obj, string filePath)
        {
            FileStream fs = null;
            try
            {
                if (!File.Exists(filePath))
                {
                    string folderPath = filePath.Substring(0, filePath.LastIndexOf('\\'));
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                }

                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());

                serializer.Serialize(fs, obj);
            }
            catch (FieldAccessException faex)
            {
                throw faex;
            }
            catch (FileNotFoundException fex)
            {
                throw fex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        /// <summary>
        /// 将xml序列化文件反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象实例</param>
        /// <param name="filePath">xml序列文件路径</param>
        /// <returns></returns>
        public static T LoadXmlSerializeFile<T>(string filePath) where T : class
        {
            FileStream fs = null;
            try
            {
                if (!File.Exists(filePath))
                {
                    return null;
                }

                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                return serializer.Deserialize(fs) as T;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
        /// <summary>
        /// 将对象序列化xml字符串
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="t">对象实例</param>
        /// <returns></returns>
        public string XmlSerializeToStr<T>(T t)
        {
            XmlSerializer serializer = new XmlSerializer(t.GetType());
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, t);

                return sb.ToString();
            }
        }
        /// <summary>
        /// 将序列化xml字符串转化为对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="str">序列xml字符串</param>
        /// <returns></returns>
        public T XmlSerializeToObj<T>(string str)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(new StringReader(str)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// 将对象序列化二进制文件
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filePath">文件</param>
        public static void BinarySerialize(object obj, string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // 用二进制格式序列化
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);

                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 将二进制文件反序列化成对象
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static object BinaryDeserialize(string filePath)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            object obj;
            if (!File.Exists(filePath))
                throw new Exception("未找到指定序列化文件");
            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = formatter.Deserialize(stream);
                stream.Close();
            }

            return obj;
        }
        /// <summary>
        /// 序列化为soap 即xml
        /// </summary>
        /// <param name="filePath">文件存储路径</param>
        /// <returns></returns>
        public static void SoapSerialize(object obj, string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    // 序列化为Soap
                    SoapFormatter formatter = new SoapFormatter();
                    formatter.Serialize(fileStream, obj);

                    fileStream.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 反序列对象
        /// </summary>
        /// <param name="filePath"></param>
        public static object SoapDeserialize(string filePath)
        {
            object obj;
            System.Runtime.Serialization.IFormatter formatter = new SoapFormatter();

            if (!File.Exists(filePath))
                throw new Exception("未找到指定序列化文件");
            //Soap格式反序列化
            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = formatter.Deserialize(stream);
                stream.Close();
            }

            return obj;
        }
    }
}
