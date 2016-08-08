using System;
using System.IO;
using Alis.Utils.IO;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using Alis.Pac.Factor.Development;
using System.Net;

namespace Alis.SAT
{
    public static class  Common
    {

        /*  public static void CertificateData(string pCerFile, out string Certificate, out string CertificateNumber)
{
X509Certificate cert = new X509Certificate(pCerFile);
byte[] strcert = cert.GetRawCertData();
Certificate = Convert.ToBase64String(strcert);

strcert = cert.GetSerialNumber();
CertificateNumber = Reverse(System.Text.Encoding.UTF8.GetString(strcert));
}

public static string Reverse(string Original)
{
string Reverse = "";
for (int i = Original.Length - 1; i >= 0; i--)
Reverse += Original.Substring(i, 1);
return Reverse;
}
*/
        public static void timbrar(string xml)
        {
            try
            {
                wspacService wsp = new wspacService();
                cfdiERecord crd;
                cfd_NSRecord req = new cfd_NSRecord();
                req.username = "VE223.test_ws";
                req.password = "Test-WS+092013";
                req.xml = xml;
                crd = (cfdiERecord)wsp.createCFDI_NS(req);
            }
            catch (WebException e)
            {
                throw e;
            }
            
        }

        public static bool ValidateXml(string xml,string schemeFile)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(xml);
                writer.Flush();
                stream.Position = 0;

