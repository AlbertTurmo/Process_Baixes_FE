//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using System.Security.Cryptography;
//using System.Text;

//namespace UnsubscribeR
//{
//    /// <summary>
//    /// Clase para encriptar o desencriptar contraseñas
//    /// </summary>
//    public static class EncryptionTools
//    {
//        private static readonly string passPhrase = "CPtseZUgsDt62rVgB6egWXRN8";



//        public static DataTable GetDecryptedDataTable(DataTable DataTable, List<string> columns)
//        {

//            foreach (DataRow DataRow in DataTable.Rows)
//            {
//                foreach (DataColumn DataColumn in DataRow.Table.Columns)
//                {
//                    if (columns.Contains(DataColumn.ColumnName))
//                    {
//                        continue;
//                    }

//                    if (DataRow[DataColumn] != null) // This will check the null values also (if you want to check).
//                    {
//                        string Value = DataRow[DataColumn].ToString();

//                        // Debug.WriteLine($"{column.ColumnName}: {value}");
//                        string NewValue = DecryptStrintToString(Value);

//                        // Debug.WriteLine($"{column.ColumnName}: {newValue}");

//                        DataRow[DataColumn] = NewValue;

//                        // convert
//                        // Do whatever you want.
//                    }

//                }
//            }


//            return DataTable;
//        }



//        public static DataTable getDecryptedDataTable(DataTable d)
//        {

//            foreach (DataRow row in d.Rows)
//            {
//                foreach (DataColumn column in row.Table.Columns)
//                {
//                    if (row[column] != null) // This will check the null values also (if you want to check).
//                    {
//                        string value = row[column].ToString();

//                        string newValue = DecryptStrintToString(value);
//                        // convert

//                        row[column] = newValue;

//                        // Do whatever you want.
//                    }

//                }
//            }

//            return d;
//        }


//        public static DataTable GetConvertedTypeDataTable(DataTable dataTable)
//        {
//            DataRow datarow;
//            DataTable newdatatable = dataTable.Clone();
//            newdatatable.Columns["date"].DataType = typeof(DateTime);

//            foreach (DataRow d in dataTable.Rows)
//            {
//                datarow = newdatatable.NewRow();


//                datarow["UsuariosId"] = d["UsuariosId"];
//                datarow["windowsid"] = d["windowsid"];
//                datarow["nombre"] = d["nombre"];
//                // datarow["email"] = d["email"];
//                DateTime.TryParse(d["date"].ToString(), out DateTime dateTime);
//                datarow["date"] = dateTime;
//                newdatatable.Rows.Add(datarow);
//            }


//            // PrintTable(newdatatable);



//            return newdatatable;
//        }

//        public static void PrintTable(DataTable d)
//        {
//            foreach (DataRow row in d.Rows)
//            {
//                foreach (DataColumn column in row.Table.Columns)
//                {

//                    if (row[column] != null) // This will check the null values also (if you want to check).
//                    {
//                        Debug.WriteLine($"{column.ColumnName}: {row[column]}");
//                    }

//                }
//            }
//        }




//        public static string encryptStToSt(string value) // encrypt string to string...
//        {
//            if (!string.IsNullOrEmpty(value))
//            {
//                byte[] encrypt = EncryptString(value);
//                string encryptedString = GetString(encrypt);
//                return encryptedString;
//            }
//            else
//            {
//                return string.Empty;
//            }





//        }

//        /// <summary>
//        /// Encripta una cadena a partir de una clave y lo convierte en un array de bits
//        /// </summary>
//        /// <param name="Message">Cadena a encriptar</param>
//        /// <param name="Passphrase">Clave para encriptar-desencriptar</param>
//        /// <returns>Array de bits con el string encriptado</returns>
//        private static byte[] EncryptString(string Message)
//        {
//            if (String.IsNullOrEmpty(Message) == true)
//                return null;

//            byte[] Results;
//            UTF8Encoding utf8 = new UTF8Encoding();

//            // Step 1. We hash the passphrase using MD5
//            // We use the MD5 hash generator as the result is a 128 bit byte array
//            // which is a valid length for the TripleDES encoder we use below

//            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
//            byte[] TDESKey = HashProvider.ComputeHash(utf8.GetBytes(passPhrase));

//            // Step 2. Create a new TripleDESCryptoServiceProvider object
//            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

//            // Step 3. Setup the encoder
//            TDESAlgorithm.Key = TDESKey;
//            TDESAlgorithm.Mode = CipherMode.ECB;
//            TDESAlgorithm.Padding = PaddingMode.PKCS7;

//            // Step 4. Convert the input string to a byte[]
//            byte[] DataToEncrypt = utf8.GetBytes(Message);

//            // Step 5. Attempt to encrypt the string
//            try
//            {
//                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
//                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
//            }
//            finally
//            {
//                // Clear the TripleDes and Hashprovider services of any sensitive information
//                TDESAlgorithm.Clear();
//                HashProvider.Clear();
//            }

//            return Results;
//            // Step 6. Return the encrypted string as a base64 encoded string
//            //return Convert.ToBase64String(Results);
//        }

//        public static string DecryptStrintToString(string StrToDecrypt) // decrypt string to string...
//        {
//            if (!string.IsNullOrEmpty(StrToDecrypt))
//            {
//                byte[] DataToDecrypt = GetBytes(StrToDecrypt);
//                return DecryptString(DataToDecrypt);
//            }
//            else
//            {
//                return string.Empty;
//            }



//        }

//        /// <summary>
//        /// Desencripta un array de bits a partir de una clave y lo convierte en una cadena
//        /// </summary>
//        /// <param name="DataToDecrypt">Array de bits con el valor encriptado</param>
//        /// <param name="Passphrase">Clave para encriptar-desencriptar</param>
//        /// <returns>Cadena con el valor desencriptado</returns>
//        private static string DecryptString(byte[] DataToDecrypt)
//        {
//            if (DataToDecrypt == null)
//            {
//                return String.Empty;
//            }


//            byte[] Results;
//            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

//            // Step 1. We hash the passphrase using MD5
//            // We use the MD5 hash generator as the result is a 128 bit byte array
//            // which is a valid length for the TripleDES encoder we use below

//            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
//            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passPhrase));

//            // Step 2. Create a new TripleDESCryptoServiceProvider object
//            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

//            // Step 3. Setup the decoder
//            TDESAlgorithm.Key = TDESKey;
//            TDESAlgorithm.Mode = CipherMode.ECB;
//            TDESAlgorithm.Padding = PaddingMode.PKCS7;

//            // Step 4. Convert the input string to a byte[]
//            //byte[] DataToDecrypt = Convert.FromBase64String(Message);

//            // Step 5. Attempt to decrypt the string
//            try
//            {
//                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
//                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
//            }
//            finally
//            {
//                // Clear the TripleDes and Hashprovider services of any sensitive information
//                TDESAlgorithm.Clear();
//                HashProvider.Clear();
//            }

//            // Step 6. Return the decrypted string in UTF8 format
//            return UTF8.GetString(Results);
//        }

//        public static byte[] GetBytes(string str)
//        {
//            byte[] result = Convert.FromBase64String(str);
//            return result;
//        }

//        public static string GetString(byte[] bytes)
//        {
//            string result = Convert.ToBase64String(bytes);
//            return result.Trim(); ;
//        }
//    }
//}
