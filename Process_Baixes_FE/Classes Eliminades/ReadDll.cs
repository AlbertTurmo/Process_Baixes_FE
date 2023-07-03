//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace UnsubscribeR
//{
//    class ReadDll
//    {
//        static readonly string directory = System.AppDomain.CurrentDomain.BaseDirectory;

//        static readonly string pathDllConfig = System.IO.Path.Combine(ReadDll.directory, "dll.config");

//        public static string ReadTagFileConfig(string parentTagName, string sTagName)
//        {
//            string readTag = string.Empty;

//            if (!File.Exists(pathDllConfig))
//            {
//                return "error";
//            }

//            XmlDocument doc = new XmlDocument();
//            doc.Load(pathDllConfig);

//            XmlElement root = doc.DocumentElement;
//            XmlNodeList lst = root.GetElementsByTagName(parentTagName);
//            if (lst != null && lst.Count > 0)
//            {
//                XmlElement node = (XmlElement)lst[0];
//                XmlNodeList childList = node.GetElementsByTagName(sTagName);
//                if (childList != null && childList.Count > 0)
//                {
//                    readTag = childList[0].InnerText;
//                }
//            }
//            return readTag;
//        }


//        /// <summary>
//        /// Devuelve un numérico (int) con el valor en el fichero dllConfig con el tag asociado y subTag indicado
//        /// </summary>
//        /// <param name="parentTagName">Nombre asignado del nodo padre dentro del xml del fichero</param>
//        /// <param name="sTagName">Nombre asignado al nodo del que se busca el valor</param>
//        /// <returns>Int con el valor. En caso de no existir, devuelve 0</returns>
//        public static int ReadIntTagFileConfig(string parentTagName, string sTagName)
//        {
//            string readTag = string.Empty;

//            if (!File.Exists(pathDllConfig))
//            {
//                return 0;
//            }
                

//            XmlDocument document = new System.Xml.XmlDocument();
//            document.Load(pathDllConfig);

//            XmlElement root = document.DocumentElement;
//            XmlNodeList lst = root.GetElementsByTagName(parentTagName);
//            if (lst != null && lst.Count > 0)
//            {
//                XmlElement node = lst[0] as XmlElement;
//                XmlNodeList childList = node.GetElementsByTagName(sTagName);
//                if (childList != null && childList.Count > 0)
//                {
//                    readTag = childList[0].InnerText;
//                }
                    
//            }
//            if (String.IsNullOrEmpty(readTag) == true)
//            {
//                return 0;
//            }
                
//            return Convert.ToInt32(readTag);
//        }



//        /// <summary>
//        /// Devuelve un numérico (int) con el valor en el fichero dllConfig con el tag asociado y subTag indicado
//        /// </summary>
//        /// <param name="parentTagName">Nombre asignado del nodo padre dentro del xml del fichero</param>
//        /// <param name="sTagName">Nombre asignado al nodo del que se busca el valor</param>
//        /// <returns>Int con el valor. En caso de no existir, devuelve 0</returns>
//        public static bool ReadBooleanTagFileConfig(string parentTagName, string sTagName)
//        {
//            string readTag = string.Empty;
//            bool booleanResult = false;

//            if (!File.Exists(pathDllConfig))
//            {
                
//            }

//            XmlDocument document = new System.Xml.XmlDocument();
//            document.Load(pathDllConfig);

//            XmlElement root = document.DocumentElement;
//            XmlNodeList nodelist = root.GetElementsByTagName(parentTagName);
//            if (nodelist != null && nodelist.Count > 0)
//            {
//                XmlElement node = nodelist[0] as XmlElement;
//                XmlNodeList childList = node.GetElementsByTagName(sTagName);
//                if (childList != null && childList.Count > 0)
//                {
//                    readTag = childList[0].InnerText;
//                    bool.TryParse(readTag, out booleanResult);
//                }

//            }
//            if (String.IsNullOrEmpty(readTag))
//            {
//                return false;
//            }

//            return booleanResult;
//        }




//        /// <summary>
//        /// Devuelve una lista de valores 
//        /// </summary>
//        /// <param name="parentTagName"></param>
//        /// <param name="sTagName"></param>
//        /// <returns></returns>
//        public static List<string> ReadListTagFileConfig(string parentTagName, string sTagName)
//        {
//            List<string> readTags = new List<string>();

//            if (File.Exists(pathDllConfig) == false)
//            {
//                return null;
//            }

//            XmlDocument doc = new XmlDocument();
//            doc.Load(pathDllConfig);

//            XmlElement root = doc.DocumentElement;
//            XmlNodeList nodelist = root.GetElementsByTagName(parentTagName);
//            if (nodelist != null && nodelist.Count > 0)
//            {
//                XmlElement node = (XmlElement)nodelist[0];
//                XmlNodeList childList = node.GetElementsByTagName(sTagName);
//                foreach (XmlNode childNode in childList)
//                {
//                    readTags.Add(childNode.InnerText);
//                }
//            }
//            return readTags;
//        }


//    }
//}