                using (XmlTextReader tr = new XmlTextReader(stream))
                {
                    using (XmlValidatingReader vr = new XmlValidatingReader(tr))
                    {
                        vr.Schemas.Add("http://www.sat.gob.mx/cfd/3", schemeFile);
                        //vr.Schemas.Add("http://www.sat.gob.mx/detallista", schemeFile2);
                        //vr.Schemas.Add("http://www.sat.gob.mx/nomina", schemeFile3);

                        vr.ValidationType = ValidationType.Schema;


                        while (vr.Read()) { }
                    }


                    tr.Close();
                }
            }catch (XmlSchemaException schemaEx)
            {

                    //SaveError(10, schemaEx, schemaEx.Message + " [RECEPTOR: " + NOMBRE_RECEPTOR + "]");
                    //tr.Close();
                    return false;
            }catch (Exception ex)
            {

                    //SaveError(10, ex, ex.ToString());
                    //tr.Close();
                    return false;
            }
            return true;
        }

        private static byte[] ReadCertificado(string FileNameCert)
        {
            //bytes read file
            FileStream f = new FileStream(FileNameCert, FileMode.Open, FileAccess.Read);
            int size = (int)f.Length;
            byte[] data = new byte[size];
            size = f.Read(data, 0, size);
            f.Close();
            return data;
        }

        public static string GetNumberCertificate(string FileNameCert)
        {
            X509Certificate2 cer = new X509Certificate2();
            byte[] rawData = ReadCertificado(FileNameCert);
            cer.Import(rawData);
            return Encoding.UTF8.GetString(cer.GetSerialNumber());
        }

        /// <summary>
        /// Devuelve cadena base 64 el certificado
        /// </summary>
        /// <param name="FileNameCert">Especificar la ruta del certificado digital</param>
        /// <returns></returns>
        public static string GetStringCertificate(string FileNameCert)
        {
            X509Certificate2 cer = new X509Certificate2();

            //bytes read file
            byte[] rawData = ReadCertificado(FileNameCert);

            cer.Import(rawData);
            return Convert.ToBase64String(cer.GetRawCertData());
        }

        public static string GetOriginalChain(string xml, string archivoXslt)
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xml);
            XslCompiledTransform xlc = new XslCompiledTransform();
            xlc.Load(archivoXslt);
            StringWriter str = new StringWriter();
            XmlTextWriter myWriter = new XmlTextWriter(str);
            xlc.Transform(xDoc, null, myWriter);

            return str.ToString();
        }


        /// <summary>
        /// Get original chain and signing
        /// </summary>
        /// <param name="keyFileName">Name File Key</param>
        /// <param name="password">Pass from File Name Key</param>
        /// <param name="originalChain">Original chain</param>
        /// <returns></returns>
        public static string SignOriginalChain(string keyFileName, string password, string originalChain)
        {
            if (!System.IO.File.Exists(keyFileName))
            {
                return "Archivo .key no existe";
            }

            string SignedString = "";

            RSACryptoServiceProvider rsa = OpenKeyFile(keyFileName, password);
            if (rsa != null)
            {
                byte[] CO = Encoding.UTF8.GetBytes(originalChain);
                byte[] SignedBytes = rsa.SignData(CO, new SHA1CryptoServiceProvider());
                SignedString = Convert.ToBase64String(SignedBytes);
            }
            return SignedString;
        }

        //Read private key
        private static RSACryptoServiceProvider OpenKeyFile(String keyFileName, string password)
        {
            RSACryptoServiceProvider rsa = null;
            byte[] keyBytes = Utils.IO.File.GetBytes(keyFileName);

            if (keyBytes == null)
                return null;

            rsa = DecodePrivateKey(keyBytes, password);	//PKCS #8 encrypted
            if (rsa != null)
            {
                return rsa;
            }

            return null;
        }

        private static RSACryptoServiceProvider DecodePrivateKey(byte[] keyBytes, string password)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            // this byte[] includes the sequence byte and terminal encoded null 
            byte[] OIDpkcs5PBES2 = { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x05, 0x0D };
            byte[] OIDpkcs5PBKDF2 = { 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x05, 0x0C };
            byte[] OIDdesEDE3CBC = { 0x06, 0x08, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x03, 0x07 };
            byte[] seqdes = new byte[10];
            byte[] seq = new byte[11];
            byte[] salt;
            byte[] IV;
            byte[] encryptedpkcs8;
            byte[] pkcs8;

            int saltsize, ivsize, encblobsize;
            int iterations;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            MemoryStream mem = new MemoryStream(keyBytes);
            BinaryReader binReader = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;

            try
            {
                twobytes = binReader.ReadUInt16();
                if (twobytes == 0x8130)
                    //data read as little endian order (actual data order for Sequence is 30 81)
                    binReader.ReadByte();	//advance 1 byte
                else if (twobytes == 0x8230)
                    binReader.ReadInt16();	//advance 2 bytes
                else
                    return null;

                twobytes = binReader.ReadUInt16();	//inner sequence
                if (twobytes == 0x8130)
                    binReader.ReadByte();
                else if (twobytes == 0x8230)
                    binReader.ReadInt16();


                seq = binReader.ReadBytes(11);		//read the Sequence OID
                if (!Binary.CompareBytearrays(seq, OIDpkcs5PBES2))	//is it a OIDpkcs5PBES2 ?
                    return null;

                twobytes = binReader.ReadUInt16();	//inner sequence for pswd salt
                if (twobytes == 0x8130)
                    binReader.ReadByte();
                else if (twobytes == 0x8230)
                    binReader.ReadInt16();

                twobytes = binReader.ReadUInt16();	//inner sequence for pswd salt
                if (twobytes == 0x8130)
                    binReader.ReadByte();
                else if (twobytes == 0x8230)
                    binReader.ReadInt16();

                seq = binReader.ReadBytes(11);		//read the Sequence OID
                if (!Binary.CompareBytearrays(seq, OIDpkcs5PBKDF2))	//is it a OIDpkcs5PBKDF2 ?
                    return null;

                twobytes = binReader.ReadUInt16();
                if (twobytes == 0x8130)
                    binReader.ReadByte();
                else if (twobytes == 0x8230)
                    binReader.ReadInt16();

                bt = binReader.ReadByte();
                if (bt != 0x04)		//expect octet string for salt
                    return null;
                saltsize = binReader.ReadByte();
                salt = binReader.ReadBytes(saltsize);

                bt = binReader.ReadByte();
                if (bt != 0x02) 	//expect an integer for PBKF2 interation count
                    return null;

                int itbytes = binReader.ReadByte();	//PBKD2 iterations should fit in 2 bytes.
                if (itbytes == 1)
                    iterations = binReader.ReadByte();
                else if (itbytes == 2)
                    iterations = 256 * binReader.ReadByte() + binReader.ReadByte();
                else
                    return null;

                twobytes = binReader.ReadUInt16();
                if (twobytes == 0x8130)
                    binReader.ReadByte();
                else if (twobytes == 0x8230)
                    binReader.ReadInt16();


                seqdes = binReader.ReadBytes(10);		//read the Sequence OID
                if (!Binary.CompareBytearrays(seqdes, OIDdesEDE3CBC))	//is it a OIDdes-EDE3-CBC ?
                    return null;

                bt = binReader.ReadByte();
                if (bt != 0x04)		//expect octet string for IV
                    return null;
                ivsize = binReader.ReadByte();	// IV byte size should fit in one byte (24 expected for 3DES)
                IV = binReader.ReadBytes(ivsize);

                bt = binReader.ReadByte();
                if (bt != 0x04)		// expect octet string for encrypted PKCS8 data
                    return null;


                bt = binReader.ReadByte();

                if (bt == 0x81)
                    encblobsize = binReader.ReadByte();	// data size in next byte
                else if (bt == 0x82)
                    encblobsize = 256 * binReader.ReadByte() + binReader.ReadByte();
                else
                    encblobsize = bt;		// we already have the data size


                encryptedpkcs8 = binReader.ReadBytes(encblobsize);
                SecureString secpswd = new SecureString();
                foreach (char c in password)
                    secpswd.AppendChar(c);

                pkcs8 = DecryptPBDK2(encryptedpkcs8, salt, IV, secpswd, iterations);
                if (pkcs8 == null)	// probably a bad pswd entered.
                    return null;

                RSACryptoServiceProvider rsa = DecodePrivateKeyInfo(pkcs8);
                return rsa;
            }

            catch (Exception)
            {
                return null;
            }
            finally { binReader.Close(); }
        }

        private static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            // this byte[] includes the sequence byte and terminal encoded null 
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];
            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            MemoryStream mem = new MemoryStream(pkcs8);
            int lenstream = (int)mem.Length;
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;

            try
            {

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)	//data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();	//advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();	//advance 2 bytes
                else
                    return null;


                bt = binr.ReadByte();
                if (bt != 0x02)
                    return null;

                twobytes = binr.ReadUInt16();

                if (twobytes != 0x0001)
                    return null;

                seq = binr.ReadBytes(15);		//read the Sequence OID
                if (!Binary.CompareBytearrays(seq, SeqOID))	//make sure Sequence for OID is correct
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x04)	//expect an Octet string 
                    return null;

                bt = binr.ReadByte();		//read next byte, or next 2 bytes is  0x81 or 0x82; otherwise bt is the byte count
                if (bt == 0x81)
                    binr.ReadByte();
                else
                    if (bt == 0x82)
                    binr.ReadUInt16();
                //------ at this stage, the remaining sequence should be the RSA private key

                byte[] rsaprivkey = binr.ReadBytes((int)(lenstream - mem.Position));
                RSACryptoServiceProvider rsacsp = DecodeRSAPrivateKey(rsaprivkey);
                return rsacsp;
            }

            catch (Exception)
            {
                return null;
            }

            finally { binr.Close(); }
        }

        private static byte[] DecryptPBDK2(byte[] edata, byte[] salt,
              byte[] IV, SecureString secpswd, int iterations)
        {
            CryptoStream decrypt = null;

            IntPtr unmanagedPswd = IntPtr.Zero;
            byte[] psbytes = new byte[secpswd.Length];
            unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
            Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length);
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd);

            try
            {
                Rfc2898DeriveBytes kd = new Rfc2898DeriveBytes(psbytes, salt, iterations);
                TripleDES decAlg = TripleDES.Create();
                decAlg.Key = kd.GetBytes(24);
                decAlg.IV = IV;
                MemoryStream memstr = new MemoryStream();
                decrypt = new CryptoStream(memstr, decAlg.CreateDecryptor(), CryptoStreamMode.Write);
                decrypt.Write(edata, 0, edata.Length);
                decrypt.Flush();
                decrypt.Close();	// this is REQUIRED.
                byte[] cleartext = memstr.ToArray();
                return cleartext;
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem decrypting: {0}", e.Message);
                return null;
            }
        }

        private static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)	//data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();	//advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();	//advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)	//version number
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;


                //------  all private key components are Integer sequences ----
                elems = Binary.GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = Binary.GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                Console.WriteLine("showing components ..");

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally { binr.Close(); }
        }
    }
}
